using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField] GameManager m_GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Over");
        if (other.CompareTag("Monster"))
        {
            Debug.Log("Game Over");
            m_GM.GameOver();
        }
    }
}
