using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController m_player;
    [SerializeField] Group m_Group;
    [SerializeField] DeadLine m_DeadLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        m_Group.StopGame();
        m_player.StopGame();
    }
}
