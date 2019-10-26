using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelStart : MonoBehaviour {

    [SerializeField] private GameObject Pinball;
    [SerializeField] Vector3 pinballSpawnLocation;

    // Spawns a pinball at a set place when the bonus level is reached.
    private void Start()
    {
        Instantiate(Pinball, pinballSpawnLocation, Quaternion.identity);
    }
}
