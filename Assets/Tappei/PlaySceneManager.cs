using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム本編の進行を管理・制御する
/// </summary>
public class PlaySceneManager : MonoBehaviour
{
    /// <summary>ゲーム中の状態を表す</summary>
    enum GameState
    {
        Standby,
        Play,
        Result,
    }

    /// <summary>プレイヤー1の移動を制御するスクリプト</summary>
    [SerializeField] Playercontrolle _player1MoveController;
    /// <summary>プレイヤー1の攻撃を制御するスクリプト</summary>
    [SerializeField] PlayerShoot _player1FireController;
    /// <summary>プレイヤー2の移動を制御するスクリプト</summary>
    [SerializeField] PlayerController2 _player2MoveController;
    /// <summary>プレイヤー2の攻撃を制御するスクリプト</summary>
    [SerializeField] PlayerShoot _player2FireController;
    /// <summary>ターンのリミット</summary>
    [SerializeField] float _turnLimit;
    /// <summary>現在の状態</summary>
    GameState _currentState = GameState.Standby;

    /// <summary>ゲームプレイに移行</summary>
    public void TransitionGamePlay() => _currentState = GameState.Play;
    /// <summary>リザルトに移行</summary>
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
                // タイトル中
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
                // ゲームのリザルト
            break;

        }
    }
}
