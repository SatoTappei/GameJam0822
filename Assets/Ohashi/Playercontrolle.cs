using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontrolle : MonoBehaviour
{
    [Header("移動スピード")]
    [Tooltip("移動スピード")] [SerializeField] float _moveSpeed;
    [Header("playerのヒットポイント")]
    [Tooltip("playerのヒットポイント")] [SerializeField] int _hp = 2;

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
    }
    void Move()
    {
        float _moveZ = Input.GetAxisRaw("Horizontal1");
        float _moveX = Input.GetAxisRaw("Vertical1");
        _dir = new Vector3(0, _moveX, _moveZ);
    }
    void Hit()
    {
        if(_hp <= 0)
        {
            SceneManager.LoadScene("result画面のscene名");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "弾のタグ名")
        {
            _hp--;
        }
    }
}
