using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticNameController : MonoBehaviour
{
    public static int player1Lives = 3;
    public static int player2Lives = 3;
    public static int player1score= 0;
    public static int player2score = 0;
    public static bool twoPlayerMode = false;

    public static bool player1VineActive = false;
    public static bool player2VineActive = false;

    void Start()
    {
        
    }

    public static StaticNameController instance;
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
