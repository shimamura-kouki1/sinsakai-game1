using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using static System.Object;


namespace Text.Inheritance
{

    public class Player : MonoBehaviour
    {
        public bool isJumping;
        //[SerializeField] float _power = 5f;
        Rigidbody2D _ri;

        [SerializeField, Header("体力")]
            //整数のhp
        private int _hp;

        [SerializeField, Header("移動速度")]
        private float _Speed;

        [SerializeField, Header("ジャンプ速度")]
        private float _jumpSpeed;

        private void Start()
        {
            Application.targetFrameRate = 60;

            _ri = GetComponent<Rigidbody2D>();

            isJumping = false;
        }

        private void Update()
        {       //hpの値が減っているのかを確認する
            Debug.Log(_hp);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 pos = transform.position;
                pos.x += _Speed;
                transform.position = pos;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector2 pos = transform.position;
                pos.x -= _Speed;
                transform.position = pos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                //もしfalseだったらjump可能　
                if (isJumping == false)
                {
                    //Jumpの高さ
                    _ri.velocity = new Vector2(0, 15);

                }
                //Jumpをしたらtrueになる
                isJumping = true;
            }

            /*if(Input.GetKey(KeyCode.E))
            {
                transform.position = new Vector3(0, 0,10);
            }*/

            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }

        }

        void HideParentOnly(GameObject parent)
        {
            Renderer renderer = parent.GetComponent<Renderer>();
            if (Input.GetKey(KeyCode.E))
            {
                renderer.enabled = false; // 親オブジェクトを非表示
            }
        }


        //Collision2D ->    衝突したときに実行
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                HitEnemy(collision.gameObject);
            }

            if (collision.gameObject.tag == ("ground"))
            {
                //falseの場合Jumpを可能にする
                isJumping = false;
            }

            if(collision.gameObject.tag == ("Goal"))
            {
                FindObjectOfType<MainManeger>().ShowGameClearUI();
                this.enabled = false;    //このスクリプトを非アクティブにする
               // GetComponent<>().enabled = false;
            }
            
        }

        private void HitEnemy(GameObject enemy)
        {       //haltScaleYにGameObjectの半分の高さが代入される
            float halfScaleY = transform.lossyScale.y / 2.0f;

                //enemyHalfScaleYにenemyの半分の高さが代入される
            float enemyHalfScaleY = enemy.transform.lossyScale.y / 2.0f;

                //もしplayreの位置からplayreの半分下に下げた位置がenemyの座標から半分の大きさ分あげた位置よりも上だった場合
                //transform.positionはplayreのちょうど真ん中の位置を指している
                //-0.1fはめり込んだ時の座標の対処している
            if (transform.position.y - (halfScaleY - 0.1f) >= enemy.transform.position.y + (enemyHalfScaleY - 0.1f))
            {
                MainManeger.score += 100; //scoreの加算
                Destroy(enemy);

                //上方向(Vector2.up)にnew Vector2(0,5.5f)分加速させる。
                //AddForceとはオブジェクトを加速させる処理、「ForceMode2D」の設定で加速の仕方が変わる
                //「ForceMode2D」は2種類あり、「Force」は初速が遅く、徐々に加速していく処理・「impulse」は初速が早く、徐々に減速していく処理

                _ri.AddForce(Vector2.up * new Vector2(0,15f),ForceMode2D.Impulse);
            }
                //if文以外の場所で接触した場合処理する
            else
            {
                //EnemyobujectからPlayerDamageメソッドが呼ばれる。
                //(this)とは自分のクラスを変数として使う。今回はMoveクラスを入れている
                enemy.GetComponent<Enemy>().PlayerDamage(this);
            
            }


        }

        private void _Dead()
        {       //hpが０以下になったら処理
            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void Damage(int damage)//
        {   
            //Mathf.Max()とは()内のに入れた２つの値のうちから大きいほうを変数に入れる処理
            //_hpに_hpからdamageを引いた数を代入していく。()の中に0が入っているのは0以下の数字が表示されないようにしている。
            _hp = Mathf.Max(_hp - damage,0);

            _Dead();
        }

    }


    /*float horizontal = Input.GetAxis("Horizntal");
     _ri.AddForce(transform.right * horizontal * _power * Time.deltaTime, ForceMode2D.Impulse);*/


    //「||」とは「～または～」という条件設定に使う　　if(A||B)->AまたはBの条件になったときに処理を実行する
    //「&&」とは「～かつ～」という条件設定に使う　　　if(A&&B)->AかつBの条件になったときに処理を実行する

}

