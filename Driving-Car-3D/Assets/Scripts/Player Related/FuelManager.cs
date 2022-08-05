using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class FuelManager : MonoBehaviour
{
    [SerializeField] private float fuelAmount; 
    
    [SerializeField] private Image fuelBar;
    [SerializeField] private float consumeSpeed;
    [SerializeField] private float incrementInFuel;
    private bool startConsuming;
    private float curFuel;

    [SerializeField] private CarColor scriptableColor;
    [SerializeField] private Material carBodyMaterial;
    public MyColor curCarColor;
    private void Start()
    {
        SetCarDefaultColor();
        curFuel = fuelAmount;
        EventsManager.OnGameStart += StartConsumingFuel;
        EventsManager.OnPositiveFuelPicked += IncrementFuel;
        EventsManager.OnNegativeFuelPicked += DecrementFuel;
    }

    private void OnDisable()
    {
        EventsManager.OnGameStart -= StartConsumingFuel;
        EventsManager.OnPositiveFuelPicked -= IncrementFuel;
        EventsManager.OnNegativeFuelPicked -= DecrementFuel;
    }

    private void Update()
    {
        if(!startConsuming) return;
        if (!HasFuel())
        {
            EventsManager.FuelEnd();
            enabled = false;
        }
         
       
        curFuel = Mathf.Lerp(curFuel, 0, Time.deltaTime * consumeSpeed * 0.5f);
        fuelBar.fillAmount = (curFuel / 100);
    }

    #region Event Callbacks

    private void StartConsumingFuel()
    {
        startConsuming = true;
    }

    private void IncrementFuel()
    {
        curFuel += incrementInFuel;
        if (curFuel > fuelAmount)
            curFuel = fuelAmount;
    }

    private void DecrementFuel()
    {
        carBodyMaterial.DOColor(Color.black,0.07f).OnComplete(() =>
        {
            carBodyMaterial.DOColor(curCarColor.color,.07f) ;
        });
        curFuel -= (incrementInFuel/4);
    }
    #endregion

    private void SetCarDefaultColor()
    {
        curCarColor.colorName = scriptableColor.colorName;
        curCarColor.color = scriptableColor.color;
        carBodyMaterial.color = curCarColor.color;
    }
    private bool HasFuel()
    {
        return fuelBar.fillAmount > 0.05f;
    }
  
    public void UpdateCarColor(MyColor newColor)
    {
        carBodyMaterial.DOColor(newColor.color, .1f);
        curCarColor = newColor;
    }

    public MyColor GetCarColor() => curCarColor;

}
