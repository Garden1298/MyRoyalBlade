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
            if (doAttack)
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            collision.GetComponent<Block>().TakeDamage(damage);
        }
    }
}
