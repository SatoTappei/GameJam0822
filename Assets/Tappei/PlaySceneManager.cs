using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���{�҂̐i�s���Ǘ��E���䂷��
/// </summary>
public class PlaySceneManager : MonoBehaviour
{
    /// <summary>�Q�[�����̏�Ԃ�\��</summary>
    enum GameState
    {
        Standby,
        Play,
        Result,
    }

    /// <summary>�v���C���[1�̈ړ��𐧌䂷��X�N���v�g</summary>
    [SerializeField] Playercontrolle _player1MoveController;
    /// <summary>�v���C���[1�̍U���𐧌䂷��X�N���v�g</summary>
    [SerializeField] PlayerShoot _player1FireController;
    /// <summary>�v���C���[2�̈ړ��𐧌䂷��X�N���v�g</summary>
    [SerializeField] PlayerController2 _player2MoveController;
    /// <summary>�v���C���[2�̍U���𐧌䂷��X�N���v�g</summary>
    [SerializeField] PlayerShoot _player2FireController;
    /// <summary>�^�[���̃��~�b�g</summary>
    [SerializeField] float _turnLimit;
    /// <summary>���݂̏��</summary>
    GameState _currentState = GameState.Standby;

    /// <summary>�Q�[���v���C�Ɉڍs</summary>
    public void TransitionGamePlay() => _currentState = GameState.Play;
    /// <summary>���U���g�Ɉڍs</summary>
    public void TransitionResult() => _currentState = GameState.Result;

    float _timer;

    void Start()
    {
        _player1MoveController.enabled = false;
        _player2FireController.enabled = false;
        _currentState = GameState.Play;
    }

    void Update()
    {
        switch (_currentState)
        {
            case GameState.Standby:
                // �^�C�g����
            break;
            case GameState.Play:
                _timer += Time.deltaTime;
                if (_timer > _turnLimit)
                {
                    _timer = 0;
                    _player1MoveController.enabled = !_player1MoveController.enabled;
                    _player2MoveController.enabled = !_player2MoveController.enabled;
                    _player1FireController.enabled = !_player1FireController.enabled;
                    _player2FireController.enabled = !_player2FireController.enabled;
                }
                break;
            case GameState.Result:
                // �Q�[���̃��U���g
            break;

        }
    }
}
