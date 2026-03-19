using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    
    private PlayerCollision _playerCollision;

    private Rigidbody2D _rb;
    
    private bool _isClicked;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerCollision = GetComponent<PlayerCollision>();
        
        if (_playerCollision == null)
            Debug.LogError("PlayerCollision component missing!");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _isClicked = true;
    }

    private void FixedUpdate()
    {
        if (!_isClicked || _playerCollision == null) 
            return;

        Vector2 velocity = _rb.linearVelocity;

        if (_playerCollision.isTouchedWallLeft)
        {
            velocity.x = speed;
            _playerCollision.isTouchedWallLeft = false;
        }
        else if (_playerCollision.isTouchedWallRight)
        {
            velocity.x = -speed;
            _playerCollision.isTouchedWallRight = false;
        }
        else
        {
            velocity.x = speed;
            _playerCollision.isTouchedWallRight = true;
        }

        _rb.linearVelocity = velocity;
        _isClicked = false;
    }
}