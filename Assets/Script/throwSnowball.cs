using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwSnowball : MonoBehaviour
{
     private Animator animator;
    [SerializeField] private GameObject snowball;
    public float pwr = 150f;
    [SerializeField] private GameObject launchPoint;
    [SerializeField] private float TimeToLive;
    private Rigidbody2D snowballrb;

    private Rigidbody2D instance;


    [SerializeField]private float FireRate = 1.0f;
    private float NextFire;

    
    private void Awake()
    {
        animator=GetComponentInChildren<Animator>();
    }



    // Start is called before the first frame update
    void Start()
    {

        snowballrb = snowball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            animator.SetTrigger("snowballThrow");
            var instance = Instantiate(snowballrb, launchPoint.transform.position, launchPoint.transform.rotation)as Rigidbody2D;
            instance.AddRelativeForce(launchPoint.transform.right * pwr);

       


            Destroy(instance, 5);

        }
      

    }
}
