using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/SwitchParticles")]
    public class SwitchParticles : Action
    {
        public bool state;
        public override void Act(StateController controller)
        {
            if(state) controller.GetComponentInChildren<ParticleSystem>().Play();
            else controller.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }
}
