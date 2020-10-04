using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float speedMove;
    public float speedRotation;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speedMove * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speedRotation * Time.deltaTime);
    }
}
