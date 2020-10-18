using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ske_Combat : MonoBehaviour
{
    #region
    public int skeDmg;
    public float skeHealth;
    public Transform hitbox2;
    public LayerMask playerLayer;
    [SerializeField] private Collider2D hitbox;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" ) {
            Debug.Log("HOOYYYYY Nakatamaa");
            AttackDamage();
        }
    }**/


    //To fix
    public void AttackDamage()
    {

        Debug.Log("Attack BTN");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitbox2.position, playerLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit" + enemy.name);

            //enemy.GetComponent<PlayerCombat>().PlayerHealth(skeDmg);
        }


    }

    /**
     * 
     *         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit" + enemy.name);

            enemy.GetComponent<EnemyCombat>().TakeDmg(swordDmg);
        }
     * **/
}
