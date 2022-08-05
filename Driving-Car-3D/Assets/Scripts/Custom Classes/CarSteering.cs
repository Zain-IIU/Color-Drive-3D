using UnityEngine;


public class CarSteering : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speedToReturnToNormalRotation;
//    [SerializeField] private RectTransform wheelTR;
    [SerializeField] private Transform wheelTR;
    private float value;
    private float mValue;
    [SerializeField] private SwerveControl horizontalControl;
    
    private void Update()
    { 
        CheckForInput(); 
        ClampAngle(); 
        RotateWheelSprite();
    }

    private void RotateWheelSprite()
    {
       
        var rotation = wheelTR.transform.localRotation;

        var normalRotation = Quaternion.Euler(0, 0, -value);
        wheelTR.transform.localRotation = Quaternion.Lerp(rotation, normalRotation, Time.deltaTime * rotationSpeed);
        
    }

    private void CheckForInput()
    {
        if (!horizontalControl.onScreenHold)
        {
            value = Mathf.Lerp(value, 0, speedToReturnToNormalRotation * Time.deltaTime);
            return;
        }
    
        mValue = horizontalControl.MoveFactorX * rotationSpeed * Time.deltaTime;

        if (horizontalControl.MoveFactorX != 0)
        {
            value += mValue;
        }
            
        else
            value = Mathf.Lerp(value, 0, speedToReturnToNormalRotation * Time.deltaTime);
        
    }

    private void ClampAngle()
    {
        value = Mathf.Clamp( value, -90, 90 );
    }
}
