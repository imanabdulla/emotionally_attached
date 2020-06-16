using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundClip
    {
        public AudioClip click;
        public AudioClip yay;
        public AudioClip greatYay;
        public AudioClip waterSink;
        public AudioClip hairDrier;
        public AudioClip cabinetSound;
        public AudioClip curtainSound;
        public AudioClip doorSound;
    }

    [System.Serializable]
    public class MusicClip
    {
        public AudioClip gamePlayMusic;
        public AudioClip birdsSound;
        public AudioClip rainsSound;
    }

    public SoundClip soundClip;
    public MusicClip musicClip;
    public AudioSource musicSource, soundSource;
    public Scrollbar musicScrollbar, soundsScrollbar;
    public bool isMusicStarted;

    #region  singleton
    public static AudioManager audioManager;

    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(audioManager);
        }
        else
        {
            Destroy(GameObject.Find("AudioManager"));
            audioManager = this;
            DontDestroyOnLoad(audioManager);
        }
    }
    #endregion

    private void Start()
    {
        if (PlayerPrefs.GetInt("MUSIC-ON", 1) == 1)
        {
            musicSource.enabled = true;
            musicScrollbar.value = 1;
        }
        else if (PlayerPrefs.GetInt("MUSIC-ON") == 0)
        {
            musicSource.enabled = false;
            musicScrollbar.value = 0;
        }
        if (PlayerPrefs.GetInt("SOUNDS-ON", 1) == 1)
        {
            soundSource.enabled = true;
            soundsScrollbar.value = 1;
        }
        else if (PlayerPrefs.GetInt("SOUNDS-ON") == 0)
        {
            soundSource.enabled = false;
            soundsScrollbar.value = 0;
        }
    }

    public void PlayMusic(AudioClip[] clips, float[] volumes, bool loop)
    {
        musicSource.loop = loop;
        musicSource.volume = volumes[0];

        for (int i = 0; i < clips.Length; i++)
        {
            musicSource.PlayOneShot(clips[i], volumes[i]);
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySound(AudioClip clip, bool loop, float vloume)
    {
        soundSource.clip = clip;
        soundSource.loop = loop;
        soundSource.volume = vloume;
        soundSource.Play();
    }

    public void StopSound()
    {
        soundSource.Stop();
    }

    public void SwitchMusicONOFF()
    {
        if (musicScrollbar.value == 1)
        {
            musicSource.enabled = true;
            PlayerPrefs.SetInt("MUSIC-ON", 1);
        }
        else
        {
            musicSource.enabled = false;
            PlayerPrefs.SetInt("MUSIC-ON", 0);
        }
    }

    public void SwitchSoundONOFF()
    {
        if (soundsScrollbar.value == 1)
        {
            soundSource.enabled = true;
            PlayerPrefs.SetInt("SOUNDS-ON", 1);
        }
        else
        {
            soundSource.enabled = false;
            PlayerPrefs.SetInt("SOUNDS-ON", 0);
        }
    }
}