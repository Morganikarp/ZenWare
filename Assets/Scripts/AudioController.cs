using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public MasterGameController MGC;
    public AudioClip[] SFX;

    AudioSource AUSource;

    void Start()
    {
        AUSource = GetComponent<AudioSource>();

    }

    void Update()
    {

        if (MGC.TitleMusic == true)
        {
            MGC.TitleMusic = false;
            AUSource.loop = true;
            AUSource.clip = SFX[0];
            AUSource.Play();
        }

        if (MGC.StartSFX == true)
        {
            MGC.StartSFX = false;
            AUSource.Stop();
            AUSource.loop = false;
            AUSource.clip = SFX[1];
            AUSource.Play();
        }
        
        if (MGC.GameMusic == true)
        {
            MGC.GameMusic = false;
            AUSource.Stop();
            AUSource.loop = true;
            AUSource.clip = SFX[2];
            AUSource.Play();
        }
        
        if (MGC.EndSFX == true)
        {
            MGC.EndSFX = false;
            AUSource.Stop();
            AUSource.loop = false;
            AUSource.clip = SFX[3];
            AUSource.Play();
        }
    }
}
