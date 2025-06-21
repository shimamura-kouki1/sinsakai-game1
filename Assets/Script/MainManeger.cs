using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManeger : MonoBehaviour
{
    [SerializeField]
    public string sceneName;//タイトル画面作り途中

    [SerializeField, Header("スコア")]
    private TextMeshProUGUI _textText;
    public static int score = 0;

    [SerializeField, Header("ゲームオーバーUI")]
    private GameObject _gameOverUI;

    [SerializeField, Header("ゲームクリアUI")]
    private GameObject _gameClearUI;

    [SerializeField,Header("ReStart")]
    private GameObject _reStartButton;

    [SerializeField,Header("ポーズ画面")]
    private GameObject _pose;

    private GameObject _player;

    Button button;

    [Header("リスタートボタン")]
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        //フレームレートの制限
        Application.targetFrameRate = 60;

        _player = FindObjectOfType<Player>().gameObject;
        score = 0;

        //最初に選択状態にする
        EventSystem.current.SetSelectedGameObject(restartButton.gameObject);

        //ReStartButton(); 92行目
    }

    // Update is called once per frame
    void Update()
    {
        ShowGameOverUI();

        Score();

        PauseGame();

        /*選択されていない状態から再度選択状態に戻す
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(restartButton.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject selectedObj = EventSystem.current.currentSelectedGameObject;
            if (selectedObj != null)
            {
                Button btn = selectedObj.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.Invoke(); // ボタンのクリックイベントを実行
                }
            }
        }*/
    }

    public void Score()
    {　　//加算されるスコアはPleyerの124行目
        _textText.text = ("Score" + score);
    }

    private void ShowGameOverUI()
    {
        //_playerのGameObjectがnullの時に実行される
        if (_player != null)
        {
            return;
        }
        //gameOverUIが有効になる
        _gameOverUI.SetActive(true); //SetActive = ゲームオブジェクトの有効・無効を切り替える
    }

    public void ShowGameClearUI()//Playerスクリプト103行目
    {　 　
        //gameClearUIが有効になる
        _gameClearUI.SetActive(true);

        Time.timeScale = 0;

    }
    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.T))
        {
           　　//ポーズ画面をtureにする
                _pose.SetActive(true);
            　　//ゲームを一時停止
                Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            _pose.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReStartButton()
    {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
    }
    public void TitleButton()//ゲーム画面製作中
    {
            SceneManager.LoadScene("TitleScene");
    }
    public void Choice()
    {   
        button = GameObject.Find("Canvas/pose/ReStartButton/Button").GetComponent<Button>();
        button.Select();
    }
   
    /*public void ReStartButton()
    {   //ポーズ画面をfalseに
        _pose.SetActive(false);
        //ゲーム進行
        Time.timeScale = 1;
    }*/
}
//まとめてコメントアウト　ctrl+K+C
//まとめてコメントアウト解除　ctrl +K+U
