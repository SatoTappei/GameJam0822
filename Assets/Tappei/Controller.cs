using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動のテスト
/// </summary>
public class Controller : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        if (vert != 0 || hori != 0)
        {
            Debug.Log(gameObject.name + "が移動中です");
        }
    }
}
