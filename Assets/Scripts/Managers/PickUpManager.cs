using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpManager : MonoBehaviour
{
    private DataStructures.spritePair currentAmount;

    [SerializeField] private Dictionary<int, DataStructures.spritePair> currentDoorPickUps = new Dictionary<int, DataStructures.spritePair>();

    public static event Action<Dictionary<int, DataStructures.spritePair>> OnDoorPickUpUpdate = delegate { };

    private void Awake()
    {
        Manager.instance.PickUpManager = this;
    }

    private void Start()
    {
        OnDoorPickUpUpdate(currentDoorPickUps);
    }

    public void AddDoorPickUp(GameObject obj)
    {
        if (!currentDoorPickUps.ContainsKey(obj.layer))
        {
            currentAmount.value = 1;
            currentAmount.sprite = obj.GetComponent<SpriteRenderer>().sprite;
            currentDoorPickUps.Add(obj.layer, currentAmount);
        }
        else
        {
            currentDoorPickUps.TryGetValue(obj.layer, out currentAmount);
            currentAmount.value++;
            currentDoorPickUps[obj.layer] = currentAmount;
        }

        //debug del diccionario.
        //currentDoorPickUps.TryGetValue(obj.layer, out currentAmount);
        //Debug.Log("layer:" + obj.layer);
        //Debug.Log("valor: " + currentAmount);
    }
    public void SubDoorPickUp(GameObject obj)
    {
        currentDoorPickUps.TryGetValue(obj.layer, out currentAmount);
        currentAmount.value--;
        currentDoorPickUps[obj.layer] = currentAmount;
        OnDoorPickUpUpdate(currentDoorPickUps);
    }
}
