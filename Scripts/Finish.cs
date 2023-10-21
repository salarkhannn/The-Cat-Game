 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the player is touching the finish object
        if (collision.gameObject.CompareTag("Player"))
        {
            //play the finish sound
            FindObjectOfType<AudioManager>().Play("Finish");
            //call complete level function
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        //load the next scene(level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
