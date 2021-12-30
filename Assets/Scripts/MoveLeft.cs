using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerControl playerControl;
    private float lowerBound = -15;
    public bool sprint = false;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.gameOver==false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            
        }
        if (Input.GetKey(KeyCode.S) && !playerControl.gameOver)
        {
            transform.Translate(Vector3.left * 2 * Time.deltaTime * speed);
            sprint = true;
        }
        if(!Input.GetKey(KeyCode.S) && !playerControl.gameOver)
        {
            sprint = false;
        }
        if (transform.position.x<lowerBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
