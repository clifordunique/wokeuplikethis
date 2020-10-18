using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Animator anim;

    [SerializeField] int maxHealth;
    int currentHealth;

    [SerializeField] float animationDeathTime;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);
    }


    public void TakeDmg(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        //Shake, Camera Effect

        anim.SetTrigger("Hurt");

        if (currentHealth <= 0) {
            StartCoroutine(DeathTime());
        }
    }


    public IEnumerator DeathTime()
    {
        //SOUND CLIP Insert
        Debug.Log("IENUMERATOOORRR");

        //Animation
        anim.SetBool("isDead", true);
        //asdfasdfasdfasdfasdf

        //rigiddBody
        yield return new WaitForSeconds(animationDeathTime);
        //Destroy Enemy
        Destroy(gameObject);
    }

}
