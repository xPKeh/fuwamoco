using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    //[SerializeField] private int levelIndex = 0;
    [SerializeField] private string scene;
    DataStructures.SaveObject currentSave = new DataStructures.SaveObject();
    // Start is called before the first frame update
    private void Awake()
    {
        Manager.instance.SceneLoadManager = this;
        Debug.Log(currentSave.victorias);
        Debug.Log(currentSave.completedLevels);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevelScene(int indexW, int indexLvl)
    {
        Debug.Log("dentro del load scene lvl: Nivel" + indexW + "_" + indexLvl);
        scene = "Nivel" + indexW.ToString() + "_" + indexLvl.ToString();
        SceneManager.LoadScene(scene);
    }
}
