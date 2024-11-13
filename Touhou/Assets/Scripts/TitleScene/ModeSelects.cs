using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[System.Serializable]
struct PairInt
{
    public int first;
    public int second;
}
public class ModeSelects : MonoBehaviour
{ //이거 싹다 지우고 UI MVP Model 적용하기
    [SerializeField] private PairInt[] _ranges;
    [SerializeField] private Image _titleOfTitle;
    [SerializeField] private String[] _descs;
    private Text _desc;
    private RectTransform[] _childTrans = new RectTransform[8];
    private Text[] _childTexts = new Text[8];

    private Boolean _moveTrigger = false;
    private PlayerActions _playerInput;

    public Int32 SelectedStage { get; private set; } = 0;
    public void Awake()
    {
        _desc = transform.GetChild(8).GetComponent<Text>();
        for(int i = 0; i < _childTrans.Length; i++)
        {
            _childTrans[i] = transform.GetChild(i).GetComponent<RectTransform>();
            _childTexts[i] = transform.GetChild(i).GetComponent<Text>();
            if (i != 0) _childTexts[i].color = Color.gray;
        }
        StartCoroutine(MoveCoroutine());

        _playerInput = new PlayerActions();
        _playerInput.Enable();

        _playerInput.MainTitle.Up.started += PlayerInputUp;
        _playerInput.MainTitle.Down.started += PlayerInputDown;
    }

    public void Start()
    {
        StartCoroutine(StartGameUI());
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
    }

    public void PlayerInputDown(InputAction.CallbackContext context)
    {
        SelectedStage = (SelectedStage + 1) % 8;
        MarkButtonSelect(SelectedStage);
    }
    IEnumerator StartGameUI()
    {
        yield return new WaitForSeconds(1f);
        _titleOfTitle.DOColor(new Color(1, 1, 1, 0), 0.5f);
        yield return null;
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
