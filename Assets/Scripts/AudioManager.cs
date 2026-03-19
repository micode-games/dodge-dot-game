using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [Header("Sound Effects")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;
    
    private AudioSource _audioSource;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    
    
    public void PlayHitSound()
    {
        if (hitSound != null)
        {
            _audioSource.PlayOneShot(hitSound);
        }
    }
    
    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            _audioSource.PlayOneShot(deathSound);
        }
    }
}
