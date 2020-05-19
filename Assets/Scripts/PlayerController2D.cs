using UnityConstants;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public CharacterController2D controller;
    private bool jump;
    private float moveX;
    public float speed = 20.0f;

    private void Awake()
    {
        if (PlayerCustomization.usedAnimatorController)
        {
            var usedAnimationParameters = gameObject.GetComponent<Animator>();
            usedAnimationParameters.runtimeAnimatorController = PlayerCustomization.usedAnimatorController;
        }
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButtonDown("Jump")) jump = true;
    }

    private void FixedUpdate()
    {
        controller.Move(moveX, false, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.Enemies) || other.gameObject.CompareTag(Tags.DieZone))
        {
            GameOverMenu.Instance.showGameOverMenu();
            Destroy(gameObject);
        }
    }
}