using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̈ړ��̃e�X�g
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
            Debug.Log(gameObject.name + "���ړ����ł�");
        }
    }
}
