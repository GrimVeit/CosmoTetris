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

        int closestIndex = FindClosestBlock(percent);

        if(closestIndex != activeBlockIndex)
        {
            activeBlockIndex = closestIndex;
            //Up
        }
    }

    private float GetPercent(PointerEventData eventData)
    {
        Vector2 localPoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPoint))
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
            //sliderBlocks[i].imageBlock.
        }
    }
}

public class SliderBlock
{
    public Image imageBlock;

    [Range(0, 100)]
    public float percentValue;
}
