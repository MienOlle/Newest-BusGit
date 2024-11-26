using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    float rotateInput;
    float yRotate;
    public float rotationSpeed = 100f;
    public float minXRotation = -16f;
    public float maxXRotation = 22f;

    // Fixed update to mess with physics
    void Update()
    {
        rotateInput = Input.GetAxis("Horizontal");
        yRotate = rotateInput * rotationSpeed * Time.deltaTime;

        transform.Rotate(0, yRotate, 0);

        Vector3 currentRotation = transform.localEulerAngles;

        // if(Input.GetKey("q") && currentRotation.x < maxXRotation){
        //     transform.Rotate(20f * Time.deltaTime, 0, 0);
        // }else if(Input.GetKey("e") && currentRotation.x > minXRotation){
        //     transform.Rotate(-20f * Time.deltaTime, 0, 0);
        // }

        if(currentRotation.x > 180){
            currentRotation.x -= 360;
        }

        if(Input.GetKey("q") && currentRotation.x < maxXRotation){
            currentRotation.x += 20f * Time.deltaTime;
        }else if(Input.GetKey("e") && currentRotation.x > minXRotation){
            currentRotation.x -= 20f * Time.deltaTime;
        }

        float clampedX = Mathf.Clamp(currentRotation.x, minXRotation, maxXRotation);
        transform.localEulerAngles = new Vector3(clampedX, currentRotation.y, 0f);
    }
}
