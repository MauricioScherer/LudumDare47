using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisTargetCamera : MonoBehaviour
{
    public Transform target;
    public float speedMove;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speedMove * Time.deltaTime);
    }

    public void RotateRight()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90.0f, transform.eulerAngles.z);
    }

    public void RotateLeft()
    {
        print("teste");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 90.0f, transform.eulerAngles.z);
    }
}
