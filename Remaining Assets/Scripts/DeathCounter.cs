using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    //initialize deathCount
    public static int deathCount = 0;
    TMP_Text death;

    // Start is called before the first frame update
    void Start()
    {
        //gets the text component
        death = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //adds one to the death count
        death.text = "Death Count: " + deathCount;
    }
}
