using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePickup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Debug.Log("플레이어가 발사체와 충돌했습니다.");

            //발사체 획득 처리
            PlayerController player=coll.collider.GetComponent<PlayerController>();
            player.hasProjectile=true;

            //발사체 소멸 처리
            GameObject.Destroy(gameObject);
        }
    }
}
