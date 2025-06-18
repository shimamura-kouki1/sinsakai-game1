using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField,Header("x")]private float x;
    [SerializeField,Header("y")] private float y;
    [SerializeField,Header("z")] private float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 120 == 0)
        {
            GameObject obj = (GameObject)Resources.Load("Enemy");
            Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
        }
       
    }
}
