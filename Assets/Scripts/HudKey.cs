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
        player = FindObjectOfType<PlayerController>();//�÷��̾� ĳ��

        image=GetComponent<Image>();//�̹��� ������Ʈ �̸� ����

        GameObject key = GameObject.FindGameObjectWithTag("Key");//���� ���ӿ�����Ʈ ���� �˻�
        if (key == null) {//Ű�� ������
            gameObject.SetActive(false);//��Ȱ��ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return; // �÷��̾ ������ ����

        if (player.hasKey) {
            image.sprite = hasKeySprite; //�÷��̾ Ű�� ������
        }
        else {
            image.sprite = hasNoKeySprite; //�÷��̾ Ű�� ������
        }
    }
}
