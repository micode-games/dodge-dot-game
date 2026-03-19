using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private GameObject deathExplosion;
    [SerializeField] private GameObject slideEffect;

    [SerializeField] private CameraShake cameraShake;

    private bool _deathSpawned;

    private void Start()
    {
        deathExplosion.SetActive(false);
        slideEffect.SetActive(false);
    }

    private void Update()
    {
        if (playerCollision == null) return;

        Vector3 playerPosition = playerTransform.position;
        slideEffect.transform.position = playerPosition;

        HandleDeathEffect(playerPosition);
        HandleSlideEffect();
    }

    private void HandleDeathEffect(Vector3 playerPosition)
    {
        if (playerCollision.isDead && !_deathSpawned)
        {
            deathExplosion.transform.position = playerPosition;
            deathExplosion.SetActive(true);
            slideEffect.SetActive(false);

            _deathSpawned = true;

            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        }
    }

    private void HandleSlideEffect()
    {
        bool isSliding = playerCollision.isTouchedWallLeft || playerCollision.isTouchedWallRight;
        slideEffect.SetActive(isSliding);
    }
}