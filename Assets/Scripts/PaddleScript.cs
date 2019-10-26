using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleScript : MonoBehaviour {

    [SerializeField] Button FlipButton;
    [SerializeField] private float fPressedPosition = 45f;
    [SerializeField] private float fRestPosition = 0f;
    [SerializeField] private float fHitStrength = 10000f;
    [SerializeField] private float fPaddleDamper = 150f;
    HingeJoint hinge;
    private bool bFlipping = false;

    //Sets components.
	void Start () {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    /// <summary>
    /// Change flipping bool to true and play audio.
    /// </summary>
    public void FlipUp()
    {
        // Null-check for the top left paddle.
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        bFlipping = true;
    }

    //Change flipping bool to false.
    public void FlipDown()
    {
        bFlipping = false;
    }

    /// <summary>
    /// Changes the position of the flipper depending on the current value of the bool.
    /// </summary>
	void Update () {
        JointSpring spring = new JointSpring();
        spring.spring = fHitStrength;
        spring.damper = fPaddleDamper;

        if (bFlipping == true)
        {
            spring.targetPosition = fPressedPosition;
        }
        else
        {
                spring.targetPosition = fRestPosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }

}
