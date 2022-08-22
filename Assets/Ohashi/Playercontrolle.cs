using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontrolle : MonoBehaviour
{
    [Header("�ړ��X�s�[�h")]
    [Tooltip("�ړ��X�s�[�h")] [SerializeField] float _moveSpeed;
    [Header("player�̃q�b�g�|�C���g")]
    [Tooltip("player�̃q�b�g�|�C���g")] [SerializeField] int _hp = 2;

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
        Move();//�ړ��̓���
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
            SceneManager.LoadScene("result��ʂ�scene��");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "�e�̃^�O��")
        {
            _hp--;
        }
    }
}
