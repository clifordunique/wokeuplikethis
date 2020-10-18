using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ske_behaviour : MonoBehaviour
{
    #region Public Variables
    [SerializeField] Transform rayCast;
    [SerializeField] LayerMask rayCastMask;
    [SerializeField] float rayCastLength;
    [SerializeField] float attackDistance;
    [SerializeField] float moveSpeed;
    [SerializeField] float timer;
    //public Collider2D HitBox;
    public Transform leftLimit;
    public Transform rightLimit;
    //public GameObject Player;



    //[SerializeField] float skeletonTime;

    //public 
    public Animator anim;
    public int SkeletonDmg;

    /**
    public HealthBar ske_healthBar;
    public int skeletonMaxHealth; //Health
    int skeletonCurrentHealth; //current**/
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    //private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    private void Start()
    {
        /**skeletonCurrentHealth = skeletonMaxHealth;
        ske_healthBar.SetMaxHealth(skeletonCurrentHealth);**/
    }

    private void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(!attackMode)
        {
            Move();
        }
        //asdfasdfasdfasdfasdf
        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("ske_attack")) {
            SelectTarget();
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, rayCastMask);
            RaycastDebugger();
        }

        //when detected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            //anim.SetBool("canWalk", false);
                StopAttack();
        }


    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player") {
            target = trig.transform;
            inRange = true;
            Flip();
            
            //DamageAttack();
        }

    }

   
    //LOGIC

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("attack", false);

        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("ske_attack")) //Only Skeleton
        {
            Vector2 targetPosition = new Vector2(target.position.x, target.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed  * Time.deltaTime);

        }
    }
    /*****************************  ATTTTAAACCKkKK  ***********************************/
    void Attack()
    {
        timer = intTimer; //Timer
        attackMode = true; //

        anim.SetBool("canWalk", false);
        anim.SetBool("attack", true);
        //DamageAttack();
    }

    /**void DamageAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(HitBox.position, attackDistance, rayCastMask);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit" + enemy.name);

            enemy.GetComponent<PlayerCombat>().PlayerHealth(SkeletonDmg);
        }
        if (HitBox.isTrigger)
        {
            //HitBox.GetComponent<PlayerCombat>().PlayerHealth(SkeletonDmg);
            //Player.GetComponent<PlayerCombat>().PlayerHealth(SkeletonDmg);
            Debug.Log("What hitbox");
            

        } else if (!HitBox.isTrigger) {
            Player.GetComponent<PlayerCombat>().PlayerHealth(+1);
        }

    }**/


        /***************************** ENNDDD ATTTACCK  *******************************/

        void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("attack", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance) {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        } 
        else
        {
            target = rightLimit;
        }


        Flip();
    }

    private void Flip() {
        Vector3 rotation = transform.eulerAngles;

        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }
    
    //TAKING DMG
    /**
    public void DmgTake(int dmg)
    {
        skeletonCurrentHealth -= dmg;
        ske_healthBar.SetHealth(skeletonCurrentHealth);


        Debug.Log("Nababawasan");
        //Shake, Camera Effect

        anim.SetTrigger("skeHurt");

        if (skeletonCurrentHealth <= 0)
        {
            StartCoroutine(SkeletonDeath());
        }
    }

    public IEnumerator SkeletonDeath()
    {
        //animator.SetBool("Death", true);
        Debug.Log("DEADSSS");
        yield return new WaitForSeconds(skeletonTime);
        //Destroy Enemy
        Destroy(gameObject);
    }
    **/
}
