using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorBehaviour : MonoBehaviour
{
    private bool active = false;
    private bool fireboy = false;
    private bool watergirl = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void ActivateDoor()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.portalActivate);
        anim.SetBool("active", true);
        active = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireboy")) 
        { 
            fireboy = true;
            CheckDoor();
        }
        if (collision.gameObject.CompareTag("Watergirl")) 
        { 
            watergirl = true;
            CheckDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireboy")) 
        { 
            fireboy = false;
        }
        if (collision.gameObject.CompareTag("Watergirl")) 
        { 
            watergirl = false;
        }
    }

    private void CheckDoor()
    {
        if (fireboy && watergirl && active) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
