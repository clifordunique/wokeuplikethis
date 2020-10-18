using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCombat : MonoBehaviour
{
    /***************************Code for making the skeleton attack **************************/

    //making a hitbox
    //doing dmg to the player
    [SerializeField] public Animator anim;
    [SerializeField] public Transform skeletonAttackPoint;

    [SerializeField] public float skeletonAttackRange = 0.5f;
    [SerializeField] public int skeletonDmg;

    public bool playerDetected = true;
    public LayerMask playerLayerMask;



    



    public void Update()
    {
        //RaycastHit2D skeletonDetect = Physics2D.Raycast(skeletonAttackPoint.position, Vector2.down, 1f, playerLayerMask);
        /**Collider2D[] skeletonDetect = Physics2D.OverlapCircleAll(skeletonAttackPoint.position, skeletonAttackRange, playerLayerMask);

        if (skeletonDetect.collider == true)
        {
            //anim.Play("skeleton_attack");
            Debug.Log("YOOOOO");
            DamagePlayer();
        }**/

        //DamagePlayer();

 

    }

    private void OnDrawGizmosSelected()
    {
        if (skeletonAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(skeletonAttackPoint.position, skeletonAttackRange);
    }

    //putting dmg
    public void DamagePlayer()
    {
        Collider2D[] playerDetector = Physics2D.OverlapCircleAll(skeletonAttackPoint.position, skeletonAttackRange, playerLayerMask);
        //RaycastHit2D playerDetect = Physics2D.Raycast(skeletonAttackPoint.position, Vector2.down, 1f, playerLayerMask);
        
            foreach (Collider2D enemy in playerDetector)
            {
                Debug.Log("Enemy Hit");
                anim.SetTrigger("skeleton_attack");
                //enemy.GetComponent<PlayerCombat>().PlayerHealth(skeletonDmg);
            }

        /**foreach(playerDetect == playerDetected)
        {
            Debug.Log("GGGGGGGG");

            enemy.GetComponent<PlayerCombat>().PlayerHealth(skeletonDmg);

        }**/


    }
}
