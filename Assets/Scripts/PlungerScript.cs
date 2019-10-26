using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour {
    float fPower;
    float fMinPower = 0f;
    [SerializeField] private float fMaxPower = 100f;
    [SerializeField] Slider powerSlider;
    [SerializeField] Button leftPaddleButton, rightPaddleButton;
    List<Rigidbody> pinballList;
    bool bBallReady = false;

    /// <summary>
    /// Sets start values and empty list.
    /// </summary>
	void Start () {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = fMaxPower;
        pinballList = new List<Rigidbody>();
	}
	
    /// <summary>
    /// The value of the slider is set to the value of the power.
    /// When the ball is in the trigger ball ready = true.
    /// When the trigger is true the paddle buttons are disabled and the slider enabled.
    /// When you hold down a finger on the screen power is added to the 'fPower' int.
    /// As soon as the finger is removed from the screen, the power is applied to the ball.
    /// </summary>
	void Update () {


        powerSlider.value = fPower;

        if (bBallReady)
        {
            leftPaddleButton.gameObject.SetActive(false);
            rightPaddleButton.gameObject.SetActive(false);
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            leftPaddleButton.gameObject.SetActive(true);
            rightPaddleButton.gameObject.SetActive(true);
            powerSlider.gameObject.SetActive(false);
        }

        if(pinballList.Count > 0)
        {
            bBallReady = true;
            if(Input.touchCount > 0)
            {
                var tapCount = Input.touchCount;
                for (var i = 0; tapCount > i; i++)
                {
                    var touch = Input.GetTouch(i);

                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        if (fPower <= fMaxPower)
                        {
                            fPower += 100f * Time.deltaTime;
                        }
                    }
                    else if(touch.phase == TouchPhase.Ended)
                    {
                        foreach (Rigidbody r in pinballList)
                        {
                            r.AddForce(fPower * 25f * Vector3.forward);
                            fPower = 0f;
                        }
                    }
                }
            }

        }
        else
        {
            bBallReady = false;
            fPower = 0f;
        }
	}

    //Adds ball to pinball list.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            pinballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    //Removes ball to pinball list.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            pinballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            fPower = 0f;
        }
    }
}
