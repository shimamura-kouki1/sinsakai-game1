using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;

public class MainManeger : MonoBehaviour
{
    [SerializeField, Header("�Q�[���I�[�o�[UI")]
    private GameObject _gameOverUI;

    [SerializeField, Header("�Q�[���N���AUI")]
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
    {   //�unull�v�ϐ������������Ă��Ȃ����
        //_move��GameObject���Ȃ��Ȃ����Ƃ��Ɏ��s�����
        if (_player != null) return;

        _gameOverUI.SetActive(true);
    }

    public void ShowGameClearUI()
    {
        _gameClearUI.SetActive(true);
    }
}
