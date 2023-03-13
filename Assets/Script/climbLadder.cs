using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbLadder : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    [SerializeField] private float upSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {

            if (Input.GetKey(KeyCode.W))
            {
                Rigidbody2D.velocity = new Vector2(0, upSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Rigidbody2D.velocity = new Vector2(0, -upSpeed);
            }
            else
            {
                Rigidbody2D.velocity = new Vector2(0, 0);
            }
        }
    }
}
