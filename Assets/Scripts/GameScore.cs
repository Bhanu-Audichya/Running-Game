using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public int score;
    private MoveLeft move;
    private PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ScoreTrack", 0, 1);
        move = GameObject.Find("Background").GetComponent<MoveLeft>();
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ScoreTrack()
    {
        if(move.sprint==false && !playerControl.gameOver)
        {
            score++;
            Debug.Log("ur score" + score);
        }
        else if(move.sprint==true && !playerControl.gameOver)
        {
            score += 2;
            Debug.Log("ur score" + score);
        }
        
    }
}
