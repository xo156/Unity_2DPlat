using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePickup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Debug.Log("�÷��̾ �߻�ü�� �浹�߽��ϴ�.");

            //�߻�ü ȹ�� ó��
            PlayerController player=coll.collider.GetComponent<PlayerController>();
            player.hasProjectile=true;

            //�߻�ü �Ҹ� ó��
            GameObject.Destroy(gameObject);
        }
    }
}
