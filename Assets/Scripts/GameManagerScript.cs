using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public static int GameScore;
    public static int RemainingPinballs;

    // Makes sure the score is kept constantly throughout the scenes.
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Reset gamescore and remaining pinballs.
    void Start () {
        GameScore = 0;
        RemainingPinballs = 3;
	}

    // When the Menu scene is loaded after the player loses then the script is destroyed so there aren't duplicates created when replaying.
    // The score is saved in the ResetGame script so you no longer need this for the menu.
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(gameObject);
        }
    }
}
