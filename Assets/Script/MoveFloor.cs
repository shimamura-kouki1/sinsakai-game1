using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private Rigidbody2D _rig;
    private float _elapsedTime;
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

        transform.position = new Vector2(transform.position.x, Mathf.Sin(_elapsedTime) * 2f);
    }
}
