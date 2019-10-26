using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusLevelScript : MonoBehaviour {

    [SerializeField] private int hitScorePoints = 5000;
    public static int iLettersActive;

    // Sets the letter tracker int to 0 at the start of the level.
	void Start () {
        iLettersActive = 0;
	}
	
	/// <summary>
    /// Checks constantly to when all 5 letters have been activated.
    /// Resets the int and then calls 'BonusLevel()' function.
    /// </summary>
	void Update () {
		if (iLettersActive >= 5)
        {
            iLettersActive = 0;
            BonusLevel();
        }
	}

    /// <summary>
    /// "BLASTOFF" Audio is played and delay coroutine is started.
    /// </summary>
    void BonusLevel()
    {
        GameManagerScript.GameScore += hitScorePoints;
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadBonusLevel());
    }

    /// <summary>
    /// Delay to take into account time for audio to play and then bonus level is called.
    /// </summary>
    private IEnumerator LoadBonusLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("BLAST");
    }
}
