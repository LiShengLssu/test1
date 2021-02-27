using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField] float m_ShakeSpeed = 1;
    [SerializeField] float m_ShakeTime = 0.1f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float liveTime = 1;
    [SerializeField] private GameManager m_GM;
    bool m_bShake = true;
    bool m_bPlay = true;
    public float m_fShakeCurrentTime = 0;
    public int m_Num = 0;
    Vector3 m_OriginedPosition;
    int Times = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_OriginedPosition = gameObject.transform.position;
        Times = 0;
        m_bPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_bPlay)
            return;
        if (m_bShake)
        {
            Vector3 pos = gameObject.transform.position;
            m_fShakeCurrentTime += Time.deltaTime;
            if (m_fShakeCurrentTime < 0.25 * m_ShakeTime)
            {
                pos.x += m_ShakeSpeed * Time.deltaTime;
                gameObject.transform.position = pos;
            }
            else if (m_fShakeCurrentTime < 0.75 * m_ShakeTime)
            {
                pos.x -= m_ShakeSpeed * Time.deltaTime;
                gameObject.transform.position = pos;
            }
            else if (m_fShakeCurrentTime < 1.0 * m_ShakeTime)
            {
                pos.x += m_ShakeSpeed * Time.deltaTime;
                gameObject.transform.position = pos;
            }
            else
            {
                Times++;
                if(Times>=2)
                {
                    m_bShake = false;
                    gameObject.transform.position = m_OriginedPosition;
                    m_fShakeCurrentTime = 0;
                    Times = 0;
                }
                else
                {
                    m_fShakeCurrentTime = 0;
                }
            }
        }
        else
        {
            Vector3 pos = gameObject.transform.position;
            pos.y += speed * Time.deltaTime;
            gameObject.transform.position = pos;
            liveTime -= Time.deltaTime;
            if (liveTime < 0)
            {
                liveTime = 1;
                m_OriginedPosition = pos;
                m_bShake = true;
            }
        }     
    }
    public void StopGame()
        {
            m_bPlay = false;
        }
    public void DeadOneMonstor()
    {
        m_Num--;
        if(m_Num<0)
        {
            m_GM.GameOver();
        }
    }
}
