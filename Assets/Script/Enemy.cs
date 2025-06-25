using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float _moveSpeed;

    [SerializeField, Header("攻撃力")]
    //enemyの攻撃力を入れるための変数
    private int _attackPower;

    private Rigidbody2D _rig;

    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rig.velocity = new Vector2(Vector2.left.x * _moveSpeed * Time.timeScale, _rig.velocity.y);
   
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
        //float sin = Mathf.Sin(Time.time);
        //this.transform.position = new Vector3(0, sin, 0);  *Time.deltaTime
    }


    public void PlayerDamage(Player player)
    {
        player.Damage(_attackPower);        //Playerの中にあるDamageのメッソドを持ってきて、引数の中に自分の攻撃力を入れる
    }
}
