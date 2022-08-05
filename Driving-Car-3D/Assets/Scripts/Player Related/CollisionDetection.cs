using System;
using DG.Tweening;
using UnityEngine;
using MoreMountains.NiceVibrations;


public class CollisionDetection : MonoBehaviour
{
   [SerializeField] private  Vector3 forceDir = new Vector3(3, 1, 2);
   private CoinsManager coinsManager;

   private void Start()
   {
       coinsManager=CoinsManager.instance;
   }

   private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = false;
            rb.AddForce(forceDir  * 10f, ForceMode.Impulse);
            rb.AddTorque(other.transform.up * 10f, ForceMode.Impulse); 
            other.isTrigger = false;
            var noColLayer = LayerMask.NameToLayer("NoCollision");
            other.gameObject.layer =noColLayer;

            if (other.CompareTag("EnemyCar"))
            {
                MMVibrationManager.Haptic(HapticTypes.HeavyImpact, false,true, this);
                EventsManager.CarCollision();
            }
            
        }

        if (other.CompareTag("Coin"))
        {
            other.transform.DOScale(Vector3.zero, .25f);
            EventsManager.CoinPicked();
            MMVibrationManager.Haptic(HapticTypes.Selection, false,true, this);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            EventsManager.ReachedEnd();
        }
        if (other.gameObject.CompareTag("Crash"))
        {
            EventsManager.GameWin();
        }
        if (other.gameObject.CompareTag("multiplier"))
        {
            Multiplier multiplier = other.transform.parent.GetComponent<Multiplier>();
            coinsManager.MultiplyCoins(multiplier.GetMultiplierValue());
            Transform transform1; 
            (transform1 = other.transform).DOScale(Vector3.zero, .25f); 
            //AudioManager.instance.Play("GlassBreak");
            ParticlesManager.instance.PlayBreakVFXAt(transform1);
            MMVibrationManager.Haptic(HapticTypes.HeavyImpact, false,true, this);
        }

        if (other.CompareTag("Winner"))
        {
            ParticlesManager.instance.PlayConfettiVFX();
            EventsManager.GameWin();
            MMVibrationManager.Haptic(HapticTypes.Success, false,true, this);
        }
    }
}
