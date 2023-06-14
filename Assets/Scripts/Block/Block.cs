using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float health; // 블럭의 체력
    [SerializeField] int jumpPower;
    [SerializeField] ParticleSystem explosionParticle; // 블럭이 삭제될때 사용되는 파티클
    #endregion

    #region private
    Rigidbody2D rb;
    Vector2 originPos;
    BlockController blockController;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // (오브젝트 풀링) 블럭 생성
    public void Create(BlockController blockController)
    {
        this.blockController = blockController;
        gameObject.SetActive(false);
        originPos = this.transform.position;
    }

    // (오브젝트 풀링) 블럭 스택에 할당
    public void Push()
    {
        blockController.Push(this);
    }

    // 피격
    public void TakeDamage(float damage)
    {
        health -= damage;

        rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        if (health <= 0)
        {
            DestroyBlock();
        }
    }

    //죽음
    public void DestroyBlock()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        blockController.Push(this);
        this.transform.position = originPos;
    }
}
