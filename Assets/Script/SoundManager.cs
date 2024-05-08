using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource BackgroundMusic;
    public AudioSource SoundEffect;

    public AudioClip ButtonClick;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            BackgroundMusic.Pause();
        }
    }

    private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        if (newScene.buildIndex == 0)
        {
            PlayBackgroundMusic();
        }
    }

    private void PlayBackgroundMusic()
    {
        if (BackgroundMusic != null && !BackgroundMusic.isPlaying)
        {
            BackgroundMusic.Play();
        }
    }

    public void ButtonSound()
    {
        SoundEffect.PlayOneShot(ButtonClick);
    }
}
