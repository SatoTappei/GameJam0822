using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ˌ����s������")]
    float _shootPosLength = 10;

    [SerializeField]
    [Tooltip("�e�̃v���n�u")]
    GameObject _bullet;


    [SerializeField]
    [Tooltip("�v���C���[�P���ǂ���")]
    bool _isPlayer1;

    [Tooltip("�ˌ����s�����")]
    int _shootLimit;

    [Tooltip("�ˌ����s������")]
    int _shootCount;
    
    public Vector3 _shootPos;
    
    LineRenderer _line;


    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }


    private void OnEnable()
    {
        _shootCount = 0;
        _shootLimit++;

        _line.enabled = true;
    }


    private void OnDisable()
    {
        _line.enabled = false;    
    }


    private void Update()
    {
        Shoot();

        ShootPosChange();

        transform.up = _shootPos;
    }


    private void ShootPosChange()
    {
        float x;
        float y;

        if (_isPlayer1)
        {
            x = Input.GetAxisRaw("Horizontal1");
            y = Input.GetAxisRaw("Vertical1");

            Mathf.Abs(_shootPosLength);

            _shootPos = new Vector3(_shootPosLength, y * _shootPosLength, x * _shootPosLength);
        }
        else
        {
            x = Input.GetAxisRaw("Horizontal2");
            y = Input.GetAxisRaw("Vertical2");

            _shootPos = new Vector3(-_shootPosLength, y * _shootPosLength, x * _shootPosLength);
        }


        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, _shootPos + transform.position);
    }


    private void Shoot()
    {
        bool _isShoot;
        
        if (_isPlayer1)
        {
            _isShoot = Input.GetKeyDown(KeyCode.LeftShift);
        }
        else
        {
            _isShoot = Input.GetKeyDown(KeyCode.RightShift);
        }

        if (_isShoot && _shootCount <= _shootLimit)
        {
            _shootCount++;
            Instantiate(_bullet, _shootPos, transform.rotation);
        }
    }
}
