using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Doors/OpenDoor")]
    public class OpenDoor : Action
    {
        public override void Act(StateController controller)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.portalActivate);
            //controller.GetComponent<Animator>().SetBool("Open", true);
            //controller.GetComponent<Animator>().SetBool("Player", false);
        }
    }
}
