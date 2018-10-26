using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
      [SerializeField] GameObject target;
 
    [Header("Speed")]
    [SerializeField] float moveSpeed = 300f;
    [SerializeField] float zoomSpeed = 100f;
 
    [Header("Zoom")]
    [SerializeField] float minDistance = 2f;
    [SerializeField] float maxDistance = 5f;
 
    void Update ()
    {
        CameraControl();
    }
 
    void CameraControl()
    {
        if (Input.GetMouseButton(0))
        {
            /* Rotate the camera using the input managers mouse axis */
            transform.RotateAround(target.transform.position, Vector3.up, ((Input.GetAxisRaw("Mouse X") * Time.deltaTime) * moveSpeed));
            transform.RotateAround(target.transform.position, transform.right, -((Input.GetAxisRaw("Mouse Y") * Time.deltaTime) * moveSpeed));
        }
 
        /* Zoom the camera */
        ZoomCamera();
    }
 
    void ZoomCamera()
    {
        /* If we are already close enough for the min distance and we try to zoom in, dont, return instead */
        /* Similarly for zooming out */
        if (Vector3.Distance(transform.position, target.transform.position) <= minDistance && Input.GetAxis("Mouse ScrollWheel") > 0f) { return; }
        if (Vector3.Distance(transform.position, target.transform.position) >= maxDistance && Input.GetAxis("Mouse ScrollWheel") < 0f) { return; }
 
        /* Only move in the Z relative to the Camera (so forward and back) */
        transform.Translate(
            0f,
            0f,
            (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomSpeed,
            Space.Self
        );
    }  
}