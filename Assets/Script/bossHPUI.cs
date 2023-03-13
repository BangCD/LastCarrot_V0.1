using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class bossHPUI : MonoBehaviour
{
    public GameObject bossNameOBJ;
    public TMP_Text bossName;
    Slider Slider;

    private void Awake()
    {
        Slider=GetComponentInChildren<Slider>();
        //bossName=GetComponentInChildren<Text>();
        bossNameOBJ=gameObject.transform.GetChild(1).gameObject;
        Debug.Log(bossNameOBJ.name);
        bossName = bossNameOBJ.GetComponent<TMP_Text>();
    }


    public void SetBossName(string name)
    {
        bossName.text = name;
    }

    public void SetBossUIActive()
    {
        Slider.gameObject.SetActive(true);
        bossName.gameObject.SetActive(true);

    }

    public void SetBossUIFalse()
    {
        Slider.gameObject.SetActive(false);
        bossName.gameObject.SetActive(false);

    }

    public void bossMaxHP(float maxHP)
    {
        Slider.maxValue= maxHP;
        Slider.value= maxHP;
    }

    public void bossCurrentHP(float BOSScurrentHP)
    {
        Slider.value= BOSScurrentHP;
    }
 


    // Start is called before the first frame update
    void Start()
    {
       Slider.gameObject.SetActive(false);
       bossName.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
