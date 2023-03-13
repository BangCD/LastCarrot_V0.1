using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

   
    [SerializeField] private Image[] Hearts;
    private float playerHP;
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerHealth>().OnHealthChanged += HandleHealthChanged;
        }
        
        playerHP=player.GetComponent<PlayerHealth>().currentHP;
    }

    private void HandleHealthChanged(float hp)
    {
        //StartCoroutine(changehp(hp));
        //Foregroundimage.fillAmount=hp;
        Debug.Log("Hp Value "+hp);
        Debug.Log("Fill amount changed ");

        for(int i=0;i<Hearts.Length;i++) 
        {
            if(i< hp)
            {
                Hearts[i].fillAmount = 1;
                Debug.Log("Fill amount changed  1 ");
            }
            else
            {
                Hearts[i].fillAmount=0;
                Debug.Log("Fill amount changed  2 ");
            }
            
        }

    }


    //private IEnumerator changehp(float hp)
    //{

    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
