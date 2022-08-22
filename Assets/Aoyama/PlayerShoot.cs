using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ˌ����s���|�C���g")]
    Vector3[] _shootPositions;

    [SerializeField]
    [Tooltip("�e�̃v���n�u")]
    GameObject _bullet;

    [SerializeField]
    [Tooltip("�ˌ����s�����")]
    int _shootLimit;

    [SerializeField]
    [Tooltip("�ˌ����s����C���^�[�o��")]
    float _shootInterval;

    [SerializeField]
    [Tooltip("�v���C���[�P���ǂ���")]
    bool _isPlayer1;

    int _shootCount;
    
    Vector3 _shootPos;
    
    float _timer;


    private void OnEnable()
    {
        _shootCount = 0;
    }


    private void Update()
    {
        Shoot();
    }


    private void ShootPosChange()
    {
        float x;
        float y;

        if (_isPlayer1)
        {
            x = Input.GetAxisRaw("Horizontal1");
            y = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            x = Input.GetAxisRaw("Horizontal2");
            y = Input.GetAxisRaw("Vertical2");
        }
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

        if (_isShoot)
        {
            _shootCount++;
            Instantiate(_bullet, _shootPos, transform.rotation);
        }
    }
}
