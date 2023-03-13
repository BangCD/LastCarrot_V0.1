using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class snowmanMovement : MonoBehaviour
{

    public Animator animator;

    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float speed = 10f;
    private Rigidbody2D Rigidbody2D;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded;
    private bool FacingRight = true;
    public UnityEvent OnLandEvent;


    private bool jump=false;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

    }

    void Start()
    {

    }




    private void Flip()
    {
        FacingRight = !FacingRight;

        transform.Rotate(0, 180f, 0);
    }




    // Update is called once per frame
    void FixedUpdate()
    {

        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        animator.SetBool("Grounded", m_Grounded);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                animator.SetBool("Grounded", m_Grounded);
                //Debug.Log("Grounded by default : " + m_Grounded);
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }


        //Move forward and back
        if (horizontalInput > 0 && !FacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && FacingRight)
        {
            Flip();
        }
        //Debug.Log("Horizontal Input " + horizontalInput);
        
        Rigidbody2D.velocity = new Vector2(horizontalInput * 10f, Rigidbody2D.velocity.y);  //Makes character move based on input
        

        //jump
        if (m_Grounded && jump == true)
        {


            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.y, jumpStrength);

            jump = false;
            m_Grounded = false;
            animator.SetBool("jumpStart", jump);
            animator.SetBool("Grounded", m_Grounded);
            //Debug.Log("Grounded after jump : "+ m_Grounded);
        }
       

    }


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jump is pressed");
            
            jump = true;
            animator.SetBool("jumpStart", jump);
        }


        
        


    }

}
