using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //Variable

    Rigidbody2D rb2d;
    //MALI TONG MGA TO
    /**
    public float speed;
   // public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
        
        if(player.transform.localScale.x < 1) {
            Debug.Log("LOL1");
            speed = -speed;
        }else
        {
            FlipFire();
        }

       
    }
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
    //Pagpapatuloy 

    void FlipFire()
    {
        Debug.Log("asdasdadasda");
        Vector3 scale = transform.localScale;
        speed = speed;
        scale.x = -1;

    }**/


    //Method

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Destroyer", .5f);
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(10,0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroyer();
    }

    private void Destroyer()
    {
        Destroy(gameObject);
    }
}
