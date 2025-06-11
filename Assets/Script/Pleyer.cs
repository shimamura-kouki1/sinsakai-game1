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

        [SerializeField, Header("�̗�")]
            //������hp
        private int _hp;

        [SerializeField, Header("�ړ����x")]
        private float _Speed;

        [SerializeField, Header("�W�����v���x")]
        private float _jumpSpeed;

        private void Start()
        {
            Application.targetFrameRate = 60;

            _ri = GetComponent<Rigidbody2D>();

            isJumping = false;
        }

        private void Update()
        {       //hp�̒l�������Ă���̂����m�F����
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
                //����false��������jump�\�@
                if (isJumping == false)
                {
                    //Jump�̍���
                    _ri.velocity = new Vector2(0, 15);

                }
                //Jump��������true�ɂȂ�
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
                renderer.enabled = false; // �e�I�u�W�F�N�g���\��
            }
        }


        //Collision2D ->    �Փ˂����Ƃ��Ɏ��s
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                HitEnemy(collision.gameObject);
            }

            if (collision.gameObject.tag == ("ground"))
            {
                //false�̏ꍇJump���\�ɂ���
                isJumping = false;
            }

            if(collision.gameObject.tag == ("Goal"))
            {
                FindObjectOfType<MainManeger>().ShowGameClearUI();
                this.enabled = false;    //���̃X�N���v�g���A�N�e�B�u�ɂ���
               // GetComponent<>().enabled = false;
            }
            
        }

        private void HitEnemy(GameObject enemy)
        {       //haltScaleY��GameObject�̔����̍�������������
            float halfScaleY = transform.lossyScale.y / 2.0f;

                //enemyHalfScaleY��enemy�̔����̍�������������
            float enemyHalfScaleY = enemy.transform.lossyScale.y / 2.0f;

                //����playre�̈ʒu����playre�̔������ɉ������ʒu��enemy�̍��W���甼���̑傫�����������ʒu�����ゾ�����ꍇ
                //transform.position��playre�̂��傤�ǐ^�񒆂̈ʒu���w���Ă���
                //-0.1f�͂߂荞�񂾎��̍��W�̑Ώ����Ă���
            if (transform.position.y - (halfScaleY - 0.1f) >= enemy.transform.position.y + (enemyHalfScaleY - 0.1f))
            {
                MainManeger.score += 100; //score�̉��Z
                Destroy(enemy);

                //�����(Vector2.up)��new Vector2(0,5.5f)������������B
                //AddForce�Ƃ̓I�u�W�F�N�g�����������鏈���A�uForceMode2D�v�̐ݒ�ŉ����̎d�����ς��
                //�uForceMode2D�v��2��ނ���A�uForce�v�͏������x���A���X�ɉ������Ă��������E�uimpulse�v�͏����������A���X�Ɍ������Ă�������

                _ri.AddForce(Vector2.up * new Vector2(0,15f),ForceMode2D.Impulse);
            }
                //if���ȊO�̏ꏊ�ŐڐG�����ꍇ��������
            else
            {
                //Enemyobuject����PlayerDamage���\�b�h���Ă΂��B
                //(this)�Ƃ͎����̃N���X��ϐ��Ƃ��Ďg���B�����Move�N���X�����Ă���
                enemy.GetComponent<Enemy>().PlayerDamage(this);
            
            }


        }

        private void _Dead()
        {       //hp���O�ȉ��ɂȂ����珈��
            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void Damage(int damage)//
        {   
            //Mathf.Max()�Ƃ�()���̂ɓ��ꂽ�Q�̒l�̂�������傫���ق���ϐ��ɓ���鏈��
            //_hp��_hp����damage�����������������Ă����B()�̒���0�������Ă���̂�0�ȉ��̐������\������Ȃ��悤�ɂ��Ă���B
            _hp = Mathf.Max(_hp - damage,0);

            _Dead();
        }

    }


    /*float horizontal = Input.GetAxis("Horizntal");
     _ri.AddForce(transform.right * horizontal * _power * Time.deltaTime, ForceMode2D.Impulse);*/


    //�u||�v�Ƃ́u�`�܂��́`�v�Ƃ��������ݒ�Ɏg���@�@if(A||B)->A�܂���B�̏����ɂȂ����Ƃ��ɏ��������s����
    //�u&&�v�Ƃ́u�`���`�v�Ƃ��������ݒ�Ɏg���@�@�@if(A&&B)->A����B�̏����ɂȂ����Ƃ��ɏ��������s����

}

