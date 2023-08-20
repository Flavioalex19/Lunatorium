using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx_Manager : MonoBehaviour
{
    [SerializeField]AudioSource as_Env;//audio source for the enviroment
    [SerializeField]AudioSource as_heartbeat;

    [SerializeField] List<AudioClip> list_ac_Heartbeats = new List<AudioClip>();

    private void Start()
    {
        as_Env.Play();
        as_heartbeat.Stop();
    }
    
    public void StartSFXHeartBeat()
    {
        as_heartbeat.Play();
    }
    public void changeHeardbeatClip(int index)
    {
        as_heartbeat.Pause();
        as_heartbeat.clip = list_ac_Heartbeats[index];
        as_heartbeat.Play();
    }
}
