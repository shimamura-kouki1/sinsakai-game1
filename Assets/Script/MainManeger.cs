using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManeger : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        //フレームレートの制限
        Application.targetFrameRate = 60;

        _player = FindObjectOfType<Player>().gameObject;
        score = 0;

        //ReStartButton(); 92行目
    }

    // Update is called once per frame
    void Update()
    {
        ShowGameOverUI();

        Score();

        PauseGame();
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

    public void Choice()
    {   //
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
