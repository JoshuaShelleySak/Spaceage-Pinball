using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipOscillator : MonoBehaviour {

    private float fTimeCounter = 0;

    [SerializeField] GameObject Pinball, SpaceshipTrigger;
    [SerializeField]private float fRotationSpeed = 1, fRotationWidth = 1, fRotationLength = 1;
    [SerializeField] private int hitScorePoints = 250;
    private int hitPoints;
    private float timeLeft;

    private Vector3 InitialPosition;
    
    /// <summary>
    /// As soon as the spaceship is enabled "MULTIBALL" is announced.
    /// The initial position is stored to find out where to rotate around.
    /// The hitpoints are set to 0 and 20seconds is set on the timer.
    /// </summary>
	void OnEnable () {
        gameObject.GetComponent<AudioSource>().Play();
        InitialPosition = gameObject.transform.position;
        hitPoints = 0;
        timeLeft = 20.0f;
	}

	/// <summary>
    /// The update tracks time change and causes the spaceship to rotate in an oval.
    /// After time = 0s, a pinball is instantiated depending on the int value.
    /// Finally the small spaceship trigger is enabled again and the large spaceship is disabled.
    /// </summary>
	void Update () {

        fTimeCounter += Time.deltaTime * fRotationSpeed;

        float x = Mathf.Cos (fTimeCounter) * fRotationWidth;
        float y = 1;
        float z = Mathf.Sin(fTimeCounter) * fRotationLength;

        transform.position = new Vector3(x + InitialPosition.x, y + InitialPosition.y, z + InitialPosition.z);

        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            for (var i = 0; hitPoints > i; i++)
            {
                Instantiate(Pinball, new Vector3(-8f+(i*2), 25.5f, 5.7f), Quaternion.identity);
            }
            SpaceshipTrigger.SetActive(true);
            gameObject.SetActive(false);
        }

	}

    /// <summary>
    /// When the pinball collides with the spaceship the 'hitPoints' int tracker is increased.
    /// Points are also added to the score.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pinball"))
        {
            hitPoints += 1;
            GameManagerScript.GameScore += hitScorePoints;
        }
    }
}
