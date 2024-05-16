using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource BackgroundMusic;
    public AudioSource SoundEffect;
    public AudioSource SoundJump;
    public AudioSource SoundGameComplate;
    public AudioSource SoundGameOverr;

    public AudioClip ButtonClick;
    public AudioClip MusicLevel1;
    public AudioClip MusicLevel2;
    public AudioClip MusicLevel3;
    // Tambahkan lebih banyak variabel AudioClip untuk arena lainnya jika diperlukan

    private float pausedTime; // Menyimpan waktu musik dijeda

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
        PlayMusicForScene(scene.buildIndex);
    }

    private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        PlayMusicForScene(newScene.buildIndex);
    }

    private void PlayMusicForScene(int sceneIndex)
    {
        AudioClip clipToPlay = null;

        switch (sceneIndex)
        {            
            case 2:
                clipToPlay = MusicLevel1;
                break;
            case 3:
                clipToPlay = MusicLevel2;
                break;
            case 4:
                clipToPlay = MusicLevel3;
                break;
            default:
                clipToPlay = null;
                break;
        }

        /*StopCurrentMusic();*/

        if (clipToPlay != null)
        {
            PlayMusic(clipToPlay);
        }
    }

    private void StopCurrentMusic()
    {
        if (BackgroundMusic.isPlaying)
        {
            BackgroundMusic.Stop();
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        if (BackgroundMusic.clip != clip)
        {
            BackgroundMusic.Stop();
            BackgroundMusic.clip = clip;
            BackgroundMusic.Play();
        }
        else
        {
            // Memulai kembali dari waktu terakhir jika musik masih berada di clip yang sama
            BackgroundMusic.time = pausedTime;
            BackgroundMusic.Play();
        }
    }

    public void ButtonSound()
    {
        SoundEffect.PlayOneShot(ButtonClick);
    }

    public void JumpSoundd()
    {
        SoundJump.PlayOneShot(SoundJump.clip);
    }

    public void GameComplateSound()
    {
        SoundGameComplate.PlayOneShot(SoundGameComplate.clip);
    }

    public void GameOverrSound()
    {
        SoundGameOverr.PlayOneShot(SoundGameOverr.clip);
    }

    // Metode untuk menjeda musik
    public void PauseMusic()
    {
        if (BackgroundMusic.isPlaying)
        {
            BackgroundMusic.Pause();
            pausedTime = BackgroundMusic.time; // Simpan waktu musik dijeda
        }
    }

    // Metode untuk melanjutkan musik dari waktu terakhir
    public void ResumeMusic()
    {
        if (!BackgroundMusic.isPlaying && BackgroundMusic.clip != null)
        {
            BackgroundMusic.Play();
            BackgroundMusic.time = pausedTime; // Mulai kembali dari waktu terakhir yang disimpan
        }
    }
}
