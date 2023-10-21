using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

    //This script is used to decrease the falling time of a player
    //It may not be physically correct but, it makes the controls feel better

    //variable that multiplies with the gravity as the player is coming down
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2.5f;

    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        //If the vertical velocity of the player is -ve (player is coming down) increase the gravity.
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //If the player isn't pressing the jump button, increase the gravity
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
