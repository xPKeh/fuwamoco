using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 2f;
    private Vector2 targetPos;

    private void Start()
    {
        targetPos = endPoint.position;
    }

    private void Update()
    {
        ChangeTarget();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public void ChangeTarget()
    {
        if (Vector2.Distance(transform.position, startPoint.position) < .5f) targetPos = endPoint.position;
        if (Vector2.Distance(transform.position, endPoint.position) < .5f) targetPos = startPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>() && collision.GetComponent<Movement>().IsPlatform()) collision.transform.SetParent(this.transform);
        if (collision.GetComponent<GrabbableSystem>() && collision.GetComponent<GrabbableSystem>().transform.parent == null) collision.transform.SetParent(this.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Movement>()) collision.transform.SetParent(null);
    }

    private void OnDrawGizmos()
    {
        if(startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(transform.position, startPoint.position);
            Gizmos.DrawLine(transform.position, endPoint.position);
        }
    }
}
