using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject[] hearts; // 플레이어의 생명 수
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

            // 제일 마지막 하트를 비활성화 시킨다.
            GameObject heart = hearts[health];
            heart.SetActive(false); 

            // 마지막으로 남은 하트였다면 게임 오버
            if (health <= 0)
            {
                Debug.Log("gameover");
                return;
            }
        }
    }
}
