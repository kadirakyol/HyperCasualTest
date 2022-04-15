using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float limitX;
    public float runningSpeed;
    public float xSpeed;
    private float _currentRunningSpeed;
    void Start()
    {
        _currentRunningSpeed = runningSpeed;
    }

    void Update()
    {
        float newX = 0f;
        float touchXDelta = 0f;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);
        
        
        Vector3 newPosition = new Vector3(newX,transform.position.y, transform.position.z +
            _currentRunningSpeed * Time.deltaTime);
        transform.position = newPosition;

    }
}
