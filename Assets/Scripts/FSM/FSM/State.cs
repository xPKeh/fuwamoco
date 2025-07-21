using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class State : ScriptableObject
    {
        public Action[] enterActions, updateActions, exitActions;
        public Transition[] transitions;

        public void OnEnter(StateController controller)
        {
            ApplyState(controller, enterActions);
        }

        public void OnUpdate(StateController controller)
        {
            ApplyState(controller, updateActions);
            foreach (var t in transitions)
            {
                if (t.Decide(controller))
                {
                    controller.Transition(t.goToState);
                    return;
                }
            }
        }
        public void OnExit(StateController controller) 
        {  
            ApplyState(controller, exitActions); 
        }


        private void ApplyState(StateController controller, Action[] actions)
        {
            foreach (Action action in actions) 
            {
                action.Act(controller);
            }
        }
    }


}