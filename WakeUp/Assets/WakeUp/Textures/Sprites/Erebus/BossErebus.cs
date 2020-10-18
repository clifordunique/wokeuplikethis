using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossErebus : MonoBehaviour
{
    //public Variables
    public Transform trigger;
    public Animator anim;
    //public GameObject player;
    public float attackDistance;
    public int ErebusDmg;
    public float timer;
    public Transform attackPoints;


    //private

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            //Methods
            Debug.Log("asdfasdddddd");
            ErebusAttack();
        }
    }

    public void ErebusAttack()
    {
        //animation play
        //anim.SetTrigger("ErebusAttack");
        //other things
        //dmg
        //projectile
    }


}
