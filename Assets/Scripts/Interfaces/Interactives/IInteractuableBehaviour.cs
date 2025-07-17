using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractuableBehaviour
{
    // Start is called before the first frame update
    public void SetParentInteractuable(GameObject playerInteractuableSlot);
    public void RemoveParentInteractuable();
    public void Act();
    public void Act(GameObject Player);

}
