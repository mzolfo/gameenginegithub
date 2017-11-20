using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerUponLeaving : MonoBehaviour {
    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // TODO: replace with a call to PlayerRespawn
            collision.gameObject.GetComponent<PlayerRespawn>().Respawn();
        }
    }
}
