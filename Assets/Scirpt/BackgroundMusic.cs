using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public float PuaseTime;
    public string[] BGMPath;

    private AudioClip[] BGM;
    private AudioSource MAudioSource;

    private void Awake()
    {
        LoadBGM();
        MAudioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!MAudioSource.isPlaying)
        {
            MAudioSource.clip = BGM[Random.Range(0, BGM.Length)];
            MAudioSource.PlayDelayed(PuaseTime);
        }
    }

    private void LoadBGM()
    {
        BGM = new AudioClip[BGMPath.Length];
        for (int i = 0; i < BGMPath.Length; i++)
        {
            BGM[i] = Resources.Load<AudioClip>(BGMPath[i]);
        }
    }
}
