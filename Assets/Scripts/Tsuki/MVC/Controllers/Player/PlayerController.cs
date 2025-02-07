﻿// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/27 19:01
// @version: 1.0
// @description:
// *****************************************************************************

using Tsuki.Interface;
using Tsuki.Managers;
using Tsuki.MVC.Views.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Tsuki.MVC.Controllers.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public PlayerView playerView;
        public LayerMask wallLayer;
        public LayerMask grassLayer;
        private bool _moveable = true;

        private PlayerMoveHandler _moveHandler;

        private void Awake()
        {
            // MVC 初始化
            playerView = GetComponent<PlayerView>();
            // 初始化处理器
            _moveHandler = new PlayerMoveHandler(this);
        }

        private void OnEnable()
        {
            // 注册事件
            GameManager.Instance.RegisterEvent(GameManagerEventType.OnGamePause,
                (_moveHandler as IPauseable).Pause);
            GameManager.Instance.RegisterEvent(
                GameManagerEventType.OnGameResume,
                (_moveHandler as IPauseable).Resume);
            GameManager.Instance.RegisterEvent(
                GameManagerEventType.OnGameUndo,
                (_moveHandler as IUndoable).Undo);
            GameManager.Instance.RegisterEvent(
                GameManagerEventType.BeforeGameReload,
                () => { _moveable = false; }
            );
            SceneManager.sceneLoaded += (_, _) => { _moveable = true; };
        }

        private void OnDisable()
        {
            // 注销事件
            GameManager.Instance.UnregisterEvent(
                GameManagerEventType.OnGamePause,
                (_moveHandler as IPauseable).Pause);
            GameManager.Instance.UnregisterEvent(
                GameManagerEventType.OnGameResume,
                (_moveHandler as IPauseable).Resume);
            GameManager.Instance.UnregisterEvent(
                GameManagerEventType.OnGameUndo,
                (_moveHandler as IUndoable).Undo);
        }

        public void OnMove(InputValue context)
        {
            if (!_moveable || !GameManager.Instance.AllowLoadGame) return;
            _moveHandler.GetLineMovable(out bool moveX, out bool moveY);
            _moveHandler.Move(context.Get<Vector2>(), moveX, moveY);
        }
    }
}
