using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    // Updates the Visible score to the current score value.
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Score: " + GameManagerScript.GameScore.ToString();
    }
}
