using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioSystem : MonoBehaviour
{
    public void audioInteractive(InputAction.CallbackContext context)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.playerInteractive);
    }
}
