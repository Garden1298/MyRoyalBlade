using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject panel_pause;
    [SerializeField] TMP_Text text;
    #endregion

    #region private
    private bool isPaused = false; // ���� �Ͻ� ���� ����
    #endregion

    private void Start()
    {
        PauseGame();
        SetText("GameStart?");
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        panel_pause.SetActive(true);
    }

    public void ResumeGame()
    {
        if (text.text == "Resume?" || text.text == "GameStart?")
        {
            isPaused = false;
            Time.timeScale = 1f;
            panel_pause.SetActive(false);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // ���� �� ����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // ���� �� �ε�
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
