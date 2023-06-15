using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject[] hearts; // �÷��̾��� ���� ��
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
                Debug.Log("gameover");
                return;
            }
        }
    }
}
