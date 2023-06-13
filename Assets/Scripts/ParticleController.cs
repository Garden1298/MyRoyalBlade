using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField]
    ParticleSystem movementParticle; // �����϶� ���Ǵ� ��ƼŬ
    [SerializeField, Range(0, 10)]
    int occurAfterVelocity; // dustFormationPeriod�� �����ϱ� ���� ���ǵ� ��
    [SerializeField, Range(0f, 0.2f)]
    float dustFormationPeriod; // ��ƼŬ �ֱ�

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
                //��ƼŬ �����ϱ�
                movementParticle.Play();
                counter = 0;
            }
        }
    }
}
