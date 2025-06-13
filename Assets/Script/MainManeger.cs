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
    private GameObject reStartButton;

    [SerializeField,Header("ポーズ画面")]
    private GameObject _pose;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();

        Score();

        PauseGame();
    }

    public void Score()
    {　　//加算されるスコアはPleyerの124行目
        _textText.text = ("Score" + score);
    }

    private void _ShowGameOverUI()
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
    {　 //↑に同じ　　
        _gameClearUI.SetActive(true);
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                _pose.SetActive(true);
                Time.timeScale = 0;
        }
        else
        {
            // Destroy( _pose );
            Time.timeScale = 1;
        }
    }
}
