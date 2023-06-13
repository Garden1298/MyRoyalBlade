using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float health; // 블럭의 체력
    [SerializeField] ParticleSystem explosionParticle; // 블럭이 삭제될때 사용되는 파티클
    #endregion

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            //explosionParticle.Play();
            Instantiate(explosionParticle,transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("블럭 삭제");
        }
    }
}
