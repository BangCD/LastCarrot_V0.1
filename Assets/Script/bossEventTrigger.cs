using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEventTrigger : MonoBehaviour
{
    bossHPUI bossHPUI;
    [SerializeField] GameObject currentBoss;


    public void Start()
    {
        bossHPUI = currentBoss.GetComponentInChildren<bossHPUI>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bossHPUI.SetBossUIActive();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bossHPUI.SetBossUIFalse();
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
