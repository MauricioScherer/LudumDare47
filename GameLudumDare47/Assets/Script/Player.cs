using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private bool isMove = true;
    private Vector3 velocity;

    public float speed;
    public float gravity = -9.81f;
    public float speedRotation;
    public Animator animPLayer;

    public GameObject cameraHead;
    public GameObject pressSpaceBtn;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(isMove)
        {
            //rotation player
            float rotX = Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime;
            transform.Rotate(Vector3.up * rotX);

            if(character.isGrounded)
            {
                float z = Input.GetAxis("Vertical");
                Vector3 move = transform.forward * z;
                character.Move(move * speed * Time.deltaTime);

                animPLayer.SetFloat("speed", z);
            }

            if (character.isGrounded && velocity.y < 0)            
                velocity.y = -2.0f;           

            velocity.y += gravity * Time.deltaTime;
            character.Move(velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Loop"))
        {
            GameManager.Instance.ResetPlayer();
        }

        if(other.CompareTag("Buttons"))
        {
            pressSpaceBtn.SetActive(true);
        }

        if (other.CompareTag("FinalLevel"))
        {
            GameManager.Instance.LoadLevel(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Buttons"))
        {
            pressSpaceBtn.SetActive(false);
        }
    }

    public void SetIsMove()
    {
        isMove = !isMove;
    }

    public void ActiveView(GameObject p_otherButtons)
    {
        cameraHead.SetActive(!cameraHead.activeSelf);
        SetIsMove();

        p_otherButtons.SetActive(!p_otherButtons.activeSelf);
    }
}
