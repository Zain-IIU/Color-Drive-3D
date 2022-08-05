using UnityEngine;


    public class GameManager : MonoBehaviour
    {
        [ContextMenu("Game Start")]
        public void StartGame()
        {
            EventsManager.GameStart();
        }
    }
