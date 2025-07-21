using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public enum OperatorType
    {
        LessThan, 
        LessThanOrEqual,
        GreaterThan, 
        GreaterThanOrEqual,
        Equals
    }

    [CreateAssetMenu(menuName = "FSM/Decisions/DistanceOp")]

    public class DistanceOp: Decision
    {
        public float distance;
        public OperatorType op;
        public override bool Decide(StateController controller)
        {
            /*var realDistance = controller.transform.position - GameManager.Instance.player.transform.position;
            switch (op)
            {
                case OperatorType.LessThan:
                    return realDistance.magnitude < distance;
                case OperatorType .LessThanOrEqual:
                    return realDistance.magnitude <= distance;
                case OperatorType.GreaterThanOrEqual:
                    return realDistance.magnitude > distance;
                case OperatorType.GreaterThan:
                    return realDistance.magnitude >= distance;
                case OperatorType.Equals:
                    return realDistance.magnitude == distance;
                
            }*/
            return false;
        }
    }
}