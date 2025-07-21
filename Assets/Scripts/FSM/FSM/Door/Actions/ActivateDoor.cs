using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Doors/ActivateDoor")]
    public class ActivateDoor : Action
    {
        public override void Act(StateController controller)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.portalActivate);
            controller.GetComponent<Animator>().SetBool("Active", true);
        }
    }
}
