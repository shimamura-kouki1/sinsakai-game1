using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Score : MonoBehaviour
{
    TextMeshPro _textMeshPro;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }
  

    // Update is called once per frame
    void Update()
    {
        _textMeshPro.text= ("Score" + score);
    }
}
