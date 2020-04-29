using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private float speed = 20.0f;
    CharacterController controller;
    void Start()
    {

    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed ;
    }

    private void FixedUpdate()
    {
    }

}
