using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    //public enum RotationAxis {
    //    MouseX =1, MouseY=2
    //}
    //public RotationAxis axes = RotationAxis.MouseX;

    public float minVertAngle = -89f;
    public float maxVertAngle = 89f;
    public float sensVertical = 10f;

    private float rotationX = 0;

    // Update is called once per frame
    void Update()
    {
        //if (axes == RotationAxis.MouseX) {
        //    transform.Rotate(0f, Input.GetAxis("Mouse X")*sensHorizontal ,0f );
        //}
        //else {
        //}
            rotationX -=Input.GetAxis("Mouse Y")*sensVertical;
            rotationX = Mathf.Clamp(rotationX, minVertAngle, maxVertAngle);

            transform.localEulerAngles= new Vector3(rotationX, 0f , 0f);

    }

}
