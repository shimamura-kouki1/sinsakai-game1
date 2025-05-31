using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;

public class MainManeger : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバーUI")]
    private GameObject _gameOverUI;

    private GameObject _move;


    // Start is called before the first frame update
    void Start()
    {
        _move = FindObjectOfType<PlayeBase>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
    }


    private void _ShowGameOverUI()
    {   //「null」変数が何も入っていない状態
        //_moveのGameObjectがなくなったときに実行される
        if (_move != null) return;

        _gameOverUI.SetActive(true);
    }
}
