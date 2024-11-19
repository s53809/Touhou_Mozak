using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.InputSystem;

[System.Serializable]
struct PairInt
{
    public int first;
    public int second;
}
public class ModeSelectsPresenter : PresenterBase<ModeSelectsView>
{
    [SerializeField] private PairInt[] _ranges;
    [SerializeField] private String[] _descs;

    private RectTransform[] _childTrans;
    private Text[] _childTexts;

    private Boolean _moveTrigger = false;
    private PlayerActions _playerInput;

    public Int32 SelectedStage { get; private set; } = 0;
    public override void Release() { }

    public override void InitPresenter()
    {
        base.InitPresenter();
        _childTexts = new Text[]
        {
            _view.Start,
            _view.Extra_Start,
            _view.Practice_Start,
            _view.Replay,
            _view.Result,
            _view.Music_Room,
            _view.Option,
            _view.Quit,
        };
        _childTrans = new RectTransform[]
        {
            _view.Start.rectTransform,
            _view.Extra_Start.rectTransform,
            _view.Practice_Start.rectTransform,
            _view.Replay.rectTransform,
            _view.Result.rectTransform,
            _view.Music_Room.rectTransform,
            _view.Option.rectTransform,
            _view.Quit.rectTransform,
        };

        for (Int32 i = 0; i < _childTexts.Length; i++) _childTexts[i].color = Color.gray;
        _view.Start.color = Color.white;
        OnDescription(SelectedStage);

        StartCoroutine(MoveCoroutine());

        _playerInput = new PlayerActions();
        _playerInput.Enable();

        _playerInput.MainTitle.Up.started += PlayerInputUp;
        _playerInput.MainTitle.Down.started += PlayerInputDown;
    }

    private void MarkButtonSelect(Int32 index)
    {
        for (int i = 0; i < _childTrans.Length; i++)
        {
            if (i != index) _childTexts[i].color = Color.gray;
            else _childTexts[i].color = Color.white;
        }
    }

    public void PlayerInputUp(InputAction.CallbackContext context)
    {
        if (SelectedStage == 0) SelectedStage = 7;
        else SelectedStage--;
        MarkButtonSelect(SelectedStage);
        OnDescription(SelectedStage);
    }

    public void PlayerInputDown(InputAction.CallbackContext context)
    {
        SelectedStage = (SelectedStage + 1) % 8;
        MarkButtonSelect(SelectedStage);
        OnDescription(SelectedStage);
    }

    private void OnDescription(Int32 index)
    {
        _view.Description.rectTransform.DOPause();
        _view.Description.text = _descs[index];
        _view.Description.rectTransform.anchoredPosition = new Vector3(-245, -70, 0);
        _view.Description.rectTransform.DOAnchorPosY(-20, 0.5f);
    }
    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < _childTrans.Length; i++)
            {
                int xPos = 0;
                if ((i % 2) == (_moveTrigger ? 1 : 0)) xPos = _ranges[i].first;
                else xPos = _ranges[i].second;
                _childTrans[i].DOAnchorPosX(xPos, 1f);
            }
            _moveTrigger = !_moveTrigger;
            yield return new WaitForSeconds(4f);
        }
    }
}
