using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameAnalytics : MonoBehaviour
{
    [SerializeField]
    private GameObject GetDataAndReplace;

    public static GameAnalytics Instance;
    private float time = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        time = Time.time;
        GetCurrentLevelEvent();
    }

    public void GameOverEvent()
    {
        Analytics.CustomEvent("GameOverAt_" + GetDataAndReplace);
    }
    public void GameLoseEvent()
    {
        Analytics.CustomEvent("GameLoseAt_" + GetDataAndReplace);
    }
    public void TaskCompleteEvent()
    {
        Analytics.CustomEvent("TaskCount_" + GetDataAndReplace);
    }
    public void FoundationSubmissionEvent()
    {
        Analytics.CustomEvent("FoundationCount_" + GetDataAndReplace);
    }
    private void GetCurrentLevelEvent()
    {
       Analytics.CustomEvent("Level_" + SceneManager.GetActiveScene().buildIndex);
    }
    public void OnAdClickEvent()
    {
        Dictionary<string, object> dict = new Dictionary<string, object>() { { "TaskNumber", GetDataAndReplace } };

        Analytics.CustomEvent("AdCLicked", dict) ;

    }

    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
            time = Time.time - time;
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Level :", currentScene);
            data.Add("PlayTime :", time);
            if (currentScene > 0)
            {
                data.Add("TaskCompleted :", GetDataAndReplace);
            }

            Analytics.CustomEvent("QuitGame :", data);
        }
    }
}
