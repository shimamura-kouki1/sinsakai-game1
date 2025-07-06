using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField,Header("x")]private float x;
    [SerializeField,Header("y")] private float y;
    [SerializeField,Header("z")] private float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if(Time.timeScale > 0f && Time.frameCount % 120  == 0)           //タイムスケールが０よりも大きい時かつ、120フレームレートごとに実行する
        {　
           
            GameObject obj = (GameObject)Resources.Load("Enemy");        //ResourcesからEnemyをobjに代入し

           
            Instantiate(obj, new Vector3(x, y, z), Quaternion.identity); //Instantiateでオブジェクト生成し引数に（prefab,スポーン座標,回転つまり角度？）
        }
    }
}
