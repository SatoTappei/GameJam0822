using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̑��x")]
    float _bulletSpeed;

    [Tooltip("�e�̑��x")]
    AudioSource _audio;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();

        BulletMove();
    }


    /// <summary>�e�̓������Ǘ����郁�\�b�h</summary>
    private void BulletMove()
    {  
        _rb.velocity = transform.up * _bulletSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.7f);
        }

        _audio.Play();
    }
}
