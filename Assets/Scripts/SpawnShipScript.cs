using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShipScript : MonoBehaviour {

    [SerializeField] GameObject SpaceShip;
    [SerializeField] private int hitScorePoints = 1000;
    private int iTriggeredAmount;

    /// <summary>
    /// Resets the number of times triggered to 0.
    /// </summary>
	void OnEnable () {
        iTriggeredAmount = 0;
    }

    /// <summary>
    /// When a pinball hits reaches the small spaceship to the right side,
    /// points are added to the score, the 'iTriggeredAmount' counts the number of times hit
    /// and red particles are played to show the player they hit it.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pinball"))
        {
            GameManagerScript.GameScore += hitScorePoints;
            iTriggeredAmount += 1;
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    /// <summary>
    /// When the player manages to hit the bonus 3 times the large multiball
    /// spaceship is enabled and the small trigger is disabled.
    /// </summary>
    void Update () {
		if(iTriggeredAmount >= 3)
        {
            SpaceShip.SetActive(true);
            gameObject.SetActive(false);
        }
	}
}
