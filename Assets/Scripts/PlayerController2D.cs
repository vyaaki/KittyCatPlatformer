using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 20.0f;
    public CharacterController2D controller;
    float moveX = 0f;
    bool jump = false;
    void Start()
    {

    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(moveX, false, jump);
        jump = false;
    }

}
