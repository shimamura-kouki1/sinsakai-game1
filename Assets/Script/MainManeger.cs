using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;

public class MainManeger : MonoBehaviour
{
    [SerializeField, Header("�Q�[���I�[�o�[UI")]
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
    {   //�unull�v�ϐ������������Ă��Ȃ����
        //_move��GameObject���Ȃ��Ȃ����Ƃ��Ɏ��s�����
        if (_move != null) return;

        _gameOverUI.SetActive(true);
    }
}
