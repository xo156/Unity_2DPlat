using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openedDoorSprite;

    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D=GetComponent<BoxCollider2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Debug.Log("플레이어가 문과 충돌했습니다.");

            PlayerController player=coll.gameObject.GetComponent<PlayerController>();
            if (player == null) return;
            
            if(player.hasKey) {
                player.hasKey = false; //플레이어 열쇠 뺏기

                //문 열림
                spriteRenderer.sprite = openedDoorSprite;
                boxCollider2D.enabled = false;
            }
        }
    }
}
