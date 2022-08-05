using System.Collections;
using UnityEngine;


public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private GameObject windLines;
    [SerializeField] private GameObject boostVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private GameObject carChangeVFX;
    [SerializeField] private ParticleSystem positiveFuelPickVFX;
    [SerializeField] private ParticleSystem negativeFuelPickVFX;

    private void Start()
    {
        EventsManager.OnSpeedBoosted += EnableWindLines;
        EventsManager.OnCarCollision += EnableHitVFX;
        EventsManager.OnPositiveFuelPicked += EnableFuelPickVFX_Pos;
        EventsManager.OnNegativeFuelPicked += EnableFuelPickVFX_Neg;
        EventsManager.OnCarUpgrade += EnableCarChangeVFX;
    }

    private void OnDisable()
    {
        EventsManager.OnSpeedBoosted -= EnableWindLines;
        EventsManager.OnCarCollision -= EnableHitVFX;
        EventsManager.OnPositiveFuelPicked -= EnableFuelPickVFX_Pos;
        EventsManager.OnNegativeFuelPicked -= EnableFuelPickVFX_Neg;
        EventsManager.OnCarUpgrade -= EnableCarChangeVFX;
    }

    private void EnableWindLines()
    {
        boostVFX.SetActive(true);
        windLines.SetActive(true);
        StartCoroutine(nameof(Normalize));
    }

    private void EnableHitVFX()
    {
        hitVFX.SetActive(true);
    }

    private void EnableFuelPickVFX_Pos()
    {
        positiveFuelPickVFX.Play();
    }

    private void EnableFuelPickVFX_Neg()
    {
        negativeFuelPickVFX.Play();
        
    }

    private void EnableCarChangeVFX()
    {
        carChangeVFX.SetActive(true);
    }
    IEnumerator Normalize()
    {
        yield return new WaitForSeconds(1.5f);
        windLines.SetActive(false);
    }
}
