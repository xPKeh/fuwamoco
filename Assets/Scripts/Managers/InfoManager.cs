using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    private DataStructures.SaveObject currentSave = new DataStructures.SaveObject();
    [SerializeField]private DataStructures.LevelId currentLevel;

    void Awake()
    {
        Manager.instance.InfoManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetData();
    }

    public void GetData()
    {
        currentSave = SaveFileManager.instance.GetSaveData();
    }

    
    public DataStructures.SaveObject GetLvlData()
    {
        return currentSave;
    }



    public bool IsDoorOpen(DataStructures.LevelId levelid)
    {
        if (currentSave.completedLevels.Lvl >= levelid.Lvl)
            return true;
        return false;
    }


    //Coger los datos del save, añadir levelID SerializeField para añadirlo en cada nivel y quitar el level id de las puertas.
    //Leer la estructura de datos para gestionar que puertas del menu estan desbloqueadas (completedLevels)
    //Enviar los datos al save cuando se complete el nivel (estrellas completadas, tiempo, etc.)

}
