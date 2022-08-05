using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private RectTransform steerPart;
    [SerializeField] private RectTransform fuelBar;

    [SerializeField] private RectTransform startUI;
    private void Start()
    {
        StartUIElements();
        EventsManager.OnGameStart += EnableInGameUI;
        EventsManager.OnGameWin += HideUI;
        EventsManager.OnGameLose += EnableLosePanel;
        EventsManager.OnPositiveFuelPicked += AnimateFuelBar;
    }

    private void OnDisable()
    {
        EventsManager.OnGameStart -= EnableInGameUI;
        EventsManager.OnGameWin -= HideUI;
        EventsManager.OnGameLose -= EnableLosePanel;
        EventsManager.OnPositiveFuelPicked -= AnimateFuelBar;
    }


    private void EnableInGameUI()
    {
        startUI.gameObject.SetActive(false);
        steerPart.DOScaleY(1, 0.35f);
        fuelBar.DOScaleX(1, 0.35f); 
    }

    private void StartUIElements()
    {
        fuelBar.DOScaleX(0, 0);
        winPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
    }

    private void HideUI()
    {
        steerPart.DOScaleY(0, 0.25f);
        fuelBar.DOScaleX(0, 0.25f);
        winPanel.SetActive(true);
    }

    private void EnableLosePanel()
    {
        steerPart.DOScaleY(0, 0.25f);
        fuelBar.DOScaleX(0, 0.25f);
        losePanel.SetActive(true);
    }

    private void AnimateFuelBar()
    {
        fuelBar.DOScale(Vector2.one * 1.1f, .25f).OnComplete(() =>
        {
            fuelBar.DOScale(Vector2.one, .15f);
        });
    }
}
