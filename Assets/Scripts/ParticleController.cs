using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    #region SerializeField
    [Header("Particle")]
    [SerializeField] ParticleSystem movementParticle; // 움직일때 사용되는 파티클
    [SerializeField] ParticleSystem fallParticle; // 착지할때 사용되는 파티클
    [SerializeField, Range(0, 10)] int occurAfterVelocity; // 파티클이 생성되기 위한 스피드 값
    [SerializeField, Range(0f, 0.2f)] float particleFormationPeriod; // 파티클 생성 주기
    #endregion

    #region private
    Rigidbody2D rb;
    float counter; // 딜레이
    bool isOnGround; // 땅과 접촉 유무
    #endregion

    private void Start()
    {
        rb = transform.root.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        counter += Time.deltaTime;

        //파티클 생성 조건
        if (!isOnGround && Mathf.Abs(rb.velocity.y) > occurAfterVelocity)
        {
            if (counter > particleFormationPeriod)
            {
                //파티클 실행하기
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
