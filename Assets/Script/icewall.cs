using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icewall : MonoBehaviour
{
    [SerializeField] private GameObject iceWall;
    [SerializeField] private GameObject placepoint;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            var iceWallInstance=Instantiate(iceWall,placepoint.transform.position,placepoint.transform.rotation);
        }
    }
}
