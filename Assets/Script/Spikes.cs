using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    [SerializeField] private int damageDone;
    private Rigidbody2D playerRB;
    private PlayerHealth PlayerHealth;
    [SerializeField] private float onHitJump;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Spikes Collided");
            PlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            PlayerHealth.TakeDmg(damageDone);
            if (!PlayerHealth.dead)
            {
                playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRB.velocity = new Vector2(playerRB.velocity.y, onHitJump);
            }


        }
    }

    //private void OnTriggerEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag=="Player")
    //    {
    //        Debug.Log("Spikes Collided");
    //        PlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
    //        PlayerHealth.TakeDmg(damageDone);
    //        if (!PlayerHealth.dead)
    //        {
    //            playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
    //            playerRB.velocity = new Vector2(playerRB.velocity.y, 15);
    //        }


    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
