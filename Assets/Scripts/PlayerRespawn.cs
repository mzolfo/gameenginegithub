using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour {

    // This script must be placed on the player gameobject!


    public void Respawn()
    {
            if (Checkpoint.currentlyActiveCheckpoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                transform.position =
                    Checkpoint.currentlyActiveCheckpoint.transform.position;
            }      
    }
}
