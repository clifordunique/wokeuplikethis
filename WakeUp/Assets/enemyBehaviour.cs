using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float speed;
    public bool movingRight;
    //spublic Animator enemyAnim;

    //public Transform[] pointLimit;

    /// <summary>
    ///I change the idle to a alk anim.. no idle na
    /// </summary>


    public bool detectWallCollision;
    public bool detectFloorCollision;
    public Transform groundDetection;
    public LayerMask groundLayerMask;
    public int enemyDmg;


    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (detectWallCollision == true)
        {
            if (movingRight == false)
            {
                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, 1f, groundLayerMask);
                if (groundInfo.collider == true)
                {

                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;

                }
            }
            else if (movingRight == true)
            {
                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 1f, groundLayerMask);
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
                if (movingRight == false)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
            }
        }





        /**
        if (moveRight)
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1,1);
            
        }
        else {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1,1);

        }**/
    }


    /// <summary>
    /// not orrking 
    /// </summary>
 
/**
    private void OnTriggerEnter2D(Collider2D trig)
    {
        
        if (trig.gameObject.CompareTag("Limit")) { 
            if (moveRight)
            {
                moveRight = true;
            }
            else {
                moveRight = false;
            }
        } 

    }

**/
}
