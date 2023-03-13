using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camShake : MonoBehaviour
{
    [SerializeField] private float magnitude;
    [SerializeField] private float duration;
    private Vector3 camOriginalPos;

    //public IEnumerator Shanke()
    //{
    //    float magnitude = magnitude1;
    //    float duration = duration1;

    //    Debug.Log("Magnitude = " + magnitude);
    //    Debug.Log("duration = " + duration);



    //    Vector2 orignalPos = transform.localPosition;

    //    float elapsedTime = 0f;

    //    while (elapsedTime < duration)
    //    {
    //        float Xoffset=Random.Range(-0.5f, 0.5f)*magnitude;
    //        float Yoffset = Random.Range(-0.5f, 0.5f) * magnitude;

    //        transform.localPosition=new Vector2(Xoffset, Yoffset);

    //        elapsedTime += Time.deltaTime;

    //        yield return null;

    //    }
    //    transform.localPosition = orignalPos;

    //}

    public void Shake()
    {
        Debug.Log("Shake called");
        camOriginalPos =transform.position;
        InvokeRepeating("StartShaking", 0f, 0.005f);
        Invoke("StopShaking", duration);

    }

    void StartShaking()
    {
        //GetComponent<camFollowPlayer>().enabled= false;
        Debug.Log("First Invoke called");
        float Xoffset = Random.value*  magnitude* 2 - magnitude;
        float Yoffset = Random.value * magnitude * 2 - magnitude;

        Vector3 camCurrentPosition= transform.position;
        camCurrentPosition.x += Xoffset;
        camCurrentPosition.y += Yoffset;
        transform.position = camCurrentPosition;


    }

    void StopShaking()
    {
        //GetComponent<camFollowPlayer>().enabled = true;

        CancelInvoke("StartShaking");
        transform.position = camOriginalPos;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) 
        {
            Shake();
            Debug.Log("K pressed");
        }
    }
}
