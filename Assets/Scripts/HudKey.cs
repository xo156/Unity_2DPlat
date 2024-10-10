using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudKey : MonoBehaviour
{
    public Sprite hasKeySprite;
    public Sprite hasNoKeySprite;

    PlayerController player;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();//플레이어 캐싱

        image=GetComponent<Image>();//이미지 컴포넌트 미리 저장

        GameObject key = GameObject.FindGameObjectWithTag("Key");//열쇠 게임오브젝트 존재 검사
        if (key == null) {//키가 없으면
            gameObject.SetActive(false);//비활성화
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return; // 플레이어가 없으면 종료

        if (player.hasKey) {
            image.sprite = hasKeySprite; //플레이어가 키를 가지면
        }
        else {
            image.sprite = hasNoKeySprite; //플레이어가 키가 없으면
        }
    }
}
