using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    private float _moveSpeed;

    [SerializeField, Header("�U����")]
    //enemy�̍U���͂����邽�߂̕ϐ�
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
            //Move�̒��ɂ���Damage�̃��b�\�h�������Ă��āA�����̒��Ɏ����̍U���͂�����
        move.Damage(_attackPower);
    }
}
