using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public Transform LookAt;
    public Transform player;
    public float distance = 50.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    Vector3 offset;
    [SerializeField] private float sensitivity = 10f;


    private void Start()
    {
        offset = this.transform.position - player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
        this.transform.LookAt(new Vector2(currentX, currentY) * sensitivity);

        //this.transform.position = player.transform.position + offset;
        this.transform.position = player.position + rotation * offset;

        this.transform.LookAt(player.position);
    }

    /*private void LateUpdate()
    {
        Vector3 dir = new Vector3(0f, 0f, -distance);
        Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
        camTransform.position = LookAt.position + rotation * dir;

        camTransform.LookAt(LookAt.position);
    }*/

    /*void CamRotation()
    {
        
        Vector3 _rotation = new Vector3(0, -currentY, 0) * sensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_rotation));

        Vector3 CamRotation = new Vector3(currentX, 0, 0) * sensitivity;
        cam.transform.Rotate(CamRotation);
    }*/
}
