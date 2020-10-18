using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayerCombat : MonoBehaviour
{
    /**private float timeBtwAttack;
    private float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatisEnemies;
    public float attackRange;
    public int damage;**/


    //Sound

    public AudioManager audio;
    public Animator animator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;
    public float playerDeathAnimTime;
    public Vector3 respawn;

    //DMG POINT

    public int swordDmg = 40;

    //attack
    public float attackRate = 4f;
    float nextAttackTime = 0f;

    //Health
    [SerializeField] private int CurrentMaryHealth;
    public int MaxHealth;
    public HealthBar healthbar;


    //To dmg enemy
    //detect

    //Spell cast naaaa
    //public Transform firePoint;
    //public GameObject fireBall;

    public GameObject projectile;
    public Vector2 velocity;
    public Vector2 offset = new Vector2(0.4f,0.1f);


    //Combo na dis

    public int noOfClick = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.9f;



    private void Start()
    {
       //Projectile
       

        CurrentMaryHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        //All about Combo
        animator = gameObject.GetComponent<Animator>();


    }

    /**
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Monster") {
            Debug.Log("DMG FROM ENEMY");
        }
    }
    **/

    void Update()
    {


        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                nextAttackTime = Time.time * 3f / attackRate;

            }
            if (Input.GetKeyDown(KeyCode.J)) {
                Cast();
            }
        }


        //Combo pt2
        if(Time.time - lastClickedTime > maxComboDelay) { noOfClick = 0; }


    }


    public void Attack() {
        //attack animation
        //animator.SetTrigger("Attack");
        lastClickedTime = Time.time;
        noOfClick++;
        if (noOfClick == 1)
        {
            animator.SetBool("Attack1", true);
            audio.Play("SwordOne");
        }
        noOfClick = Mathf.Clamp(noOfClick, 0,3);

    }

    //COMBOOO NAAA
    public void return1()
    {
        if(noOfClick >=2)
        {
            animator.SetBool("Attack2", true);
            audio.Play("SwordTwo");
        }
        else
        {
            animator.SetBool("Attack1", false);
            noOfClick = 0;
        }
    }

    public void return2()
    {
        if (noOfClick >= 3)
        {
            animator.SetBool("Attack3", true);
            audio.Play("SwordThree");

        }
        else
        {
            animator.SetBool("Attack2", false);
            noOfClick = 0;
        }
    }

    public void return3()
    {
        animator.SetBool("Attack1", false);
        animator.SetBool("Attack2", false);
        animator.SetBool("Attack3", false);
        noOfClick = 0;

    }



    //cast
    //spell attack

    public void Cast()
    {
        
        animator.SetTrigger("Spell");
        /**GameObject go = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y );**/

        GameObject go = (GameObject)Instantiate(projectile);
        go.transform.position = new Vector3(transform.position.x + .4f, transform.position.y+ .2f, -1);
    }


    //Gizmo
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void AttackDamage() {

        Debug.Log("Attack BTN");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("Enemy Hit" + enemy.name);
            
            enemy.GetComponentInParent<EnemyCombat>().TakeDmg(swordDmg);
            //.GetComponent<ske_behaviour>().DmgTake(swordDmg);
            
        
               /**if (gameObject.tag == "Enemy")
            {
                enemy.GetComponent<EnemyCombat>().TakeDmg(swordDmg);
            } else if(gameObject.tag == "Skeleton")
            {
                enemy.GetComponent<ske_behaviour>().DmgTake(swordDmg);
            }**/

        }




    }

    //Taking DMG
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "EnemyDamage") {
            ske_behaviour skeleton = other.gameObject.GetComponentInParent<ske_behaviour>();
            CurrentMaryHealth -= skeleton.SkeletonDmg;
            DamageInEnemy();

        } 
        //PAPALITAN NG COLLISION HINDI NA ONTRIGGER
        /**if(other.gameObject.tag == "Enemy")
        {
            enemyBehaviour enemy = other.gameObject.GetComponent<enemyBehaviour>();
            CurrentMaryHealth -= enemy.enemyDmg;
        }**/

    }
    public void DamageInEnemy()
    {

        //anim
        animator.SetTrigger("Hurt");
        //Shake, Camera Effect

        //Audio
        audio.Play("PlayerHurt");

        healthbar.SetHealth(CurrentMaryHealth);

        if (CurrentMaryHealth <= 0)
        {

            StartCoroutine(PlayerDeathTime());
        }
    }

    public IEnumerator PlayerDeathTime()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        animator.SetBool("Death", true);
        Debug.Log("DEADSSS");

        //respawner//
        yield return new WaitForSeconds(playerDeathAnimTime);
        //Destroy Enemy
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
