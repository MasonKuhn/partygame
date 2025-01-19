using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float stepSize = 2.5f;
    public float moveDelay = 0.25f;

    private float lastMoveTime = 0f;

    public bool canMove = true;

    void Update()
    {
        if (canMove)
        {
            if (Time.time - lastMoveTime >= moveDelay)

                if (Input.GetKeyDown(KeyCode.W))
                {
                    Move(Vector2.up);
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    Move(Vector2.down);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    Move(Vector2.left);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    Move(Vector2.right);
                }
        }

    }
    void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction * stepSize;
        lastMoveTime = Time.time;
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void StartMovement()
    {
        canMove = true;
    }
}