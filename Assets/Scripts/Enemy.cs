using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float resetY = 6f;
    [SerializeField] private float resetOffset = 10f;

    [SerializeField] private Transform player;
    [SerializeField] private PlayerCollision playerCollision;
    
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Camera cameraRef;
    
    private float _cameraBottomHeight;
    

    private void Start()
    {
        _cameraBottomHeight = cameraRef.orthographicSize - cameraRef.transform.position.y;
        RandomX();
    }

    private void Update()
    {
        MoveDown();
        CheckForReset();
    }

    private void MoveDown()
    {
        speed += acceleration * Time.deltaTime;
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }

    private void CheckForReset()
    {
        if (transform.position.y < _cameraBottomHeight - resetOffset)
        {
            if (player.position.y > transform.position.y && !playerCollision.isDead)
            {
                scoreManager.AddScore();
            }

            Vector3 position = transform.position;
            position.y = resetY;
            transform.position = position;

            RandomX();
        }
    }

    private void RandomX()
    {
        transform.position = new Vector3(
            Random.Range(-1f, 1f),
            transform.position.y,
            transform.position.z
        );
    }
}