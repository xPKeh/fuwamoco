using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] redGem;
    [SerializeField] GameObject[] blueGem;

    [SerializeField] SpriteRenderer blueEmpty;
    [SerializeField] SpriteRenderer blueFull;

    [SerializeField] SpriteRenderer redEmpty;
    [SerializeField] SpriteRenderer redFull;

    [SerializeField] private int redTaken = 0;
    [SerializeField] private int blueTaken = 0;

    [SerializeField] private DoorBehaviour db;

    //en vez de hacer 2 listas y trabajar con eso por inspector, con scriptable objects puedo pasar los datos y no necesito ir tocandolo en cada escena.
    private void Awake()
    {
        blueEmpty.size = new Vector2 (blueGem.Length * 2.24f, blueEmpty.size.y);
        //blueEmpty.transform.position = new Vector2(blueEmpty.transform.position.x + 2.24f, blueEmpty.transform.position.y);     

        redEmpty.size = new Vector2(redGem.Length * 0.16f, redEmpty.size.y);
        //redEmpty.transform.position = new Vector2(redEmpty.transform.position.x - 0.16f, redEmpty.transform.position.y);

        redFull.gameObject.SetActive(false);
        blueFull.gameObject.SetActive(false);

        //redEmpty.rectTransform.sizeDelta = new Vector2(redGem.Length * 1.12f, redEmpty.rectTransform.rect.height);

        // redEmpty.size = new Vector2(redEmpty.size.x * redGem.Length, redEmpty.size.y);
    }

    private void OnEnable()
    {
        BlueGemBehaviour.OnGotBlueGem += GotBlueGem;
        RedGemBehaviour.OnGotRedGem += GotRedGem;
    }

    private void OnDisable()
    {
        BlueGemBehaviour.OnGotBlueGem -= GotBlueGem;
        RedGemBehaviour.OnGotRedGem += GotRedGem;
    }

    public void GotRedGem()
    {
        redFull.gameObject.SetActive(true);

        if (redTaken < redGem.Length)
        { 
            redTaken++;
            redFull.size = new Vector2(redTaken * 0.16f, redFull.size.y);
            //redFull.transform.position = new Vector2(redFull.transform.position.x + 2f, redFull.transform.position.y);
        }
        TryActivateDoor();
    }

    public void GotBlueGem()
    {
        blueFull.gameObject.SetActive(true);

        if (blueTaken < blueGem.Length)
        {
            blueTaken++;
            blueFull.size = new Vector2(blueTaken * 2.24f, blueFull.size.y);
        }
        //blueFull.transform.position = new Vector2(blueFull.transform.position.x - 2f, blueFull.transform.position.y);
        TryActivateDoor();
    }

    private void TryActivateDoor()
    {

        if (redTaken == redGem.Length && blueTaken == blueGem.Length) db.ActivateDoor();
    }
}
