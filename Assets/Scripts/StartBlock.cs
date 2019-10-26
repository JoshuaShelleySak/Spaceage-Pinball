using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour {

    [SerializeField] private GameObject gStartBlock;

    /// <summary>
    /// Blocks off the start runway when the pinball is past the trigger.
    /// Stops pinballs going down there during multiball and disabling the flippers.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            gStartBlock.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
