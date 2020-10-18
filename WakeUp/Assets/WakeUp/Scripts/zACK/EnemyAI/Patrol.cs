using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public bool movingRight = false;
    public bool detectWallCollision;
    public bool detectFloorCollision;
    public Transform groundDetection;
    public LayerMask groundLayerMask;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (detectWallCollision == true)
        {
            if (movingRight == true)
            {
                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 1f, groundLayerMask);
                if (groundInfo.collider == true)
                {

                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;

                }
            } else if (movingRight == false)
                {
                    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, 1f, groundLayerMask);
                    if (groundInfo.collider == true)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                }
        }
        if (detectFloorCollision == true)
        {
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, groundLayerMask);
            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
    }
}
