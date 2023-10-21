using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //loads scenes when a button is clicked
    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ShowLevels()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartLevel1()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartLevel2()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void StartLevel3()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
