using UnityEngine;


public class FuelColor : MonoBehaviour
{
    [SerializeField] private CarColor scriptableColor;
    
    [SerializeField] private MyColor fuelColor;

    private void Awake()
    {
        fuelColor.colorName = scriptableColor.colorName;
        fuelColor.color = scriptableColor.color;
    }

    public MyColor GetFuelColor() => fuelColor;
}
