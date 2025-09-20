using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomSliderPanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private SliderBlock[] sliderBlocks;
    [SerializeField] private float tweenDuration = 0.2f;
    [SerializeField] private RectTransform rectTransform;

    private int activeBlockIndex = -1;
    private Tween valueTween;
    private float currentPercent;

    public void OnDrag(PointerEventData eventData)
    {
        UpdatePercent(eventData, false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdatePercent(eventData, true);
    }

    private void UpdatePercent(PointerEventData eventData, bool isClick)
    {
        float percent = GetPercent(eventData);

        Debug.Log(percent);

        int closestIndex = FindClosestBlock(percent);

        Debug.Log(closestIndex);

        if (closestIndex != activeBlockIndex)
        {
            activeBlockIndex = closestIndex;
            UpdateVisual();

            if (isClick)
                AnimateValue(sliderBlocks[activeBlockIndex].percentValue);
            else
                SetValueInstant(sliderBlocks[activeBlockIndex].percentValue);

        }
    }

    private void AnimateValue(float targetPercent)
    {
        valueTween?.Kill();

        valueTween = DOTween.To(() => currentPercent, x => currentPercent = x, targetPercent, tweenDuration).OnUpdate(() =>
        {
            float volume = currentPercent / 100f;
        });
    }

    private void SetValueInstant(float targetPercent)
    {
        currentPercent = targetPercent;

        float volume = currentPercent / 100f;
    }

    private float GetPercent(PointerEventData eventData)
    {

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
            return 0;

        float halfWidth = rectTransform.rect.width / 2f;
        return Mathf.Clamp01((localPoint.x + halfWidth) / rectTransform.rect.width) * 100f;
    }

    private int FindClosestBlock(float percent)
    {
        int closestIndex = 0;
        float minDiff = Mathf.Abs(percent - sliderBlocks[0].percentValue);

        for (int i = 0; i < sliderBlocks.Length; i++)
        {
            float diff = Mathf.Abs(percent - sliderBlocks[i].percentValue);

            if (diff < minDiff)
            {
                minDiff = diff;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    private void UpdateVisual()
    {
        for (int i = 0; i < sliderBlocks.Length; i++)
        {
            sliderBlocks[i].imageBlock.sprite = i <= activeBlockIndex ? sliderBlocks[i].spriteActive : sliderBlocks[i].spriteInactive;
        }
    }
}

[System.Serializable]
public class SliderBlock
{
    public Image imageBlock;
    public Sprite spriteActive;
    public Sprite spriteInactive;

    [Range(0, 100)]
    public float percentValue;
}
