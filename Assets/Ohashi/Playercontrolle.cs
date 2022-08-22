using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrolle : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
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
        float _moveZ = Input.GetAxisRaw("Horizontal1");
        float _moveX = Input.GetAxisRaw("Vertical1");
        _dir = new Vector3(0, _moveX, _moveZ);

    }
}
