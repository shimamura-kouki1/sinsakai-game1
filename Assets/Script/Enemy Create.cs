using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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
            Instantiate(obj, new Vector3(-3.71f, -1.94f, 0.0f), Quaternion.identity);
        }
       
    }
}
