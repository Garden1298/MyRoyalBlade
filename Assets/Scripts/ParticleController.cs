using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField]
    ParticleSystem movementParticle; // 움직일때 사용되는 파티클
    [SerializeField, Range(0, 10)]
    int occurAfterVelocity; // dustFormationPeriod에 도달하기 위한 스피드 값
    [SerializeField, Range(0f, 0.2f)]
    float dustFormationPeriod; // 파티클 주기

    Rigidbody2D rb;

    float counter;

    private void Start()
    {
        rb = transform.root.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if(Mathf.Abs(rb.velocity.y)>occurAfterVelocity)
        {
            if(counter> dustFormationPeriod)
            {
                //파티클 실행하기
                movementParticle.Play();
                counter = 0;
            }
        }
    }
}
