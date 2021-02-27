using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    public GameObject prefabBullet;
    public Transform tfFirepos;
    public float m_fIntervalTime = 0.1f;
    float m_firecurrentTime = 0;
    bool m_bPlay = true;
    public int m_iHp;
    [SerializeField] Shaking CameraShaking;
    //public GameObject prefabBullet;
    //public Transform tfFirePos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_bPlay)
            return;
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = gameObject.transform.position;
            pos.x -= speed*Time.deltaTime;
            gameObject.transform.position = pos;
        }
        if(Input.GetKey(KeyCode.D))
        {
            Vector3 pos = gameObject.transform.position;
            pos.x += speed * Time.deltaTime;
            gameObject.transform.position = pos;
        }
        m_firecurrentTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && m_firecurrentTime < 0)
        {
            GameObject bullet = GameObject.Instantiate(prefabBullet);
            bullet.transform.position = tfFirepos.transform.position;
            m_firecurrentTime = m_fIntervalTime;
        }

       /* if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = GameObject.Instantiate(prefabBullet);
            bullet.transform.position = tfFirePos.transform.position;

            Debug.Log("fire");
            }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("M_bullet_tag"))
        {
            Debug.Log("HHH");
            bullet script = other.gameObject.GetComponent<bullet>();
            m_iHp -= script.m_ihurt;
            Destroy(other.gameObject);
            if(m_iHp<0)
            {
                //GAME OVER
            }

            CameraShaking.StartShaking();

        }
        if (other.CompareTag("M_AddHp"))
        {
            bullet script = other.gameObject.GetComponent<bullet>();
            m_iHp -= script.m_ihurt;
            Destroy(other.gameObject);
        }
    }

    public void StopGame()
    {
        m_bPlay = false;
    }
}
