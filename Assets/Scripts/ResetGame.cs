using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

    [SerializeField] private Vector3 pinballSpawnLocation;
    [SerializeField] GameObject Pinball, gStartBlock, gStartBlockTrigger, MultiballSpaceship;
    private int EndScore;

    // When the scene is loaded and cutscene has stopped, spawn a pinball.
    void Start () {
        InstantiatePinball();
	}

    /// <summary>
    /// When a pinball is in the out of bounds area below the flippers the script checks how many
    /// pinballs are currently in play. If there is more than 1, the pinball is destroyed.
    /// However, if it is the last pinball in play then it is destroyed, the total remaining pinballs
    /// the player has is reduced by 1 and the start blockage is disabled and replaced by the trigger again.
    /// If the player has pinballs left then another is spawned in. 
    /// If the player has 0 pinballs left then the script checks whether multiball is in play as that will spawn more in.
    /// When the player has 0 left and multiball isn't active then the game is over, the script checks if the player has beaten the
    /// previous highscore and if so "NEW HIGHSCORE" is annunced and the highscore PlayerPrefs is set to their score.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectsWithTag("Pinball").Length <= 1)
        {
            Destroy(other.gameObject);
            GameManagerScript.RemainingPinballs -= 1;
            gStartBlock.SetActive(false);
            gStartBlockTrigger.SetActive(true);
            if (GameManagerScript.RemainingPinballs > 0)
            {
                InstantiatePinball();
            }
            else if (!(MultiballSpaceship.activeSelf))
            {
                Debug.Log("GAME OVER");
                EndScore = GameManagerScript.GameScore;
                if (EndScore > PlayerPrefs.GetInt("Highscore", 0))
                {
                    PlayerPrefs.SetInt("Highscore", EndScore);
                    gameObject.GetComponent<AudioSource>().Play();

                }

                StartCoroutine(LoadMenuScene());
                // END THE RUN
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// This is a 2 second delay to account for the audio "NEW HIGHSCORE".
    /// </summary>
    private IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu");
    }

    //Spawns a pinball at default location.
    void InstantiatePinball()
    {
        Instantiate(Pinball, pinballSpawnLocation, Quaternion.identity);
    }
}
