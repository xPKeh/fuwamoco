using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructures : MonoBehaviour
{
    public struct spritePair
    {
        public int value;
        public Sprite sprite;
    }

    [System.Serializable]
    public struct SaveObject
    {
        public int victorias;
        public LevelId completedLevels;
        public LevelStarsDictionaryWrapper levelStarsDictionaryWrapper; // Clase que maneja el diccionario

        // Función que convierte el diccionario a una lista antes de serializar
        public void PrepareForSerialization()
        {
            levelStarsDictionaryWrapper.ConvertDictionaryToList();
        }

        // Función que reconstruye el diccionario desde la lista después de deserializar
        public void RestoreFromSerialization()
        {
            levelStarsDictionaryWrapper.ConvertListToDictionary();
        }
    }

    [System.Serializable]
    public struct LevelId
    {
        public int W;
        public int Lvl;
    }

    [System.Serializable]
    public struct LevelStars
    {
        public bool star1;
        public bool star2;
        public bool star3;
    }

    // Clase que envuelve el diccionario y proporciona funciones para convertirlo
    [System.Serializable]
    public class LevelStarsDictionaryWrapper
    {
        public List<LevelStarsPair> levelStarsList; // Lista de pares para serialización

        // Diccionario que será usado internamente en el código
        [System.NonSerialized]
        public Dictionary<LevelId, LevelStars> levelStarsDictionary;

        public LevelStarsDictionaryWrapper()
        {
            levelStarsList = new List<LevelStarsPair>();
            levelStarsDictionary = new Dictionary<LevelId, LevelStars>();
        }

        // Función que convierte el diccionario a lista
        public void ConvertDictionaryToList()
        {
            levelStarsList.Clear(); // Limpia la lista antes de agregar nuevos elementos
            foreach (var entry in levelStarsDictionary)
            {
                levelStarsList.Add(new LevelStarsPair { levelId = entry.Key, levelStars = entry.Value });
            }
        }

        // Función que convierte la lista de vuelta a un diccionario
        public void ConvertListToDictionary()
        {
            levelStarsDictionary.Clear(); // Limpia el diccionario antes de agregar nuevos elementos
            foreach (var pair in levelStarsList)
            {
                levelStarsDictionary.Add(pair.levelId, pair.levelStars);
            }
        }
    }

    [System.Serializable]
    public struct LevelStarsPair
    {
        public LevelId levelId;
        public LevelStars levelStars;
    }
}



/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructures : MonoBehaviour
{
    public struct spritePair{
        public int value;
        public Sprite sprite;
    }

    [System.Serializable]
    public struct SaveObject{
        public int victorias;
        public LevelId completedLevels;
        public Dictionary<LevelId, LevelStars> LevelStarsDictionary;
    }

    [System.Serializable]
    public struct LevelId
    {
        public int W;                   
        public int Lvl;
    }

    [System.Serializable]
    public struct LevelStars{
        public bool star1;
        public bool star2;
        public bool star3;
    }
}
*/

