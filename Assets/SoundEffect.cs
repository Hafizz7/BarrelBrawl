using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip ButtonClick;    
    public void ButtonClk()
    {
        SoundManager.Instance.ButtonSound();
    }
}
