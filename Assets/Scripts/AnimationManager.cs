using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private Transform playerSkin;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = playerSkin.localPosition;
    }

    private void Update()
    {
        if (!playerCollision.isTouchedWallLeft && !playerCollision.isTouchedWallRight)
            return;

        Vector3 noiseOffset = new Vector3(
            Mathf.PerlinNoise(Time.time * 5f, 0f) - 0.5f,
            Mathf.PerlinNoise(0f, Time.time * 5f) - 0.5f,
            0f
        ) * 0.1f;

        playerSkin.localPosition = _startPosition + noiseOffset;
    }
}