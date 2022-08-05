
using DG.Tweening;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public static ParticlesManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private ParticleSystem glassBreakVFX;
    [SerializeField] private GameObject winVFX;


    public void PlayBreakVFXAt(Transform pos)
    {
        glassBreakVFX.transform.DOMove(pos.position, 0).OnComplete(() =>
        {
            glassBreakVFX.Play();
        });
    }

    public void PlayConfettiVFX()
    {
        winVFX.SetActive(true);
    }
    
}
