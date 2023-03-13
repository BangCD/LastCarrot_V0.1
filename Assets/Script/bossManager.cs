using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class bossManager : MonoBehaviour
{
    bossHPUI UIbossHP;
    public string bossName;

    //[SerializeField] private float BossMaxHP;
    public float BossMaxHP;
    enemyHealth EnemyHealth;

    private void Awake()
    {
        UIbossHP = FindObjectOfType<bossHPUI>();
        EnemyHealth=GetComponent<enemyHealth>();

        if (EnemyHealth.isBoss)
        {
            EnemyHealth.OnBossHPchange += BossHPupdate;
        }

    }

  

    public void BossHPupdate(float currentHP)
    {
        Debug.Log("Boss Hp Value " + currentHP);
        UIbossHP.bossCurrentHP(currentHP);
    }


    // Start is called before the first frame update
    void Start()
    {
        UIbossHP.SetBossName(bossName);
        UIbossHP.bossMaxHP(BossMaxHP);
        UIbossHP.bossCurrentHP(BossMaxHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void takeDmg(int damage)
    //{
    //    BossHPupdate(damage);

    //}

}
