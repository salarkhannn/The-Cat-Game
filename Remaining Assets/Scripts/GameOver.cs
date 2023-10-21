using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //script for the start again button
    public void StartAgain()
    {
        //load the start menu
        SceneManager.LoadScene(0);
    }

    //script for the quit button
    public void Quit()
    {
        //quits the game
        Application.Quit();
    }
}
