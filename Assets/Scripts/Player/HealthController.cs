using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject[] hearts; // �÷��̾��� ���� ��
    [SerializeField] GuardController guardController;
    #endregion

    #region private
    int health;
    #endregion

    private void Start()
    {
        health = hearts.Length;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (guardController.isGuard) return;

        if (collision.gameObject.tag == "Block")
        {
            if (health <= 0) return;

            health -= 1;

            // ���� ������ ��Ʈ�� ��Ȱ��ȭ ��Ų��.
            GameObject heart = hearts[health];
            heart.SetActive(false);

            // ���������� ���� ��Ʈ���ٸ� ���� ����
            if (health <= 0)
            {
                GameOver();
                return;
            }
        }
    }

    private void GameOver()
    {
        // ���� �� ����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // ���� �� �ε�
        SceneManager.LoadScene(currentSceneIndex);
    }
}
