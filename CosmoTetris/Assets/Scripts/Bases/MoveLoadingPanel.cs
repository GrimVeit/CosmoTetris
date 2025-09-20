using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MoveLoadingPanel : Panel
{
    public bool IsActive => isActive;

    [SerializeField] protected Vector3 start;
    [SerializeField] protected Vector3 normal;
    [SerializeField] protected Vector3 end;
    [SerializeField] protected float time;
    protected Tween tween;

    private bool isActive;

    public override void ActivatePanel()
    {
        if (tween != null) { tween?.Kill(); }

        panel.transform.localPosition = start;
        panel.SetActive(true);
        isActive = true;
        tween = panel.transform.DOLocalMove(normal, time).OnComplete(() =>
        {
            OnActivatePanel?.Invoke();
            OnActivatePanel_Data?.Invoke(this);
        });
    }

    public override void DeactivatePanel()
    {
        if (tween != null) { tween?.Kill(); }

        panel.transform.localPosition = normal;
        isActive = false;
        tween = panel.transform.DOLocalMove(end, time).OnComplete(() =>
        {
            panel.SetActive(false);
            OnDeactivatePanel?.Invoke();
            OnDeactivatePanel_Data?.Invoke(this);
        });
    }

    #region Input

    public event Action<Panel> OnDeactivatePanel_Data;
    public event Action<Panel> OnActivatePanel_Data;

    public event Action OnDeactivatePanel;
    public event Action OnActivatePanel;

    #endregion
}
