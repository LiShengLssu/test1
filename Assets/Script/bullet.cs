using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float liveTime = 3;
    public int m_ihurt=2;
    public Collider m_bulletCollider;
    //public float speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        liveTime -= Time.deltaTime;
        if(liveTime<0)
        {
            Destroy(gameObject);
        }





        /*Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        liveTime -= Time.deltaTime;
        if(liveTime<0)
        {
            Destroy(gameObject);
        }
        */
    }
}
