using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    [SerializeField] float m_ShakeSpeed = 1;
    [SerializeField] float m_ShakeTime = 0.1f;
    bool m_bShake = false;
    public float m_fShakeCurrentTime = 0;
    Vector3 m_OriginedPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_OriginedPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
                m_bShake = false;
                gameObject.transform.position = m_OriginedPosition;
            }
        }
    }
    public void StartShaking()
    {
        m_bShake = true;
        m_fShakeCurrentTime = 0;
        m_OriginedPosition = gameObject.transform.position;
    }
}