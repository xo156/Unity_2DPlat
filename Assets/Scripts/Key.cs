using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Debug.Log("�÷��̾ ����� �浹�߽��ϴ�.");

            //���� ȹ�� ó��
            PlayerController player = coll.collider.gameObject.GetComponent<PlayerController>();
            player.hasKey= true;

            //���� �Ҹ� ó��
            GameObject.Destroy(gameObject);
        }
    }
}
