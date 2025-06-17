using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyjup : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float _moveSpeed;

    [SerializeField, Header("UŒ‚—Í")]
    //enemy‚ÌUŒ‚—Í‚ğ“ü‚ê‚é‚½‚ß‚Ì•Ï”
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
        //_rig.velocity = new Vector2(Vector2.left.x * _moveSpeed * Time.deltaTime, _rig.velocity.y);

        transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time)*2);

        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
}
