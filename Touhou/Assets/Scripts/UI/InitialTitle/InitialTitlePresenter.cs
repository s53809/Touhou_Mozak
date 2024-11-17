using DG.Tweening;
using System.Collections;
using UnityEngine;

public class InitialTitlePresenter : PresenterBase<InitialTitleView>
{
    public override void Release() { }

    public override void InitPresenter()
    {
        base.InitPresenter();
        StartCoroutine(CloseSlowly());
    }

    IEnumerator CloseSlowly()
    {
        yield return new WaitForSeconds(1f);
        _view.TitleOfTitle.DOColor(new Color(0, 0, 0, 0), 0.5f).OnComplete(Hide);
    }
}
