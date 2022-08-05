using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject startCam;
    [SerializeField] private GameObject winCam;
    [SerializeField] private GameObject loseCam;
    [SerializeField] private GameObject endCam;

    private void Start()
    {
       // EventsManager.OnReachedEnd += EnableEndCamera;
        EventsManager.OnGameWin += EnableWinCamera;
        EventsManager.OnGameLose += EnableLoseCamera;
    }

    private void OnDestroy()
    {
       // EventsManager.OnReachedEnd -= EnableEndCamera;
        EventsManager.OnGameWin -= EnableWinCamera;
        EventsManager.OnGameLose -= EnableLoseCamera;
    }

    #region Event Call Backs

    private void EnableFollowCamera()
    {
        startCam.SetActive(false);
      //  followCam.SetActive(true);
    }

    private void EnableEndCamera()
    {
      //  followCam.SetActive(false);
        endCam.SetActive(true);
    }

    private void EnableWinCamera()
    {
        endCam.SetActive(false);
        winCam.SetActive(true);
    }

    private void EnableLoseCamera()
    {
      //  followCam.SetActive(false);
        loseCam.SetActive(true);
    }

#endregion

      
    }
