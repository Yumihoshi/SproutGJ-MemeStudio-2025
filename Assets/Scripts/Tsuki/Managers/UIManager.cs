﻿// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/30 00:01
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using DG.Tweening;
using TMPro;
using Tsuki.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Tsuki.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("暂停UI预制体")] public GameObject pausePanel;

        [Header("渐变时间")] public float stepFadeTime;
        public float stepChangeFadeTime;

        private TextMeshProUGUI _stepText;
        private TextMeshProUGUI _addStepText;
        private TextMeshProUGUI _reduceStepText;

        private GameObject _pausePanel;
        private Color _addStepOriginColor;
        private Color _reduceStepOriginColor;
        private Color _addStepTargetColor;
        private Color _reduceStepTargetColor;

        private void Start()
        {
            // 获取组件
            _addStepText = GameObject.Find("UI/StepPanel/TMP_StepAdd")
                .GetComponent<TextMeshProUGUI>();
            _reduceStepText = GameObject.Find("UI/StepPanel/TMP_StepReduce")
                .GetComponent<TextMeshProUGUI>();
            // 初始化
            _addStepOriginColor = _addStepText.color;
            _reduceStepOriginColor = _reduceStepText.color;
            _addStepTargetColor = new Color(_addStepText.color.r,
                _addStepText.color.g, _addStepText.color.b, 1);
            _reduceStepTargetColor = new Color(_reduceStepText.color.r,
                _reduceStepText.color.g, _reduceStepText.color.b, 1);
            _stepText.color = new Color(1, 1, 1, 0);
            UpdateStepText(ModelsManager.Instance.PlayerMod.CurrentLeftStep);
        }

        private void OnEnable()
        {
            _stepText = GameObject.Find("UI/StepPanel/TMP_Step")
                .GetComponent<TextMeshProUGUI>();
            // 注册事件
            GameManager.Instance.RegisterEvent(GameManagerEventType.OnGamePause,
                ShowPauseUI);
            GameManager.Instance.RegisterEvent(
                GameManagerEventType.OnGameResume, HidePauseUI);
            GameManager.Instance.onAllowLoadGame.AddListener((allow) =>
            {
                if (allow)
                    _stepText.DOColor(Color.white, stepFadeTime);
            });
            ModelsManager.Instance.PlayerMod.onStepChanged.AddListener(
                UpdateStepText);
            ModelsManager.Instance.PlayerMod.onStepChanged.AddListener(
                UpdateStepColor);
        }

        private void OnDisable()
        {
            // 注销事件
            GameManager.Instance.UnregisterEvent(
                GameManagerEventType.OnGamePause,
                ShowPauseUI);
            GameManager.Instance.UnregisterEvent(
                GameManagerEventType.OnGameResume, HidePauseUI);
            ModelsManager.Instance.PlayerMod.onStepChanged.RemoveListener(
                UpdateStepText);
        }

        /// <summary>
        /// 初始化暂停UI
        /// </summary>
        private void ResetPauseUI(Scene scene, LoadSceneMode mode)
        {
            ResetPauseUI();
        }

        private void ResetPauseUI()
        {
            GameObject ui = GameObject.Find("UI");
            _pausePanel = Instantiate(pausePanel, ui.transform.position,
                Quaternion.identity, ui.transform);
            _pausePanel.SetActive(false);
        }

        /// <summary>
        /// 处理暂停UI
        /// </summary>
        private void ShowPauseUI()
        {
            _pausePanel.SetActive(true);
        }

        /// <summary>
        /// 处理暂停UI
        /// </summary>
        private void HidePauseUI()
        {
            _pausePanel.SetActive(false);
        }

        private void UpdateStepText(int step)
        {
            _stepText.text = "剩余步数：" + step;
        }

        private void UpdateStepText(int step, bool _)
        {
            UpdateStepText(step);
        }

        private void UpdateStepText(Scene scene, LoadSceneMode mode)
        {
            _stepText.text =
                "剩余步数：" + ModelsManager.Instance.PlayerMod.CurrentLeftStep;
        }

        private void UpdateStepColor(int _, bool show = true)
        {
            if (show)
            {
                Debug.Log("开始显示");
                _addStepText.DOColor(_addStepTargetColor, stepChangeFadeTime)
                    .OnComplete(
                        () =>
                        {
                            _addStepText.DOColor(_addStepOriginColor,
                                stepChangeFadeTime);
                        }
                    );
            }
            else
            {
                Debug.Log("开始隐藏");
                _reduceStepText.DOColor(_reduceStepTargetColor,
                        stepChangeFadeTime)
                    .OnComplete(
                        () =>
                        {
                            _reduceStepText.DOColor(_reduceStepOriginColor,
                                stepChangeFadeTime);
                        }
                    );
            }
        }
    }
}
