using System;
using UnityEngine;

[Flags]
public enum ViewOptions
{
    isEscapeClosing = 1,
    isStacking = 2,
    autoHideAtStart = 4,
}
public abstract class ViewBase : MonoBehaviour
{
    private CanvasGroup mCanvasGroup;
    [SerializeField] public ViewOptions options;

    private void Awake()
    {
        mCanvasGroup = GetComponent<CanvasGroup>();
        if (options.HasFlag(ViewOptions.autoHideAtStart))
            CloseView();
        InitView();
    }

    public void CloseView()
    {
        mCanvasGroup.alpha = 0.0f;
        mCanvasGroup.blocksRaycasts = false;
        mCanvasGroup.interactable = false;
    }

    public void OpenView()
    {
        mCanvasGroup.alpha = 1.0f;
        mCanvasGroup.blocksRaycasts = true;
        mCanvasGroup.interactable = true;
    }

    protected virtual void InitView() { }
}
