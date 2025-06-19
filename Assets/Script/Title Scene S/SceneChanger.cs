using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()//タイトルシーンへ移動
    {
        {
            // "GameScene" は遷移先のシーン名
            SceneManager.LoadScene("Stage1");
        }
    }
     //if (Input.GetKey(KeyCode.E))
}
