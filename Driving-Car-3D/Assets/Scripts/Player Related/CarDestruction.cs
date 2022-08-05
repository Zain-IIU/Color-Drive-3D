using System.Collections.Generic;
using UnityEngine;


public class CarDestruction : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> carParts = new List<Rigidbody>();

    [SerializeField] private float launchForce;
    
    private void Start()
    {
        EventsManager.OnCarCollision += DestroyParts;
    }

    private void OnDisable()
    {
        EventsManager.OnCarCollision -= DestroyParts;
    }

    #region Event Callbacks

    
    private void DestroyParts()
    {
        DestroyCarParts_All();
    }
    #endregion
    
    
    
    
    
    private void DestroyCarParts_All()
    {
        if(carParts.Count==0) return;
        
        var randomIndex = Random.Range(0, carParts.Count);

        carParts[randomIndex].isKinematic = false;
        carParts[randomIndex].transform.parent = null;
        carParts[randomIndex].AddForce(transform.up*launchForce,ForceMode.Impulse);
        
        carParts.RemoveAt(randomIndex);
    }
}
