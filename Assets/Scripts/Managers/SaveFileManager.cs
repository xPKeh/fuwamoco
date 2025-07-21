using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveFileManager : MonoBehaviour
{
    private DataStructures.SaveObject currentSave = new();
    public static SaveFileManager instance;
    //private const string SAVE_SEPARATOR = "#SAVE-VALUE#";

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Load();
        Debug.Log(currentSave.victorias);
        Debug.Log(currentSave.completedLevels);
    }

    public void LevelComplete(int indexW, int indexLvl, DataStructures.LevelStars levelStars)
    {
        updateSave(indexW, indexLvl, levelStars);
        Save();
        Debug.Log("saved 2");
    }

    private void updateSave(int indexW, int indexLvl, DataStructures.LevelStars levelStars)
    {
        currentSave.victorias++;

        // Actualiza el nivel completado
        if (currentSave.completedLevels.W < indexW)
        {
            currentSave.completedLevels.Lvl = 1;
            currentSave.completedLevels.W = indexW;
        }
        
        if (currentSave.completedLevels.Lvl < indexLvl && currentSave.completedLevels.W == indexW)
        {
            currentSave.completedLevels.Lvl = indexLvl;
        }


        DataStructures.LevelId levelId;
        levelId.W = indexW;
        levelId.Lvl = indexLvl;

        // Usar el LevelStarsDictionaryWrapper para actualizar el diccionario
        if (!currentSave.levelStarsDictionaryWrapper.levelStarsDictionary.ContainsKey(levelId))
        {
            currentSave.levelStarsDictionaryWrapper.levelStarsDictionary.Add(levelId, levelStars);
        }

        else
        {
            DataStructures.LevelStars saveLevelStars = currentSave.levelStarsDictionaryWrapper.levelStarsDictionary[levelId];
            if (levelStars.star1) saveLevelStars.star1 = true;
            if (levelStars.star2) saveLevelStars.star2 = true;
            if (levelStars.star3) saveLevelStars.star3 = true;
            currentSave.levelStarsDictionaryWrapper.levelStarsDictionary[levelId] = saveLevelStars;
        }
    }

    private void Save()
    {
        // Prepara los datos antes de serializar
        currentSave.levelStarsDictionaryWrapper.ConvertDictionaryToList();

        // Serializa el SaveObject
        string json = JsonUtility.ToJson(currentSave);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    private void Load()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            DataStructures.SaveObject saveObject = JsonUtility.FromJson<DataStructures.SaveObject>(saveString);

            // Restaura el diccionario desde la lista
            saveObject.levelStarsDictionaryWrapper.ConvertListToDictionary();

            // Asigna los datos restaurados a currentSave
            currentSave = saveObject;
        }
    }

    public DataStructures.SaveObject GetSaveData()
    {
        return currentSave;
    }
}