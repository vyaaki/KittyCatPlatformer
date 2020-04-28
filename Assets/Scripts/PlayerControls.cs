using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float speed = 20.0f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * speed * moveX * Time.deltaTime);
    }
}
