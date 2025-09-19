using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_Menu : MovePanel
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonGuide;
    [SerializeField] private Button buttonPrivacyPolicy;

    public override void Initialize()
    {
        base.Initialize();

        buttonPlay.onClick.AddListener(() => OnClickToPlay?.Invoke());
        buttonSettings.onClick.AddListener(() => OnClickToSettings?.Invoke());
        buttonGuide.onClick.AddListener(() => OnClickToGuide?.Invoke());
        buttonPrivacyPolicy.onClick.AddListener(() => OnClickToPrivacyPolicy?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonPlay.onClick.RemoveListener(() => OnClickToPlay?.Invoke());
        buttonSettings.onClick.RemoveListener(() => OnClickToSettings?.Invoke());
        buttonGuide.onClick.RemoveListener(() => OnClickToGuide?.Invoke());
        buttonPrivacyPolicy.onClick.RemoveListener(() => OnClickToPrivacyPolicy?.Invoke());
    }

    #region Output

    public event Action OnClickToPlay;
    public event Action OnClickToSettings;
    public event Action OnClickToGuide;
    public event Action OnClickToPrivacyPolicy;

    #endregion
}
