using System;
using DG.Tweening;
using TMPro;
using UnityEngine;


public class CoinsManager : MonoBehaviour
{
      #region  Singleton

      public static CoinsManager instance;

      private void Awake()
      {
            instance = this;
      }


      #endregion
     
      [SerializeField] private int curCoins;
      [SerializeField] private int multiplier;
      [SerializeField] private RectTransform winBar;
      [SerializeField] private RectTransform scoreImage;
      [SerializeField] private RectTransform centerPoint;
      [SerializeField] private TextMeshProUGUI coinsText;
      private void Start()
      {
            scoreImage.gameObject.SetActive(false);
            EventsManager.OnCoinPickUp += IncrementCoin;
            EventsManager.OnGameWin += ShowMultipliedText;
            
      }

      private void OnDisable()
      {
            EventsManager.OnCoinPickUp -= IncrementCoin;
            EventsManager.OnGameWin -= ShowMultipliedText;
      }


      public void MultiplyCoins(int multiple)
      {
            multiplier = multiple;
      }

      #region Event Callbacks

      private void IncrementCoin()
      {
            curCoins += 1;

            winBar.DOScale(new Vector2(1.2f, 1.2f), .1f).OnComplete(() =>
            {
                  winBar.DOScale(Vector2.one, .1f);
            });
                  
            scoreImage.gameObject.SetActive(true);
            RectTransform coin = Instantiate(scoreImage,centerPoint);
            scoreImage.gameObject.SetActive(false);
            coin.DOMove(winBar.position, .25f).OnComplete(() =>
            {
                  
                  coin.gameObject.SetActive(false);
            });
          
      }

      private void ShowMultipliedText()
      {
            curCoins = curCoins * multiplier;
            coinsText.text = curCoins.ToString();
      }

      #endregion
      
      
      
      
}