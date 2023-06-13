using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float health; // ���� ü��
    [SerializeField] ParticleSystem explosionParticle; // ���� �����ɶ� ���Ǵ� ��ƼŬ
    #endregion

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            //explosionParticle.Play();
            Instantiate(explosionParticle,transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("�� ����");
        }
    }
}
