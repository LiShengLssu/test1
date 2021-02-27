using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    // Start is called before the first frame update
  //  [SerializeField] Material m_origin;
  //  [SerializeField] Material m_white;
    [SerializeField] float m_fFlashTime;
    float m_fCountdownTime;
    bool m_bFlash = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_bFlash)
        {
            m_fCountdownTime -= Time.deltaTime;
            if(m_fCountdownTime<0)
            {
                gameObject.GetComponent<Material>().color = new Color(1, 0, 0);
                m_bFlash = false;
            }
        }
    }
}
