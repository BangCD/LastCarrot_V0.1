using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class camFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Transform camPosition ;
    public Vector3 offset;

    private void Awake()
    {
        camPosition = GetComponent<Transform>();
        //camPosition.position= transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z);
    }
}
