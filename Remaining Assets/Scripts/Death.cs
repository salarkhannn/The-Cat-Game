using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    //Initialize all the neccessary variables and objects
    [SerializeField] private LayerMask obstacles;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject Player;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private BoxCollider2D boxCollider;

    // Update is called once per frame
    void Update()
    {
        //If the player's top or bottom touches an obstacle, call the Die() function
        if (TouchBottom() || TouchTop())
        {
            //Increase the death count
            DeathCounter.deathCount += 1;
            Die(Player);
        }
    }

    // checks if the bottom of the player touches an obstacle
    private bool TouchBottom()
    {
        //bottom of the player contains a circle collider
        //check if the circle collider is touching the obstacles layer
        bool Touching = Physics2D.IsTouchingLayers(circleCollider, obstacles);
        return Touching;
    }

    // checks if the top of the player touches an obstacle
    private bool TouchTop()
    {
        //top of the player contains a box collider
        //check if the box collider is touching the obstacles layer
        bool Touching = Physics2D.IsTouchingLayers(boxCollider, obstacles);
        return Touching;
    }

    public void Die(GameObject Player)
    {
        //play the death sound
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        //make the player object inactive
        Player.SetActive(false);
        //reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
