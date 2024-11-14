using System;
using UnityEngine;

public abstract class PresenterBase<TView> : Presenter where TView : ViewBase
{
    private TView __view;
    protected TView _view { 
        get
        {
            if (__view == null)
                throw new Exception("You don't have view Component");
            else return __view;
        }
        set
        {
            __view = value;
        }
    }
    public override void InitPresenter()
    {
        __view = GetComponent<TView>();
    }

    public override void Bind()
    {
        if (HasViewOption(ViewOptions.isStacking))
            UIInputManager.Ins.AddPresenter(this);
        __view.OpenView();
    }

    public override void Hide()
    {
        __view.CloseView();
    }

    public override void Show()
    {
        __view.OpenView();
    }
    public override bool HasViewOption(ViewOptions options) => __view.options.HasFlag(options);
}