using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using static System.Object;
using UnityEngine.InputSystem;


namespace Text.Inheritance
{

    public class Player : MonoBehaviour
    {
        Rigidbody2D _rb;

        [SerializeField, Header("体力")]
        private int _hp;    //整数のhp

        //移動関係
        [SerializeField, Header("移動速度")]
        private int _Speed;
        private Vector2 _inputDirection;

        //ジャンプ関係
        [SerializeField, Header("ジャンプ高さ")]
        private float _jumpHeight;
       
        private bool _isJumping = true;
        public AudioClip jumpSound;             // ← ジャンプ音をインスペクターで指定
        private AudioSource _audioSource;        // 音を鳴らす装置
        [SerializeField, Header("エネミーヒットジャンプ")]
        private float _EnemyHitJumpHeight;

        //コインの取得音
        public AudioClip CoinSound;
        //エネミーを踏んだ時の音
        public AudioClip EnemySound;

        //アニメーション
        private Animator _anime;


        
        private void Start()
        {  
            _rb = GetComponent<Rigidbody2D>();

            _audioSource = GetComponent<AudioSource>();

            _anime = GetComponent<Animator>();
        }

        private void Update()
        {       //hpの値が減っているのかを確認する
            Debug.Log(_hp);

            if (transform.position.y < -15)     //-15以下の座標に落ちたらゲームオーバー
            {
                Destroy(gameObject);
            }

        }

        void FixedUpdate()      //FixedUpdateで更新すると物理処理とぴったり合って、カクつかないらしい
        {
            Move();
        }

        public void Move()
        {
            _rb.velocity = new Vector2(_inputDirection.x * _Speed, _rb.velocity.y);     //_OnMoveで代入した_inputDirection.xを_Speedにかけることで左右移動ができる
            //transform.rotation = Quaternion.Euler(0,180,0);                           アニメーションの反転

            if (Time.timeScale == 0f)
            {
                return;
            }
            _anime.SetBool("Walk", _inputDirection.x != 0.0f);          //指定したパラメーターのBool値を変更するもの,SetBool(変更したいパラメータ,変更したい値)
                                                                        //今回は横方向の値が0じゃない場合trueになる。つまり、動いているときにtrueになる
        }

        public void OnMove(InputAction.CallbackContext context)        //InputAction.CallbackContextはInput Systemで発生したイベントを取得するためのもの
        {
            _inputDirection = context.ReadValue<Vector2>();             //contextをVector2型に変換した値を_inputDirectionに代入している　
                                                                        //つまり、右入力なら（1,0）左入力なら（-1,0）を代入している
        }

        public void OnJump(InputAction.CallbackContext context)         //このメソッドはイベント駆動のためイベントが起きると自動的に呼び出してくれる。よってupdetoに入れなくても動く
        {
            if (!context.performed || !_isJumping) 
            {
                return; 
            }

            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
            _isJumping = false;                          //Jumpをしたらfalseになる
            _anime.SetBool("Jump",!_isJumping);         //ジャンプアニメーション
            _audioSource.PlayOneShot(jumpSound);
        }
        
        private void OnCollisionEnter2D(Collision2D collision)      //Collision2D ->    衝突したときに実行
        {
            if(collision.gameObject.tag == "Enemy")     
            {
                HitEnemy(collision.gameObject);
            }

            if (collision.gameObject.tag == ("ground"))
            {
                //falseの場合Jumpを可能にする
                _isJumping = true;
                _anime.SetBool("Jump",!_isJumping);     //ジャンプアニメーション
            }

            if(collision.gameObject.tag == ("Goal"))
            {
                FindObjectOfType<MainManeger>().ShowGameClearUI();
                this.enabled = false;    //このゲームオブジェクトを非アクティブにする
            }
        }

        private void OnTriggerEnter2D (Collider2D collider)//オブジェクトがすり抜けた時の処理
        {

            if (collider.gameObject.tag == ("Coin"))           //Coinをすり抜けたら
            {
                FindObjectOfType<MainManeger>().Score();     //MainManegerからScoreを探し出す
                MainManeger.score += 100;                    //scoreに100加算する
            } 
            
            if (CoinSound != null)
      　    {
                _audioSource.PlayOneShot(CoinSound,1f);
                 Destroy(collider.gameObject);              //接触しているゲームオブジェクトを破壊
            }
        }
        /// <summary>
        /// Enemyに接触した時の処理
        /// </summary>
        /// <param name="enemy"></param>
        private void HitEnemy(GameObject enemy)
        {       
            float halfScaleY = transform.lossyScale.y / 2.0f;       //haltScaleYにGameObjectの半分の高さが代入される
            
            float enemyHalfScaleY = enemy.transform.lossyScale.y / 2.0f;        //enemyHalfScaleYにenemyの半分の高さが代入される

            if (transform.position.y - (halfScaleY - 0.1f) >= enemy.transform.position.y + (enemyHalfScaleY - 0.1f))    //playreの中心位置からplayreの半分の高さを下げた位置がenemyの中心位置から半分の高さ分あげた位置よりも上のところが接触
                                                                                                                        //transform.positionはplayreのちょうど真ん中の位置を指している
                                                                                                                        //-0.1fはめり込んだ時の座標の対処している
            {
                MainManeger.score += 100;                       //scoreの加算
                _audioSource.PlayOneShot(EnemySound, 1f);        //エネミーをを踏んだ時の音
                Destroy(enemy);

                //上方向(Vector2.up)にnew Vector2(0,5.5f)分加速させる。
                //AddForceとはオブジェクトを加速させる処理、「ForceMode2D」の設定で加速の仕方が変わる
                //「ForceMode2D」は2種類あり、「Force」は初速が遅く、徐々に加速していく処理・「impulse」は初速が早く、徐々に減速していく処理

                _rb.AddForce(Vector2.up * new Vector2(0, _EnemyHitJumpHeight),ForceMode2D.Impulse);
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
        {       
            if(_hp <= 0)        //hpが０以下になったら処理
            {
                Destroy(gameObject);
            }
        }

        public void Damage(int damage)
        {   
            _hp = Mathf.Max(_hp - damage,0);        //Mathf.Max()とは()内のに入れた２つの値のうちから大きいほうを変数に入れる処理
                                                    //_hpに_hpからdamageを引いた数を代入していく。()の中に0が入っているのは0以下の数字が表示されないようにしている。
            _Dead();
        }
    }


    /*float horizontal = Input.GetAxis("Horizntal");
     _ri.AddForce(transform.right * horizontal * _power * Time.deltaTime, ForceMode2D.Impulse);*/


    //「||」とは「～または～」という条件設定に使う　　if(A||B)->AまたはBの条件になったときに処理を実行する
    //「&&」とは「～かつ～」という条件設定に使う　　　if(A&&B)->AかつBの条件になったときに処理を実行する　　　また、短絡評価であり、左辺の条件に会わなかったらその時点で右辺の条件を検証せずにfalseになる

}

