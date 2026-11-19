using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [Serializable] public class Transition
    {
        public State goToState;
        public Decision[] decisions;

        public bool Decide(StateController controller)
        {
            foreach (Decision decision in decisions) 
            {
                if (!decision.Decide(controller)) return false;    
            }
            return true;
        }
    }
}
