﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMultipleSoundsView : MonoBehaviour, IPointerClickHandler
{
    public AudioSource AudioSource;  
    public AudioClip ClickSound;
    public AudioClip secondClip;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayClickSound();
    }

    private void PlayClickSound()
    {
        AudioSource.PlayOneShot(ClickSound);
        AudioSource.PlayOneShot(secondClip);
    }

    public void PlaySecondClick()
    {
        if (!AudioSource.isPlaying)
        {
            AudioSource.loop = true;
            AudioSource.PlayOneShot(secondClip);
        }
    }

    public void StopSecondClick()
    {
        AudioSource.loop = false;
        AudioSource.Stop();
    }
}