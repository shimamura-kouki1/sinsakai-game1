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
    private bool _isPaused = false;

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

        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartGame();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ReStartButton();
        }
    }

    public void Score()
    {　　//加算されるスコアはPleyerの124行目
        _textText.text = ("Score" + score);
    }

    private void ShowGameOverUI()
    {
        if (_player != null)        //_playerのGameObjectがnullの時に実行される
        {
            return;
        }
        //gameOverUIが有効になる
        _gameOverUI.SetActive(true);    //SetActive = ゲームオブジェクトの有効・無効を切り替える
    }

    public void ShowGameClearUI()           //Playerスクリプト103行目
    {　 　
        _gameClearUI.SetActive(true);        //gameClearUIが有効になる
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _isPaused = !_isPaused;             // 状態を反転

            _pose.SetActive(_isPaused);         // ポーズ画面を表示/非表示
            Time.timeScale = _isPaused ? 0 : 1; // 一時停止／再開  trueなら0、falseなら1を代入する
                                                //三項演算子とは、条件式 ? 真の場合の値 : 偽の場合の値　という式
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

    public void StartGame()//タイトルシーンへ移動
    {
        // "GameScene" は遷移先のシーン名
        SceneManager.LoadScene("SelectScene");
    }
}
//まとめてコメントアウト　ctrl+K+C
//まとめてコメントアウト解除　ctrl +K+U
