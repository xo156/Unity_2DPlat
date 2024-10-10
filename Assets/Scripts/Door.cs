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
            Debug.Log("�÷��̾ ���� �浹�߽��ϴ�.");

            PlayerController player=coll.gameObject.GetComponent<PlayerController>();
            if (player == null) return;
            
            if(player.hasKey) {
                player.hasKey = false; //�÷��̾� ���� ����

                //�� ����
                spriteRenderer.sprite = openedDoorSprite;
                boxCollider2D.enabled = false;
            }
        }
    }
}
