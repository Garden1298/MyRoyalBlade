using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject panel_pause;
    #endregion

    #region private
    private bool isPaused = false; // 게임 일시 중지 여부
    #endregion

    private void Start()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        panel_pause.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        panel_pause.SetActive(false);
    }
}
