using UnityEngine;

public class MoveWallsDown : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float resetY = 6f;
    [SerializeField] private float resetOffset = 2f;
    [SerializeField] private Camera cameraRef;

    private float _cameraBottomHeight;

    private void Start()
    {
        _cameraBottomHeight = cameraRef.orthographicSize - cameraRef.transform.position.y;
    }

    private void Update()
    {
        MoveDown();
        CheckForReset();
    }

    private void MoveDown()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }

    private void CheckForReset()
    {
        if (transform.position.y < _cameraBottomHeight - resetOffset)
        {
            Vector3 position = transform.position;
            position.y = resetY;
            transform.position = position;
        }
    }
}