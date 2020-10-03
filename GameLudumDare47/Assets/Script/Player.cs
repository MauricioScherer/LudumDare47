using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xRotation = 0.0f;
    private CharacterController character;
    private bool isMove = true;

    [Header("Head")]
    public Transform head;
    public float mouseSensibility;

    [Header("Body")]
    public float speed;

    public float gravity = -9.81f;
    private Vector3 velocity;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(isMove)
        {
            #region MouseRotation
            float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            head.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
            transform.Rotate(Vector3.up * mouseX);
            #endregion

            #region InputAxis
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            character.Move(move * speed * Time.deltaTime);
            #endregion

            if (character.isGrounded && velocity.y < 0)
            {
                velocity.y = -2.0f;
            }

            velocity.y += gravity * Time.deltaTime;
            character.Move(velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Loop"))
        {
            isMove = false;
            GameManager.Instance.ResetPlayer();
        }
    }

    public void SetIsMove()
    {
        isMove = !isMove;
    }
}
