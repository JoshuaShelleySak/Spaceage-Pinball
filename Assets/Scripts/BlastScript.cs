using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastScript : MonoBehaviour {

    private bool bActivated;
    Color activatedColour, deactivatedColour;

    /// <summary>
    /// Each letter on the orignial map starts off deactivated and the colours are assigned.
    /// </summary>
    private void Start()
    {
        bActivated = false;
        activatedColour = new Color(1.0f, 0.6f, 0.0f);
        deactivatedColour = new Color(0.08f, 0.08f, 0.08f);
        gameObject.GetComponent<TextMesh>().color = deactivatedColour;
    }

    /// <summary>
    /// When the ball goes over a letter there is a trigger which causes the letter triggered
    /// to change colour and add one to the 'iLettersActive' int which tracks the total number
    /// of the 5 letters that have been activated. It then sets the bActivated bool to false so
    /// the 'iLettersActive' int doesn't increase anymore for that specific letter.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pinball"))
        {
            if (bActivated == false)
            {
                gameObject.GetComponent<TextMesh>().color = activatedColour;
                BonusLevelScript.iLettersActive += 1;
            }
            bActivated = true;
        }
    }
}
