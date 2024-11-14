using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoSingleton<UIInputManager>
{
    private Stack<Presenter> mPresenters = new Stack<Presenter>();

    public void AddPresenter(Presenter presenter)
    {
        if (presenter.HasViewOption(ViewOptions.isStacking))
        {
            mPresenters.Push(presenter);
        }
    }

    public Presenter PopPresenter()
    {
        Presenter item = mPresenters.Pop();
        item.Release();
        return item;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mPresenters.Count != 0)
        {
            if (mPresenters.Peek().HasViewOption(ViewOptions.isEscapeClosing))
                PopPresenter();
        }
    }
}