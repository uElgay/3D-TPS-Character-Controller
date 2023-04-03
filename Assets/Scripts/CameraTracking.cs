using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float controlX;
    private float controlY;

    public Transform character;
    public Vector3 offset;
    void Start()
    {
        
    }
    void Update()
    {
        if(controlX != Input.GetAxis("Mouse X") || controlY != Input.GetAxis("Mouse Y")){
            character.Rotate(0,yaw * 3 * Time.deltaTime,0);
        }
        transform.position = character.position + offset;
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch,yaw,0.0f);
        controlX = Input.GetAxis("Mouse X");
        controlY = Input.GetAxis("Mouse Y");
    }
}
