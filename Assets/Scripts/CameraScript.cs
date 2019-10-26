using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    [SerializeField] GameObject gLostSection, gCanvas;
    private bool bTriggered = false;

    // Set Canvas and ResetGame ball spawning to false at the start.
    private void Awake()
    {
        gLostSection.SetActive(false);
        gCanvas.SetActive(false);
    }
	
    /// <summary>
    /// Plays the cutscene for the first time when the scene is loaded.
    /// Disables the ball spawning and UI canvas until the cutscene is finished.
    /// </summary>
	void Update () {
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Gameplay") && !bTriggered)
        {
            bTriggered = true;
            gLostSection.SetActive(true);
            gCanvas.SetActive(true);
        }
    }
}
