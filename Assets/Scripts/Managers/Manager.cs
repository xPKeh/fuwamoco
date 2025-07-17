using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public DoorManager DoorManager;
    public PickUpManager PickUpManager;
    public SceneLoadManager SceneLoadManager;
    public InfoManager InfoManager;



    private void Awake()
    {
        if (instance == null)
        //GetComponentInChildren<DoorLevelManager>() == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }
    public void addPlayerDoor(int world, int lvl)
    {
        if(DoorManager == null)
        {
            return;
        }
        DoorManager.AddPlayerInDoor(world, lvl);

    }

    public void subPlayerDoor()
    {
        if (DoorManager == null)
        {
            return;
        }
        DoorManager.SubPlayerInDoor();
    }

    public void addDoorPickUp(GameObject obj)
    {
        if (PickUpManager == null)
        {
            return;
        }
        PickUpManager.AddDoorPickUp(obj);
    }

    public void subDoorPickUp(GameObject obj)
    {
        if (PickUpManager == null)
        {
            return;
        }
        PickUpManager.SubDoorPickUp(obj);
    }

    public void loadMenuScene()
    {
        if (SceneLoadManager == null)
        {
            return;
        }
        SceneLoadManager.LoadMenuScene();
    }

    public void loadLevelScene(int indexW, int indexLvl)
    {
        if (SceneLoadManager == null)
        {
            return;
        }
        SceneLoadManager.LoadLevelScene(indexW, indexLvl);
    }

}
