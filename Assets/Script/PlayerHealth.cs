using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float baseHP;
    [SerializeField]  private float iframe;
    private float NextFrame;
    //{
    //    get;
    //    [SerializeField] private set;
    //}
    public float currentHP 
    { 
        get; 
        private set; 
    }
    private Animator anim;
    public bool dead
    {
        get;
        private set ;
    }


    public event Action<float> OnHealthChanged = delegate { };
    private camShake camShake;


    private void Awake()
    {
        currentHP = baseHP;
        dead= false;
        anim = GetComponentInChildren<Animator>();
        camShake=Camera.main.GetComponent<camShake>();
    }

    public void TakeDmg(float damage)
    {
        if(Time.time > NextFrame)
        {
            NextFrame = Time.time+iframe;
            currentHP = Mathf.Clamp(currentHP - damage, 0, baseHP);

        }
        //currentHP = Mathf.Clamp(currentHP - damage, 0, baseHP);
        //camShake.Shake();
        if (currentHP > 0)
        {
            anim.SetTrigger("hurt");
            Debug.Log("Took dmg");
        }

        if(currentHP<=0)
        {
            if(!dead)
            {
                Debug.Log("dead ?? ");
                anim.SetTrigger("dying");
                GetComponent<snowmanMovement>().enabled = false;
                GetComponent<throwSnowball>().enabled = false;
                dead = true;
            }
        }
        OnHealthChanged(currentHP);
        Debug.Log("OnhealthChanged called ");
    }

    public void addHP(float amount)
    {
        currentHP=Mathf.Clamp(currentHP+amount, 0, baseHP);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDmg(1);
            Debug.Log("H pressed");
        }
    }
}
