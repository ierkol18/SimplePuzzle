using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioClip matchSound;
    public AudioClip switchSound;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMatchSound()
    {
        audioSource.PlayOneShot(matchSound);
    }

    public void PlaySwitchSound()
    {
        audioSource.PlayOneShot(switchSound);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
}
