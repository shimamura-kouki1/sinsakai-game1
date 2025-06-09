using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;

public class MainManeger : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバーUI")]
    private GameObject _gameOverUI;

    [SerializeField, Header("ゲームクリアUI")]
    private GameObject _gameClearUI;
    
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
    }


    private void _ShowGameOverUI()
    {   //「null」変数が何も入っていない状態
        //_moveのGameObjectがなくなったときに実行される
        if (_player != null) return;

        _gameOverUI.SetActive(true);
    }

    public void ShowGameClearUI()
    {
        _gameClearUI.SetActive(true);
    }
}
