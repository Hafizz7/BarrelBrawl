using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Diagnostics;

public class MainMenu : MonoBehaviour
{
    public Slider SliderBackgroundMusic;
    public Slider SliderSFXMusic;


    public void SliderVolumeMusic()
    {
        SoundManager.Instance.BackgroundMusic.volume = SliderBackgroundMusic.value;
        SoundManager.Instance.Musicc.volume = SliderBackgroundMusic.value;


        if (SliderBackgroundMusic.value == SliderBackgroundMusic.minValue)
        {
            SoundManager.Instance.BackgroundMusic.mute = true;
            SoundManager.Instance.Musicc.mute = true;



        }
        else
        {
            SoundManager.Instance.BackgroundMusic.mute = false;
            SoundManager.Instance.Musicc.mute = false;

            ;
        }
    }

    public void SliderVolumeSFX()
    {
        SoundManager.Instance.SoundEffect.volume = SliderSFXMusic.value;
        SoundManager.Instance.SoundJump.volume = SliderSFXMusic.value;
        SoundManager.Instance.SoundGameComplate.volume = SliderSFXMusic.value;
        SoundManager.Instance.SoundGameOverr.volume = SliderSFXMusic.value;
        

        if (SliderSFXMusic.value == SliderSFXMusic.minValue)
        {
            SoundManager.Instance.SoundEffect.mute = true;
            SoundManager.Instance.SoundJump.mute = true;
            SoundManager.Instance.SoundGameComplate.mute = true;
            SoundManager.Instance.SoundGameOverr.mute = true;
        }
        else
        {
            SoundManager.Instance.SoundEffect.mute = false;
            SoundManager.Instance.SoundJump.mute = false;
            SoundManager.Instance.SoundGameComplate.mute = false;
            SoundManager.Instance.SoundGameOverr.mute = false;
        }
    }

    public void Start()
    {
        SliderBackgroundMusic.value = SoundManager.Instance.BackgroundMusic.volume;
        SliderSFXMusic.value = SoundManager.Instance.SoundEffect.volume;
    }

    public void ButtonClick()
    {
        SoundManager.Instance.ButtonSound();
    }
    public void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();        
    }
}