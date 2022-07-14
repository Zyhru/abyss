

using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public Sound[] sounds;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this);
        }


        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
            sound.source.pitch = sound.pitch;

        }
        

    }


 

    public void Play(string e)
    {
        foreach (Sound s in sounds)
        {
            if (e == s.clipName)
            {
                s.source.Play();
            }
        }
    }


  

    [System.Serializable]
    public class Sound
    {
        public string clipName;
        public AudioClip clip;

        [Range(0, 1f)] public float volume;
        [Range(.1f, 3f)] public float pitch;
        public bool loop;

        [HideInInspector] public AudioSource source;

    }
    
    
    
}
