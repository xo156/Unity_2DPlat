using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Debug.Log("ÇÃ·¹ÀÌ¾î°¡ ¿­¼è¿Í Ãæµ¹Çß½À´Ï´Ù.");

            //¿­¼è È¹µæ Ã³¸®
            PlayerController player = coll.collider.gameObject.GetComponent<PlayerController>();
            player.hasKey= true;

            //¿­¼è ¼Ò¸ê Ã³¸®
            GameObject.Destroy(gameObject);
        }
    }
}
