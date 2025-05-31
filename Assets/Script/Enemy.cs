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
        _Move();
    }

    private void _Move()
    {
        _rig.velocity = new Vector2(Vector2.left.x * _moveSpeed, _rig.velocity.y);
    }

    public void PlayerDamage(Move move)
    {
            //Moveの中にあるDamageのメッソドを持ってきて、引数の中に自分の攻撃力を入れる
        move.Damage(_attackPower);
    }
}
