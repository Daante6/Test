using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playSolo()
    {
        StaticNameController.twoPlayerMode = false;
        StaticNameController.player1Lives = 3;
        StaticNameController.player2Lives = 0;
        StaticNameController.player1score = 0;
        StaticNameController.player2score = 0;
        SceneManager.LoadScene("Level1");
    }
    public void playMulti()
    {
        StaticNameController.twoPlayerMode = true;
        StaticNameController.player1Lives = 3;
        StaticNameController.player2Lives = 3;
        StaticNameController.player1score = 0;
        StaticNameController.player2score = 0;
        SceneManager.LoadScene("Level1");
    }
}
