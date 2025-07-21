using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Doors/CloseDoor")]
    public class CloseDoor : Action
    {
        public override void Act(StateController controller)
        {
            controller.GetComponent<Animator>().SetBool("Open", false);
        }
    }
}