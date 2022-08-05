using System.Collections;
using UnityEngine;


public class CarControls : BaseCarController
{
    [SerializeField] private bool speedIsBoosted;
    [SerializeField] private bool hasReachedEnd;

    [SerializeField] private Gradient boostedSpeedSkidGradient;
    private float horizontalValue;

    [SerializeField] private SwerveControl playerSwerve;
    protected override void Start()
    {
        base.Start();

        EventsManager.OnFuelEnd += StopTheCar;
        EventsManager.OnSpeedBoosted += BoostTheSpeed;
        EventsManager.OnReachedEnd += CarReachedEnd;
        EventsManager.OnGameWin += CarWin;
        EventsManager.OnCarUpgrade += IncreaseSpeed;
    } 
    protected override void OnDisable()
    {
        base.OnDisable();
       
        EventsManager.OnFuelEnd -= StopTheCar;
   
        EventsManager.OnSpeedBoosted -= BoostTheSpeed;
        EventsManager.OnReachedEnd -= CarReachedEnd;
        EventsManager.OnGameWin -= CarWin;
        EventsManager.OnCarUpgrade -= IncreaseSpeed;
    }

    protected override void Update()
    {
        if(stopTheCar ) return;
        GatherInput();
        HandleMovement(horizontalValue);
        HandleRotation(horizontalValue);
        HandleDrift();
        HandleCarEffects(horizontalValue);
    }


    
    protected override void HandleCarEffects(float value)
    {
        if(speedIsBoosted)
            EnableSkidMarks(true,boostedSpeedSkidGradient);
        else
        {
            EnableSkidMarks(Mathf.Abs(value) > .65f);   
        }
         
    }
    private void GatherInput()
    {
        if (Input.GetMouseButtonDown(0)) return;
        
        if (Input.GetMouseButton(0))
            horizontalValue = Input.GetAxis("Mouse X");
        else
            horizontalValue = 0;

    }


    #region EventCallBacks

    private void StopTheCar()
    {
        StopAllCoroutines();
        speedIsBoosted = false;
        NormalSpeed();
        stopTheCar = true;
        
        if(hasReachedEnd)
            EventsManager.GameWin();
        else
            EventsManager.GameLose();
    }

    private void BoostTheSpeed()
    {
        StopAllCoroutines();
        speedIsBoosted = true;
        carMoveSpeed *= 3;
        StartCoroutine(NormalizeSpeed());
    }

    private void CarReachedEnd()
    {
        hasReachedEnd = true;
        carMoveSpeed += 20f;
    }
    private void CarWin()
    {
        stopTheCar = true;
    }

    private void IncreaseSpeed()
    {
        carMoveSpeed = normalCarMoveSpeed;
    }
    #endregion

  

    IEnumerator NormalizeSpeed()
    {
        yield return new WaitForSeconds(2f);
        speedIsBoosted = false;
        NormalSpeed();
    }

}

