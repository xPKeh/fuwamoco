using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitchBehaviour : MonoBehaviour, IInteractuableBehaviour
{
    [SerializeField] private Color redColor;
    [SerializeField] private int redLayer;
    [SerializeField] private Color blueColor;
    [SerializeField] private int blueLayer;
    [SerializeField] private GameObject[] gateToSwitch;
    

    public void Act() {
        foreach (GameObject gts in gateToSwitch)
        {
            if (gts.layer == redLayer)
            {
                gts.layer = blueLayer;
                gts.GetComponent<SpriteRenderer>().color = blueColor;
            }
            else
            {
                gts.layer = redLayer;
                gts.GetComponent<SpriteRenderer>().color = redColor;
            }
        }
    }

    void IInteractuableBehaviour.Act(GameObject PlayerObject) { }

    void IInteractuableBehaviour.RemoveParentInteractuable()
    {
        throw new System.NotImplementedException();
    }

    void IInteractuableBehaviour.SetParentInteractuable(GameObject playerInteractuableSlot)
    {
        throw new System.NotImplementedException();
    }

}
