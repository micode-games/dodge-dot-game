using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isTouchedWallLeft;
    public bool isTouchedWallRight;
    public bool isDead;

    private AudioManager _audioManager;
    [SerializeField] private CameraShake cameraShake;


    private void Start()
    {
        _audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WallLeft"))
        {
            isTouchedWallLeft = true;
            OnWallHit();
        }

        if (other.gameObject.CompareTag("WallRight"))
        {
            isTouchedWallRight = true;
            OnWallHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            _audioManager.PlayDeathSound();
            isDead = true;
        }
    }

    private void OnWallHit()
    {
        _audioManager.PlayHitSound();
        StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
    }
}