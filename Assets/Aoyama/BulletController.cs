using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̑��x")]
    float _bulletSpeed;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        BulletMove();
    }


    private void Update()
    {
        BulletDestroy();
    }


    /// <summary>�e�̓������Ǘ����郁�\�b�h</summary>
    private void BulletMove()
    {  
        _rb.velocity = transform.up * _bulletSpeed;
    }


    /// <summary>�e�̔j����Ǘ����郁�\�b�h</summary>
    private void BulletDestroy()
    {
        
    }

}
