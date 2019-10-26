using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour {

    [SerializeField] private int hitScorePoints = 100;

    [SerializeField] private float bounceForceTest = 25.0f;

    /// <summary>
    /// When a bumper is hit, points are added to the score.
    /// If it is a pinball that collided with it then force is added in the opposite direction.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        GameManagerScript.GameScore += hitScorePoints;
        if (collision.gameObject.CompareTag("Pinball"))
        {
            collision.rigidbody.AddForce(-(collision.contacts[0].normal * bounceForceTest), ForceMode.VelocityChange);
        }
    }

}
