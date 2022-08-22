using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playercontrolle : MonoBehaviour
{
    [Header("移動スピード")]
    [Tooltip("移動スピード")] [SerializeField] float _moveSpeed;
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
        float _moveX = Input.GetAxisRaw("Horizontal1");
        float _moveY = Input.GetAxisRaw("Vertical1");
        _dir = new Vector3(_moveX, _moveY, 0);
    }
    void Hit()
    {
        if(_hp <= 0)
        {
            _gameoverText.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "弾のタグ名")
        {
            _hp--;
        }
    }
    private void OnDisable()
    {
        _rb.velocity = Vector3.zero;
    }
}
