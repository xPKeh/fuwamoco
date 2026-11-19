using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/MoveToPlayer")]
    public class MoveToPlayer : Action
    {
        public float speed;
        public override void Act(StateController controller)
        {
            //var target = GameManager.Instance.player.transform.position;
            //controller.GetComponent<IMovementBehaviour>().MoveToTarget(target, speed);
        }
    }
}

