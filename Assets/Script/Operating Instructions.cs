using System.Collections;
using System.Collections.Generic;
using Text.Inheritance;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class OperatingInstructions : MonoBehaviour
{
    public GameObject OperatingPanel;
    public CanvasGroup canvasGroup;

    public Transform Player;

    public Vector3 center = new Vector3(-13, -2, 0);

    public Vector3 size = new Vector3 (5, 5, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        farstPanel();
    }

    public void farstPanel()
    {
        if (Player == null)
        {
            return; // プレイヤーが存在しないなら何もしない
        }

        Vector3 pos = Player.position;
        Vector3 min = center - size * 0.5f;     //中心点から左側の座標の最少点
        Vector3 max = center + size * 0.5f;     //中心点から右側の最大点

        bool inZone = (pos.x >= min.x && pos.x <= max.x) &&             //プレイヤーがX,Yのすべての範囲に入っているかを判定する。
                     (pos.y >= min.y && pos.y <= max.y) &&
                     (pos.z >= min.z && pos.z <= max.z);

        OperatingPanel.SetActive(inZone);       //inZoneがtrueならPanelを表示、farseなら非表示
    }
}
