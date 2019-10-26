using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusLevelLost : MonoBehaviour {

    /// <summary>
    /// When the pinball goes out of play, the 'AfterBlast' scene is loaded.
    /// This scene is similar but slightly different to the oringinal scene.
    /// This scene's points are doubled what they originally were and things like the 
    /// camera cutscene aren't in it.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        SceneManager.LoadScene("AfterBlast");
    }


}
