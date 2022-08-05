using System;
using MoreMountains.NiceVibrations;
using UnityEngine;


public class PickUpManager : MonoBehaviour
{
    [SerializeField] private PickUpType pickUpType;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FuelManager fuelManager))
            TakeAction(fuelManager.GetCarColor());
    }

    private void TakeAction(MyColor carColor)
    {
      
        switch (pickUpType)
        {
            case PickUpType.FuelPickUp:
                gameObject.SetActive(false);
                var fuelColor = GetComponent<FuelColor>();

                if (carColor.colorName == fuelColor.GetFuelColor().colorName)
                {
                    MMVibrationManager.Haptic(HapticTypes.MediumImpact, false,true, this);
                    EventsManager.PositiveFuelPicked();
                }


                else
                {
                    MMVibrationManager.Haptic(HapticTypes.Warning, false,true, this);
                    EventsManager.NegativeFuelPicked();
                }
                
                break;
            case PickUpType.SpeedBooster:
                AudioManager.instance.Play("Boost");
                EventsManager.SpeedBoosted();
                break;
            case PickUpType.NoDamage:
                
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
