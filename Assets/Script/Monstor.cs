using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstor : MonoBehaviour
{
    public GameObject bom;
    public int m_ihp = 10;
    [SerializeField] private GameObject m_prefebMbullet;
    [SerializeField]private Group m_group;
    public float mf_FirebulletTime;
    float mf_DowncountTime;
    // Start is called before the first frame update
    void Start()
    {
        mf_DowncountTime = mf_FirebulletTime;
    }

    // Update is called once per frame
    void Update()
    {
        mf_DowncountTime -= Time.deltaTime;
        if(mf_DowncountTime<0)
        {
            GameObject bullet = GameObject.Instantiate(m_prefebMbullet);
            bullet.transform.position = gameObject.transform.position;
            mf_DowncountTime = mf_FirebulletTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet_tag"))
        {
            Destroy(other.gameObject);
            bullet bulletScript = other.gameObject.GetComponent<bullet>();
            m_ihp -= bulletScript.m_ihurt;
            Debug.Log("collider " + other.name);
            GameObject iii = GameObject.Instantiate(bom);
            iii.transform.position = gameObject.transform.position;
            if (m_ihp<=0)
            {
                Destroy(gameObject);
                m_group.DeadOneMonstor();
            }
            Shaking shaking = gameObject.GetComponent<Shaking>();
            shaking.StartShaking();
        }
        
    }






    /*private void OnTriggerEnter(Collider other)
    {

        Debug.Log("collider "+other.name);
    }
    */
}
