﻿// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/08 00:02
// @version: 1.0
// @description:
// *****************************************************************************

using DG.Tweening;
using Tsuki.Base;
using Tsuki.Managers;
using UnityEngine;

namespace Tsuki.Entities.AutoWall
{
    public enum WallType
    {
        A,
        B,
        C,
        D
    }

    public enum HandleType
    {
        None = 0,
        A = 1,
        B = 2,
        C = 3,
        D = 4
    }

    public class AutoWall : MonoBehaviour
    {
        public WallType wallType;
        private bool _allowShow;
        private BoxCollider2D _boxCollider2D;
        private Tween _hideTween;

        private Transform _spriteTrans;
        private Vector3 _startPos;

        private void Start()
        {
            _spriteTrans = transform.Find("Sprite");
            _startPos = _spriteTrans.position;
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _allowShow = true;
        }

        private void OnEnable()
        {
            switch (wallType)
            {
                case WallType.A:
                case WallType.B:
                    ModelsManager.Instance.PlayerMod.onStepChanged.AddListener(
                        HandleDisplay);
                    break;
                case WallType.C:
                case WallType.D:
                    ModelsManager.Instance.PlayerMod.onStepChanged.AddListener(
                        HandleDisplayReverse);
                    break;
                default:
                    DebugYumihoshi.Error<AutoWall>("自动墙", "自动墙类型错误");
                    break;
            }
        }

        private void OnDisable()
        {
            switch (wallType)
            {
                case WallType.A:
                case WallType.B:
                    ModelsManager.Instance.PlayerMod.onStepChanged
                        .RemoveListener(
                            HandleDisplay);
                    break;
                case WallType.C:
                case WallType.D:
                    ModelsManager.Instance.PlayerMod.onStepChanged
                        .RemoveListener(
                            HandleDisplayReverse);
                    break;
                default:
                    DebugYumihoshi.Error<AutoWall>("自动墙", "自动墙类型错误");
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Box")) return;
            _allowShow = false;
        }

        private void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.CompareTag("Box")) return;
            _allowShow = true;
        }

        private HandleType GetHandleType(int leftStep)
        {
            int costStep =
                ModelsManager.Instance.PlayerMod.GetCurrentLevelMaxStep() -
                leftStep;
            return (HandleType)(costStep % 4);
        }

        private void HandleDisplay(int leftStep, bool _)
        {
            if (!_allowShow) return;
            HandleType wwallType = GetHandleType(leftStep);

            switch (wwallType)
            {
                case HandleType.A:
                case HandleType.B:
                    HandleSprite(true);
                    _boxCollider2D.enabled = true;
                    break;
                case HandleType.C:
                case HandleType.D:
                    HandleSprite(false);
                    _boxCollider2D.enabled = false;
                    break;
                case HandleType.None:
                    break;
                default:
                    DebugYumihoshi.Error<AutoWall>("自动墙", "自动墙类型错误");
                    break;
            }
        }

        private void HandleDisplayReverse(int leftStep, bool _)
        {
            if (!_allowShow) return;
            HandleType wwallType = GetHandleType(leftStep);

            switch (wwallType)
            {
                case HandleType.C:
                case HandleType.D:
                    HandleSprite(true);
                    _boxCollider2D.enabled = true;
                    break;
                case HandleType.A:
                case HandleType.B:
                    HandleSprite(false);
                    _boxCollider2D.enabled = false;
                    break;
                case HandleType.None:
                    break;
                default:
                    DebugYumihoshi.Error<AutoWall>("自动墙", "自动墙类型错误");
                    break;
            }
        }

        private void HandleSprite(bool show)
        {
            _hideTween?.Complete();
            if (show)
            {
                _hideTween = _spriteTrans.DOMove(_startPos,
                    ModelsManager.Instance.PlayerMod.moveTime);
            }
            else
            {
                Vector3 targetPos = _startPos;
                targetPos.y -= 0.5f;
                _hideTween = _spriteTrans.DOMove(targetPos,
                    ModelsManager.Instance.PlayerMod.moveTime);
            }
        }
    }
}
