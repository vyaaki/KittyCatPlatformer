using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform groundDetector;
    public float speed = 5f;
    private bool movingRight = true;
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundRaycastHit = Physics2D.Raycast(groundDetector.position, Vector2.down);
        if (!groundRaycastHit.collider)
        {
            transform.Rotate(new Vector2(0, -180));
        }
    }


}
