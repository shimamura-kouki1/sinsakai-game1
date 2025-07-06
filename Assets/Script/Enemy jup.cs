using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyjup : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float _moveSpeed;

    [SerializeField, Header("攻撃力")]
    //enemyの攻撃力を入れるための変数
    private int _attackPower;

    private Rigidbody2D _rig;
    private float _elapsedTime;

    [SerializeField, Header("動きの位相ずれ")]
    private float _phaseOffset; //タイミングのずれ
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        _elapsedTime += Time.fixedDeltaTime;

        transform.position = new Vector2(transform.position.x, Mathf.Sin(_elapsedTime + _phaseOffset) * 2f);
    }
}
