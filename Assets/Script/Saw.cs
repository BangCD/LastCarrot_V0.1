using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private int damageDone;
    private PlayerHealth PlayerHealth;
    private Rigidbody2D playerRB;
    [SerializeField]private float onHitJump;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Touched Saw");
            PlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            PlayerHealth.TakeDmg(damageDone);

            //StartCoroutine(iframes());

            if (!PlayerHealth.dead)
            {
                playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRB.velocity = new Vector2(playerRB.velocity.y, onHitJump);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
