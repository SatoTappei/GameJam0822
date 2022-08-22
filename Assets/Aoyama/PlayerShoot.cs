using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("射撃を行うポイント")]
    Vector3[] _shootPositions;

    [SerializeField]
    [Tooltip("弾のプレハブ")]
    GameObject _bullet;

    [SerializeField]
    [Tooltip("射撃を行える回数")]
    int _shootLimit;

    [SerializeField]
    [Tooltip("射撃を行えるインターバル")]
    float _shootInterval;

    [SerializeField]
    [Tooltip("プレイヤー１かどうか")]
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
