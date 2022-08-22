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
        Fire,
    }

    /// <summary>プレイヤー1の移動を制御するスクリプト</summary>
    [SerializeField] Controller _player1MoveController;
    /// <summary>プレイヤー1の攻撃を制御するスクリプト</summary>
    [SerializeField] Fire _player1FireController;
    /// <summary>プレイヤー2の移動を制御するスクリプト</summary>
    [SerializeField] Controller _player2MoveController;
    /// <summary>プレイヤー2の攻撃を制御するスクリプト</summary>
    [SerializeField] Fire _player2FireController;

    /// <summary>現在の状態</summary>
    GameState _currentState = GameState.Standby;

    IEnumerator Start()
    {
        // ゲームスタートのボタンが押されたら
        yield return null;
    }

    void Update()
    {
        //switch (_currentState)
        //{
        //    case GameState.Standby:
        //        break;
        //    case GameState.Player1TurnStart:
        //        // プレイヤー1が弾を撃てる
        //        _player1FireController.enabled = true;
        //        // プレイヤー2が動ける
        //        _player1MoveController.enabled = true;
        //        // Player1のターンへ
        //        _currentState = GameState.Player1Turn;
        //        break;
        //    case GameState.Player1Turn:
        //        // プレイヤー1は動けない・弾を撃てない
        //        // プレイヤー2が動ける
        //        // 被弾、もしくは弾が止まったら次へ
        //        break;
        //    case GameState.Player1TurnEnd:
        //        // 結果の判定、プレイヤーが被弾していたら
        //    case GameState.Player2TurnStart:
        //        // Pleyer1
        //        // プレイヤー2が弾を撃てる
        //        // プレイヤー1が動ける
        //        break;
        //    case GameState.Player2Turn:
        //        // プレイヤー2が動けない・弾を撃てない
        //        // プレイヤー1が動ける
        //        // 被弾、もしくは弾が止まったら次へ
        //        break;
        //    case GameState.Player2TurnEnd:
        //        // 結果の判定
        //        break;
        //    case GameState.TurnEnd:
        //        break;
        //}
    }

    /// <summary>ゲームをプレイ中</summary>
    IEnumerator GamePlay()
    {
        while (true)
        {

            yield return new WaitUntil(() => _currentState == GameState.Fire);
        }
    }


}
