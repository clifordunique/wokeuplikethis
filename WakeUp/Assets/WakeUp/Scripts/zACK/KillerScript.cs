using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerScript : MonoBehaviour
{

    public int killer;

    public void OnCollisionEnter2D(Collision2D colInfo)
    {

        //Collider2D[] playerDetector = Physics2D.OverlapCircleAll(skeletonAttackPoint.position, skeletonAttackRange, playerLayerMask);
        PlayerCombat player = colInfo.collider.GetComponent<PlayerCombat>();

        if (player != null) 
        {
            //player.PlayerHealth(killer);
        }
    }
}



