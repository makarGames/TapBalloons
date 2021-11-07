using UnityEngine;
using DG.Tweening;

public class CanvasGroupBased : MonoBehaviour
{
    [SerializeField] protected CanvasGroup canvasGroup;

    public bool IsShown { get; protected set; }

    public virtual void Enable(bool enable)
    {
        IsShown = enable;

        canvasGroup.alpha = enable ? 1f : 0f;
        canvasGroup.blocksRaycasts = enable;
        canvasGroup.interactable = enable;
    }

    public virtual void Enable(bool enable, float duration)
    {
        IsShown = enable;

        canvasGroup.DOFade(IsShown ? 1f : 0f, duration);
        EnableInteractable(enable);
    }

    public virtual void EnableInteractable(bool enable)
    {
        canvasGroup.blocksRaycasts = enable;
        canvasGroup.interactable = enable;
    }
}