using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    public string levelNameToLoad;

    Button button;

    // Start is called before the first frame update
    void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick() {
        Debug.Log("���� ���� ��ư Ŭ��");

        SceneManager.LoadScene(levelNameToLoad);
    }
}
