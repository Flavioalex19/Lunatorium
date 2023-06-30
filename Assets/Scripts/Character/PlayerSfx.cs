using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    //Player
    [SerializeField] AudioSource sfx_playerFootsSteps;

    public void PlaySFXFootSteps()
    {
        sfx_playerFootsSteps.Play();
    }
}
