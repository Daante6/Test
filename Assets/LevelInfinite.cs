using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfinite : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;
    public Transform pos1;
    public Transform pos2;

    public GameHandler gameHandler;

    private int rand;

    // Update is called once per frame
    void Update()
    {
        GameObject[] objectsCount = GameObject.FindGameObjectsWithTag("Ball");
        if (objectsCount.Length < 3)
        {
            rand = Random.Range(0, 2);
            if(rand == 0)
            {
                rand = Random.Range(0, 2);
                if(rand == 0)
                {
                    GameObject Ball1 = Instantiate(ball1, pos1.position, Quaternion.identity);
                    Ball1.GetComponent<Ball>().startForce = new Vector2(2f, 1f);
                    gameHandler.GetComponent<GameHandler>().addTime();
                }
                else
                {
                    GameObject Ball2 = Instantiate(ball2, pos1.position, Quaternion.identity);
                    Ball2.GetComponent<Ball>().startForce = new Vector2(2f, 1f);
                    gameHandler.GetComponent<GameHandler>().addTime();
                }
            }
            else
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    GameObject Ball3 = Instantiate(ball1, pos2.position, Quaternion.identity);
                    Ball3.GetComponent<Ball>().startForce = new Vector2(-2f, 1f);
                    gameHandler.GetComponent<GameHandler>().addTime();
                }
                else
                {
                    GameObject Ball4 = Instantiate(ball2, pos2.position, Quaternion.identity);
                    Ball4.GetComponent<Ball>().startForce = new Vector2(-2f, 1f);
                    gameHandler.GetComponent<GameHandler>().addTime();
                }
            }
            
        }
    }
}
