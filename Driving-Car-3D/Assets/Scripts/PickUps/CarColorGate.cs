using UnityEngine;


    public class CarColorGate : MonoBehaviour
    {
        [SerializeField] private CarColor scriptableColor;
        
        [SerializeField] private MyColor colorToChange;
        
      

        private void Awake()
        {
            colorToChange.colorName = scriptableColor.colorName;
            colorToChange.color = scriptableColor.color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out FuelManager fuelManager))
            {
                
                fuelManager.UpdateCarColor(colorToChange);
                EventsManager.CarUpgrade();
            }
        }
        

    }
