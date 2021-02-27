using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AddHp : MonoBehaviour
{
    [SerializeField] private GameObject m_prefabBullet;
    [SerializeField] private float speed = 1;
    [SerializeField] private float liveTime = 2;
    public int m_ihp = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += speed * Time.deltaTime;
        gameObject.transform.position = pos;
        liveTime -= Time.deltaTime;
        if (liveTime < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet_tag"))
        {
            
            bullet bulletScript = other.gameObject.GetComponent<bullet>();
            m_ihp -= bulletScript.m_ihurt;
            Debug.Log("collider " + other.name);
            Destroy(other.gameObject);
            if (m_ihp <= 0)
            {
                Destroy(gameObject);
                GameObject iii = GameObject.Instantiate(m_prefabBullet);
                iii.transform.position = gameObject.transform.position;
            }
        }
    }
}