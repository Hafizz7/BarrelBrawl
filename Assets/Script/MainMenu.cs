using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider SliderBackgroundMusic;
    public Slider SliderSFXMusic;
    

    public void SliderVolumeMusic()
    {
        SoundManager.Instance.BackgroundMusic.volume = SliderBackgroundMusic.value;

        if (SliderBackgroundMusic.value == SliderBackgroundMusic.minValue)
        {
            SoundManager.Instance.BackgroundMusic.mute = true;
        }
        else
        {
            SoundManager.Instance.BackgroundMusic.mute = false;
        }
    }

    public void SliderVolumeSFX()
    {
        SoundManager.Instance.SoundEffect.volume = SliderSFXMusic.value;

        if (SliderSFXMusic.value == SliderSFXMusic.minValue)
        {
            SoundManager.Instance.SoundEffect.mute = true;
        }
        else
        {
            SoundManager.Instance.SoundEffect.mute = false;
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
}
