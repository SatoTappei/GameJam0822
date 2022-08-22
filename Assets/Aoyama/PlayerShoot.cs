using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("射撃を行う距離")]
    float _shootPosLength = 10;

    [SerializeField]
    [Tooltip("弾のプレハブ")]
    GameObject _bullet;

    [SerializeField]
    [Tooltip("プレイヤー１かどうか")]
    bool _isPlayer1;
    
    [SerializeField]
    [Tooltip("射撃を行える回数")]
    int _shootLimit = 0;

    [SerializeField]
    [Tooltip("射撃を行える回数を表示するText")]
    Text _bulletText;

    [Tooltip("射撃を行った回数")]
    int _shootCount;

    [Tooltip("射撃時のSE")]
    AudioSource _audio;

    Vector3 _shootPos;
    
    LineRenderer _line;


    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _audio = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        _shootCount = 0;
        _shootLimit++;

        if (_line)
        {
            _line.enabled = true;
        }

        if (_isPlayer1)
        {
            _bulletText.text = _shootLimit.ToString();
        }
    }


    private void OnDisable()
    {
        _line.enabled = false;

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        bullets.ToList().ForEach(b => Destroy(b));
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

        if (_isShoot && _shootCount < _shootLimit)
        {
            _audio.Play();
            _shootCount++;
            Instantiate(_bullet, _shootPos + transform.position, transform.rotation);
        }
    }
}
