using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGemDisplayBehaviour : MonoBehaviour
{
    //[SerializeField] SpriteRenderer blueEmpty;
    //[SerializeField] SpriteRenderer blueFull;

    //[SerializeField] SpriteRenderer redGem;
    //[SerializeField] SpriteRenderer blueGem;
    private bool firstTime = true;
    float offset = 0f;

    private Dictionary<int, DataStructures.spritePair> maxDoorPickUps;
        //= new Dictionary<int, PickUpManager.spritePair>();



    void OnEnable()
    {
        PickUpManager.OnDoorPickUpUpdate += OnUpdate;
    }

    void OnDisable()
    {
        PickUpManager.OnDoorPickUpUpdate -= OnUpdate;
    }

    private void MoveSprite(GameObject temp)
    {
        temp.transform.SetParent(this.gameObject.transform);
        temp.GetComponent<Image>().type = Image.Type.Tiled;
        temp.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
        temp.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
        temp.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
        temp.GetComponent<RectTransform>().localPosition = new Vector3(20f, -20 + offset, 0f);
    }

    private void OnUpdate(Dictionary<int, DataStructures.spritePair> doorPickUps)
    {
        if (firstTime)
        {
            maxDoorPickUps = new Dictionary<int, DataStructures.spritePair>(doorPickUps);
            foreach (int key in doorPickUps.Keys)
            {
                GameObject temp = new GameObject();
                temp.AddComponent<Image>().sprite = doorPickUps[key].sprite;
                temp.GetComponent<Image>().color = new Color(temp.GetComponent<Image>().color.r, temp.GetComponent<Image>().color.g, temp.GetComponent<Image>().color.b, .5f);
                temp.GetComponent<RectTransform>().sizeDelta = new Vector2(doorPickUps[key].value * 100, 100);               
                MoveSprite(temp);

                temp = new GameObject();
                temp.name = key.ToString();
                temp.AddComponent<Image>().sprite = doorPickUps[key].sprite;
                temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 100);
                MoveSprite(temp);
                offset -= 110;

                //this.gameObject.AddComponent<SpriteRenderer>().sprite = doorPickUps[key].sprite;
            }
            firstTime = false;
        }

        else
        {
            foreach (int key in doorPickUps.Keys)
            {
                int tempAmount = maxDoorPickUps[key].value - doorPickUps[key].value;
                GameObject temp = GameObject.Find(key.ToString());
                temp.GetComponent<RectTransform>().sizeDelta = new Vector2(tempAmount * 100, 100);
            }
        }
    }
}