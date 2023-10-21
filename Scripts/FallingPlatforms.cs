using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    //initializes fallDelay and destroyDelay variables
    [SerializeField] private float fallDelay = 0.5f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the player object is colliding with the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            //make the platform fall
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        //wait for a few seconds
        yield return new WaitForSeconds(fallDelay);
        //set the platform's rigidbody type to dynamic so it's affected by gravity
        rb.bodyType = RigidbodyType2D.Dynamic;
        //destroys the platform game object
        Destroy(gameObject, destroyDelay);
    }
}
