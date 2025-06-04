using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    Rigidbody2D _ri;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        _ri = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.zero;
    }
}
