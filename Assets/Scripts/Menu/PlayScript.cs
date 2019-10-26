using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour {

    private GameObject Highscore;

    /// <summary>
    /// I had to assign the highscore gameobject here rather than a serialised field
    /// as I was getting errors. This sets the highscore text to the current saved highscore.
    /// </summary>
    private void Start()
    {
        Highscore = GameObject.FindGameObjectWithTag("Highscore");
        Highscore.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    /// <summary>
    /// 'PlayGame()', 'Options()', 'ExitGame()' and 'BackButton()' 
    /// are used by the buttons in the two menu scenes. They use scenemanager
    /// to change the scene into the game or between the two menus.
    /// </summary>
    public void PlayGame()
    {
        Debug.Log("PLAY");
        SceneManager.LoadScene("ArcadeScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("MenuOptions");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// This deletes the value stored in PlayerPrefs for the highscore and resets it to 0.
    /// This is then represented on screen.
    /// </summary>
    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        Highscore.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
}
