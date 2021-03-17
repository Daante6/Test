using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Transform timeLeftBar;
    public float timeTotal;
    private float timeLeft;
    private float timeLeftNormalize;

    public GameObject timeBar;

    public GameObject player2IDE;

    private bool levelComplete = false;

    public GameObject player1;
    public GameObject player2;
    public GameObject Chain;
    public GameObject Chain2;
    public GameObject Player1Lives;
    public GameObject Player2Lives;

    void Start()
    {
        timeLeft = timeTotal;
        if (StaticNameController.twoPlayerMode)
        {
            player2IDE.SetActive(true);
        }
        else
        {
            player2IDE.SetActive(false);
        }
        if(StaticNameController.player1Lives < 1)
        {
            player1.SetActive(false);
            Chain.SetActive(false);
            Player1Lives.SetActive(false);
        }
        if (StaticNameController.player2Lives < 1)
        {
            player2.SetActive(false);
            Chain2.SetActive(false);
            Player2Lives.SetActive(false);
        }
    }

    void Update()
    {
        //time management
        timeLeft = timeLeft - Time.deltaTime;
        if(levelComplete == false)
        {
            if (timeLeft < 0)
            {
                if (StaticNameController.twoPlayerMode)
                {
                    StaticNameController.player2Lives--;
                }
                player1.GetComponent<Player1>().loseFunction();
                timeLeft = 0;
            }
        }
        //time bar + change color
        timeLeftNormalize = Mathf.InverseLerp(0, timeTotal, timeLeft);
        timeLeftBar.localScale = new Vector3(timeLeftNormalize * 20, 1f, 1f);
        if(timeLeft < timeTotal * 0.4)
        {
            var timeBarRenderer = timeBar.GetComponent<Renderer>();
            timeBarRenderer.material.SetColor("_Color", Color.red);
        }
        
        //disable chains when player is dead
        if(StaticNameController.player1Lives < 1)
        {
            Chain.SetActive(false);
        }
        else
        {
            Chain.SetActive(true);
        }
        if (StaticNameController.player2Lives < 1)
        {
            Chain2.SetActive(false);
        }
        else
        {
            Chain2.SetActive(true);
        }

        //end level
        GameObject[] objectsCount = GameObject.FindGameObjectsWithTag("Ball");
        if(objectsCount.Length < 1)
        {
            levelComplete = true;
            timeLeft = timeLeft - 0.06f;
            player1.GetComponent<Player1>().endLevel();
            player2.GetComponent<Player2>().endLevel();
            if(timeLeft < 0.01)
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
        }
    }
    public void addTime()
    {
        timeLeft = timeLeft + 20;
    }
}
