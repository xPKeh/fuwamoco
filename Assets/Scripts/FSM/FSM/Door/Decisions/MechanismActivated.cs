using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public enum StateCheck
    {
        Active,
        Open,
        PlayerOut,
        PlayerIn,
    }
    [CreateAssetMenu(menuName = "FSM/Decisions/Door/MechanismActivated")]

    public class MechanismActivated : Decision
    {
        public StateCheck sc;
        public override bool Decide(StateController controller)
        {
            switch (sc)
            {
                case StateCheck.Active:
                    return controller.gameObject.GetComponent<StatusDoorInfo>().active;
                case StateCheck.Open:
                    return controller.gameObject.GetComponent<StatusDoorInfo>().open;
                case StateCheck.PlayerOut:
                    return controller.gameObject.GetComponent<InteractuableDoorBehaviour>().player;
                case StateCheck.PlayerIn:
                    return !controller.gameObject.GetComponent<InteractuableDoorBehaviour>().player;
            }
            return false;
        }
    }
}
