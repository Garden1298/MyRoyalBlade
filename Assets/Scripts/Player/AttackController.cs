using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] Animator anim;
    [SerializeField] float meleeSpeed;
    [SerializeField] float damage;
    #endregion

    #region private
    float timeUntilMelee; // counter
    bool doAttack; // 공격 가능 유무
    #endregion

    private void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (doAttack||Input.GetKeyDown(KeyCode.A))        //GetKeyDown : 테스트용
            {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
                doAttack = false;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        doAttack = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            Debug.Log("attack");
            other.GetComponent<Block>().TakeDamage(damage);
        }
    }
}
