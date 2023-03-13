using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private float enemybaseHP;

    public float enemycurrentHP
    {
        get;
        private set;
    }
    private Animator anim;
    public bool dead
    {
        get;
        private set;
    }

    //[SerializeField] private bool isBoss;
    public bool isBoss;

    [SerializeField] private float snowballDmg;


    bossManager bossManager;


    snowballSelfDestruct snowballSelfDestruct;

    private void Awake()
    {
        enemycurrentHP = enemybaseHP;
        dead= false;
        anim = GetComponentInChildren<Animator>();
        if (isBoss)
        {
            Debug.Log("inside isBoss");
            bossManager = GetComponent<bossManager>();
            enemycurrentHP = bossManager.BossMaxHP;
            enemybaseHP= bossManager.BossMaxHP;
        }
    }

    public event Action<float> OnBossHPchange = delegate { };

    public void enemyTakeDmg(float damage)
    {
        Debug.Log("Enemey Current HP " + enemycurrentHP);
        enemycurrentHP = Mathf.Clamp(enemycurrentHP - damage, 0, enemybaseHP);

        if (enemycurrentHP > 0)
        {
            anim.SetTrigger("Enemyhurt");
            Debug.Log("Took dmg");
        }


        if (enemycurrentHP <= 0)
        {
            if (!dead)
            {
                Debug.Log(" dead?? ");
                anim.SetTrigger("EnemyDead");
                gameObject.layer = 8;
                dead = true;
            }
        }
        OnBossHPchange(enemycurrentHP);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Snowball hit22");

        if (collision.gameObject.tag == "snowball")
        {
            Debug.Log("Snowball hit");
            enemyTakeDmg(snowballDmg);
            collision.gameObject.GetComponent<snowballSelfDestruct>().instantDestroy();



        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            enemyTakeDmg(1);
            Debug.Log("O pressed");

        }
    }
}
