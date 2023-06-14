using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float health; // ���� ü��
    [SerializeField] int jumpPower;
    [SerializeField] ParticleSystem explosionParticle; // ���� �����ɶ� ���Ǵ� ��ƼŬ
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

    // (������Ʈ Ǯ��) �� ����
    public void Create(BlockController blockController)
    {
        this.blockController = blockController;
        gameObject.SetActive(false);
        originPos = this.transform.position;
    }

    // (������Ʈ Ǯ��) �� ���ÿ� �Ҵ�
    public void Push()
    {
        blockController.Push(this);
    }

    // �ǰ�
    public void TakeDamage(float damage)
    {
        health -= damage;

        rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        if (health <= 0)
        {
            DestroyBlock();
        }
    }

    //����
    public void DestroyBlock()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        blockController.Push(this);
        this.transform.position = originPos;
    }
}
