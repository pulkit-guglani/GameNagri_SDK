using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTutorial : MonoBehaviour
{
    [SerializeField]
    private Toggle DoNotShowAgainToggle;
    [SerializeField]
    private GameObject StartGamePanel;

    private void Start()
    {
       
        if (PlayerPrefs.HasKey("DoNotShowSwipeTutorial") && (PlayerPrefs.GetInt("DoNotShowSwipeTutorial") == 1))
        {
            ResumeGame();
        }
        else
        {
            Invoke("PauseGame", 0.05f);
        }

    }
    public void PauseGame()
    {
        print("pausing game");
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        print("resuming game");

        Time.timeScale = 1;
        Destroy(transform.parent.gameObject);
    }

    public void ShowStartGamePanel()
    {
        StartGamePanel.SetActive(true);
    }

    public void OnStartGameClick()
    {
        int toggle = DoNotShowAgainToggle.isOn ? 1 : 0;
        print("toggle is : " + toggle);
        PlayerPrefs.SetInt("DoNotShowSwipeTutorial", toggle);
        ResumeGame();
    }
}
