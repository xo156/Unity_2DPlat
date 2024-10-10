using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        Running = 0,
        Paused = 1
    }
    static GameManager _instance; 
    //스태틱으로 선언해야 타입(GameManager)에 맞춰 하나만 존재(인스턴스, 프로퍼티)하게 함

    //싱글톤 패턴
    // 한번에 2개 이상 생기지 않도록 한정시키는(제한시키는) 패턴

    public static GameManager Instance{
        //프로퍼티
        get {
            _instance=FindObjectOfType<GameManager>();

            if(_instance==null){
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public GameState State {
        //get은 읽기 전용 프로퍼티
        get {
            return state;
        }
    }
    [SerializeField] GameState state;
    InGameHud hud;

    void Start() {
        if (_instance == null){
            _instance=this;
        }
        else{//중복된 게임메니저가 존재하면
            GameObject.Destroy(gameObject);
        }

        hud=FindObjectOfType<InGameHud>();
    }

    public void ResumeGame() {
        state = GameState.Running;
        hud.ClosePauseMenu();
        Time.timeScale = 1.0f;
    }

    public void OpenMenu() {
        SceneManager.LoadScene("Scenes/Menu");
        ResumeGame();
    }

    public void QuitGame() {
        Application.Quit();
    }

    void PauseGame() {
        state = GameState.Paused;
        hud.OpenPauseMenu();
        Time.timeScale = 0.0f;
    }

    public void GamaOver(){
        Debug.Log("게임 오버");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (state == GameState.Running) {
                PauseGame();
            }
            else {
                ResumeGame();
            }
        }
    }
}
