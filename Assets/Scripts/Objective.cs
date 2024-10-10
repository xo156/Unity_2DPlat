using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {
    public string nextLevelName;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")){
            Debug.Log("플레이어가 목표물에 충돌");

            // 빈 문자열: ""

            PlayerPrefs.SetInt(nextLevelName, 1);
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
