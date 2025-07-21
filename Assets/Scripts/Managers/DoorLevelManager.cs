using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevelManager : DoorManager
{
    public int indexW;
    public int indexLvl;
    [SerializeField] private int doors = 0; // cantidad de puertas vacias a llenar con players
    private void Start()
    {
        if (Manager.instance.DoorManager == null)
            //GetComponentInChildren<DoorLevelManager>() == null)
        {
            Manager.instance.DoorManager = this;
            //DontDestroyOnLoad(gameObject);
        }
        /*else
        {
            Destroy(gameObject);
        }*/
    }
    
    //Resta 1 al contador de puertas que llenar con players, cuando este llega a 0 puertas se cambia de escena
    public override void AddPlayerInDoor(int door, int lvl)
    {
        doors--;
        if (doors == 0) {
            DataStructures.LevelStars lvlS = new(); // stub
            lvlS.star1 = true;
            SaveFileManager.instance.LevelComplete(indexW, indexLvl,lvlS);
            Manager.instance.loadMenuScene(); } //SceneManager siguiente escena/lobby
    }

    //Añade 1 al contador de puertas que llenar con players
    public override void SubPlayerInDoor()
    {
        doors++;
    }
}
