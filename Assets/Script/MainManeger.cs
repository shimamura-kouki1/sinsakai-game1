using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManeger : MonoBehaviour
{
    [SerializeField, Header("�X�R�A")]
    private TextMeshProUGUI _textText;
    public static int score = 0;

    [SerializeField, Header("�Q�[���I�[�o�[UI")]
    private GameObject _gameOverUI;

    [SerializeField, Header("�Q�[���N���AUI")]
    private GameObject _gameClearUI;

    [SerializeField,Header("ReStart")]
    private GameObject reStartButton;

    [SerializeField,Header("�|�[�Y���")]
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
    {�@�@//���Z�����X�R�A��Pleyer��124�s��
        _textText.text = ("Score" + score);
    }

    private void _ShowGameOverUI()
    {
        //_player��GameObject��null�̎��Ɏ��s�����
        if (_player != null)
        {
            return;
        }
        //gameOverUI���L���ɂȂ�
        _gameOverUI.SetActive(true); //SetActive = �Q�[���I�u�W�F�N�g�̗L���E������؂�ւ���
    }

    public void ShowGameClearUI()//Player�X�N���v�g103�s��
    {�@ //���ɓ����@�@
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
