using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")){
            Debug.Log("플레이어가 가시에 충돌");
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
        
            GameManager.Instance.GamaOver();
        }
    }

    private void Start() {
        Debug.Log("이거 왜 안나옴");    
    }
}
