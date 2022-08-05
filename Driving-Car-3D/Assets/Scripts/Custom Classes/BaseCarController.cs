using System.Collections;
using System.ComponentModel;
using System.Security.Claims;
using UnityEngine;


public abstract class BaseCarController : MonoBehaviour
{

   [SerializeField] protected float carMoveSpeed;
   private float _carMaxSpeed;

   [Header("Car Configs")] [SerializeField]
   protected float normalCarMoveSpeed;

   [SerializeField] private float normalCarMoveSpeedMax;
   [SerializeField] private float turningSpeed = 10f;

   [Space] [SerializeField] private float horizontalSpeed = 15f;
   [SerializeField] private float carDrag = 0.98f;
   [SerializeField] private float drift = 1f;


   [Space] [Header("Car Transforms")] [SerializeField]
   private Transform carBody;

   [SerializeField] private float carBodyRot = 5f;

   [Space] [Header("Car Skid Trails")] [SerializeField]
   private TrailRenderer skidMarkLeft;

   [SerializeField] private TrailRenderer skidMarkRight;

   private Vector3 _carMoveVector;

   protected bool stopTheCar;

   [SerializeField] private float clampXPos;
   [SerializeField] private Gradient normalSpeedSkidGradient;

   protected virtual void Start()
   {
      carMoveSpeed = 0;
      _carMaxSpeed = 0;
     
      EventsManager.OnGameStart += StartCar;

   }

   protected virtual void OnDisable()
   {
      EventsManager.OnGameStart -= StartCar;
   }


   protected virtual void Update()
   {
   }

   protected void HandleMovement(float value)
   {
      
      _carMoveVector.x += horizontalSpeed * value * Time.deltaTime;

      Vector3 movePos = transform.localPosition;
      movePos += _carMoveVector * Time.deltaTime;
      movePos.x = Mathf.Clamp(movePos.x, -clampXPos, clampXPos);

      transform.localPosition = movePos;

      _carMoveVector.z += carMoveSpeed * Time.deltaTime;
   }

   protected void HandleRotation(float value)
   {
      var rotation = carBody.transform.localRotation;
      value = Mathf.Clamp(value,-1, 1);
      var yRot = carBodyRot * value;
      
      var normalRotation = Quaternion.Euler(0, yRot, 0f);
      carBody.transform.localRotation = Quaternion.Lerp(rotation, normalRotation, Time.deltaTime * turningSpeed);
   }



   protected virtual void HandleCarEffects(float value) { }

   protected void HandleDrift()
   {
      _carMoveVector *= carDrag;
      _carMoveVector = Vector3.ClampMagnitude(_carMoveVector, _carMaxSpeed);
      _carMoveVector = Vector3.Lerp(_carMoveVector.normalized, transform.forward, drift * Time.deltaTime) *
                       _carMoveVector.magnitude;
   }


   protected void NormalSpeed()
   {
      skidMarkLeft.colorGradient = normalSpeedSkidGradient;
      skidMarkRight.colorGradient = normalSpeedSkidGradient;
      carMoveSpeed = normalCarMoveSpeed;
   }

   protected void EnableSkidMarks(bool isEnabled)
   {
      
      skidMarkLeft.emitting = isEnabled;
      skidMarkRight.emitting = isEnabled;
      
   }

   protected void EnableSkidMarks(bool isEnabled, Gradient newColor)
   {
      skidMarkLeft.colorGradient = newColor;
      skidMarkRight.colorGradient = newColor;
      skidMarkLeft.emitting = isEnabled;
      skidMarkRight.emitting = isEnabled;
   }
   
   







#region Event Callbacks

   private void StartCar()
   {
      carMoveSpeed = normalCarMoveSpeed;
      _carMaxSpeed = normalCarMoveSpeedMax;
   }

   #endregion
}
