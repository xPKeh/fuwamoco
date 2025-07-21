using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectBehaviour : MonoBehaviour, IMoveableObjectBehaviour
{
    // Start is called before the first frame update
    public bool IsPlatform()
    {
        return gameObject.GetComponent<GroundDetector>().IsPlatform();
    }
}

