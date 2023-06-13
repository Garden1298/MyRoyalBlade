using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    #region SerializeField
    [Header("Particle")]
    [SerializeField] ParticleSystem movementParticle; // �����϶� ���Ǵ� ��ƼŬ
    [SerializeField] ParticleSystem fallParticle; // �����Ҷ� ���Ǵ� ��ƼŬ
    [SerializeField, Range(0, 10)] int occurAfterVelocity; // ��ƼŬ�� �����Ǳ� ���� ���ǵ� ��
    [SerializeField, Range(0f, 0.2f)] float particleFormationPeriod; // ��ƼŬ ���� �ֱ�
    #endregion

    #region private
    Rigidbody2D rb;
    float counter; // ������
    bool isOnGround; // ���� ���� ����
    #endregion

    private void Start()
    {
        rb = transform.root.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        counter += Time.deltaTime;

        //��ƼŬ ���� ����
        if (!isOnGround && Mathf.Abs(rb.velocity.y) > occurAfterVelocity)
        {
            if (counter > particleFormationPeriod)
            {
                //��ƼŬ �����ϱ�
                movementParticle.Play();
                counter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            fallParticle.Play();
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
