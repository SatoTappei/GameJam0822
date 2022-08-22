using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の速度")]
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


    /// <summary>弾の動きを管理するメソッド</summary>
    private void BulletMove()
    {  
        _rb.velocity = transform.up * _bulletSpeed;
    }


    /// <summary>弾の破壊を管理するメソッド</summary>
    private void BulletDestroy()
    {
        
    }

}
