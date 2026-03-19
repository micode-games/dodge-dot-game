using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    private Camera _camera;
    
    void Start()
    {
        float targetAspect = 9f / 16f;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        
        _camera = GetComponent<Camera>();

        if (scaleHeight < 1f)
        {
            _camera.rect = new Rect(0f, (1.0f - scaleHeight) / 2.0f , 1f, scaleHeight);
        }
        else 
        {
            float scaleWidth = 1.0f / scaleHeight;
 
            _camera.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }
}
