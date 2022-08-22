using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [Header("playerのヒットポイント")]
    [Tooltip("playerのヒットポイント")] [SerializeField] int _hp = 2;

    [SerializeField] Text _gameoverText;
    [SerializeField] Text _hpText;

    Vector3 _dir = new Vector3(0, 0, 0);
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = _dir.normalized * _moveSpeed;
    }
    void Update()
    {
        Move();//移動の入力
        Hit();
        _hpText.text = _hp.ToString();
    }
    void Move()
    {
        float _moveZ = Input.GetAxisRaw("Horizontal2");
        float _moveX = Input.GetAxisRaw("Vertical2");
        _dir = new Vector3(0, _moveX, _moveZ);
    }
    void Hit()
    {
        if (_hp <= 0)
        {
            _gameoverText.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "弾のタグ名")
        {
            _hp--;
        }
    }
    private void OnDisable()
    {
        _rb.velocity = Vector3.zero;
    }
}
