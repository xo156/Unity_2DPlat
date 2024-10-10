using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHealth : MonoBehaviour
{
    public List<Image> hearts=new List<Image>();//����� ���ÿ� ��ü ����
    PlayerController player;

    public Sprite hasHealthSprite;
    public Sprite hasNoHealthSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        for (int i = 0 ; i < hearts.Count ; i++) {
            if (i < player.health) {
                hearts[i].sprite = hasHealthSprite;
            }
            else {
                hearts[i].sprite=hasNoHealthSprite;
            }
        }
    }
}
