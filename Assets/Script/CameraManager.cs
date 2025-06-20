using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 _Pos;

    private Player _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _FollowPlayer();
    }

    private void _FollowPlayer()

    {   //プレイヤーのX座標をXに代入
        float x = _player.transform.position.x;

        //ｘの値をカメラの初期位置から無限の間に制限
        x = Mathf.Clamp(x,_Pos.x,Mathf.Infinity);

        //x以外は位置が変わらないようにしている
        transform.position = new Vector3(x,transform.position.y,transform.position.z);
    }
}
