using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnPos;
    private PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 2f);
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Spawn()
    {
        int index = Random.Range(0, obstacles.Length);
        spawnPos = new Vector3(Random.Range(25,35), 0, 0);
        if (playerControl.gameOver == false)
        { 
            Instantiate(obstacles[index], spawnPos, obstacles[index].transform.rotation);
        }
        
    }
}
