using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAgroPart : MonoBehaviour
{

    [SerializeField] Transform playerTrack;
    [SerializeField] float aggroRange;
    //[SerializeField] float attackRange;


    //DITO

    [SerializeField] float moveSpeedAggro;
    //[SerializeField] GameDatabase skeleton;

    

    public Animator skeletonAnim;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, playerTrack.position);
        //Debug.Log("LOL"+ distToPlayer);
        //For Console


        if (distToPlayer < aggroRange) {
            ChasePlayer();
        }
        else
        {
            StopMove();
        }
        //Will Attack
        



    }

    void ChasePlayer()
    {

   
        if (transform.position.x < playerTrack.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeedAggro, 0);
            transform.localScale = new Vector2(1, 1);

        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeedAggro, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        skeletonAnim.Play("skeleton_walk");
    }

    void StopMove() 
    {
        rb2d.velocity = Vector2.zero;
        skeletonAnim.Play("skeleton");
    }

    //dmg dealt

    /**
    void NearPlayer()
    {
        //For detection attack
        float distToPlayer = Vector2.Distance(transform.position, playerTrack.position);
        if(distToPlayer <= attackRange)
        {
            skeletonAnim.SetTrigger("skeleton_attack");

            Debug.Log("Near Player");
        }
        
    }
    **/

    /**public void dealDmg()
    {
        Debug.Log("DAAAAAAAMMMAAAAGGGGEEEE");

        skeletonAnim.Play("skeleton_attack");


    }**/


}
