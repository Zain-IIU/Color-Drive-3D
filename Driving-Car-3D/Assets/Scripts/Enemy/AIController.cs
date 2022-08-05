using UnityEngine;

[SelectionBase]
public class AIController : BaseCarController
{
    [Header("Sensor Stuff")]
    [Space]
    [SerializeField] private Transform sensorPoint;

    [SerializeField] private float overtakeSpeed = 10f;
    [SerializeField] private Vector3 sensorSize;

    [SerializeField] private LayerMask carsLayer;

    private float turningMultiplier;
    // Update is called once per frame
    protected override void Update()
    {
        HandleMovement(turningMultiplier);
        HandleRotation(turningMultiplier);
        HandleDrift();
        CheckSensor();
    }


    private void CheckSensor()
    {
        turningMultiplier = Mathf.Lerp(turningMultiplier, Physics.CheckBox(sensorPoint.position,
                sensorSize,
            Quaternion.identity, carsLayer) ? 1 : 0, 
            Time.deltaTime * overtakeSpeed);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.blue;
        Gizmos.DrawCube(sensorPoint.position,sensorSize);
    }
}
