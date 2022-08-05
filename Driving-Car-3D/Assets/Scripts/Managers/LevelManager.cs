using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.NiceVibrations;
using OD;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField]
    GameObject[] levels;

   
    [SerializeField] private Color[] fogColors;
    [SerializeField] private AtmosphericFogRenderFeature fog;
    
    [SerializeField] private bool startDisabled;
    private static int CurrentLevel
    {
        get => PlayerPrefs.GetInt("CurrentLevel", 0);
        set
        {
            PlayerPrefs.SetInt("CurrentLevel", value);
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        instance = this;
        fog.settings.fogDensity = 0.002f;
        MMVibrationManager.Haptic(HapticTypes.LightImpact, false,true, this);
        if (!startDisabled) return;
        foreach (var level in levels)  level.SetActive(false);

    }

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 60;
        LoadGame();   
    }
    

    private void LoadGame()
    {
        var index = PlayerPrefs.GetInt("LevelIndex");
        CurrentLevel = index > levels.Length ? Random.Range(0, levels.Length) : GetLevelIndex();

        print("Level #" + CurrentLevel);
        levels[CurrentLevel].SetActive(true);
        fog.settings.color = fogColors[CurrentLevel];
    }

    private int GetLevelIndex()
    {
        return CurrentLevel % levels.Length;
    }
    
    [ContextMenu("Load Next Level")]
    public void IncrementLevelIndex()
    {
        CurrentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        PlayerPrefs.Save();
        Debug.Log("Loading Next level");
        EventsManager.NextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    [ContextMenu("Restart Level")]
    public void ReplayLevel()
    {
        Debug.Log("Loading same level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDisable()
    {
        fog.settings.fogDensity = 0f;
    }
}