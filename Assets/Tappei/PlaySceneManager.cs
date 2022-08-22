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
        Fire,
    }

    /// <summary>�v���C���[1�̈ړ��𐧌䂷��X�N���v�g</summary>
    [SerializeField] Controller _player1MoveController;
    /// <summary>�v���C���[1�̍U���𐧌䂷��X�N���v�g</summary>
    [SerializeField] Fire _player1FireController;
    /// <summary>�v���C���[2�̈ړ��𐧌䂷��X�N���v�g</summary>
    [SerializeField] Controller _player2MoveController;
    /// <summary>�v���C���[2�̍U���𐧌䂷��X�N���v�g</summary>
    [SerializeField] Fire _player2FireController;

    /// <summary>���݂̏��</summary>
    GameState _currentState = GameState.Standby;

    IEnumerator Start()
    {
        // �Q�[���X�^�[�g�̃{�^���������ꂽ��
        yield return null;
    }

    void Update()
    {
        //switch (_currentState)
        //{
        //    case GameState.Standby:
        //        break;
        //    case GameState.Player1TurnStart:
        //        // �v���C���[1���e�����Ă�
        //        _player1FireController.enabled = true;
        //        // �v���C���[2��������
        //        _player1MoveController.enabled = true;
        //        // Player1�̃^�[����
        //        _currentState = GameState.Player1Turn;
        //        break;
        //    case GameState.Player1Turn:
        //        // �v���C���[1�͓����Ȃ��E�e�����ĂȂ�
        //        // �v���C���[2��������
        //        // ��e�A�������͒e���~�܂����玟��
        //        break;
        //    case GameState.Player1TurnEnd:
        //        // ���ʂ̔���A�v���C���[����e���Ă�����
        //    case GameState.Player2TurnStart:
        //        // Pleyer1
        //        // �v���C���[2���e�����Ă�
        //        // �v���C���[1��������
        //        break;
        //    case GameState.Player2Turn:
        //        // �v���C���[2�������Ȃ��E�e�����ĂȂ�
        //        // �v���C���[1��������
        //        // ��e�A�������͒e���~�܂����玟��
        //        break;
        //    case GameState.Player2TurnEnd:
        //        // ���ʂ̔���
        //        break;
        //    case GameState.TurnEnd:
        //        break;
        //}
    }

    /// <summary>�Q�[�����v���C��</summary>
    IEnumerator GamePlay()
    {
        while (true)
        {

            yield return new WaitUntil(() => _currentState == GameState.Fire);
        }
    }


}
