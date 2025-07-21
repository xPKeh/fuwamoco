using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Doors/FlagDoor")]
    public class FlagPlayer : Action
    {
        public override void Act(StateController controller)
        {
            controller.GetComponent<Animator>().SetBool("Player", true);
        }
    }
}

