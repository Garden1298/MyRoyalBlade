using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float meleeSpeed;
    [SerializeField] float damage;
    [SerializeField] GameObject superAttackArea;
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
        //애니메이션
        PlayerController.Instance.anim.SetTrigger("Attack");

        doAttack = true;
    }

    public void SuperAttack()
    {
        //애니메이션
        PlayerController.Instance.anim.SetTrigger("SuperAttack");

        superAttackArea.SetActive(true);
        doAttack = true;

        //카메라 흔들기
        CinemachineShake.instance.ShakeCamera(4f, 0.5f);

        StartCoroutine(SuperAttackOff());
    }

    private IEnumerator SuperAttackOff()
    {
        yield return new WaitForSeconds(1f);
        superAttackArea.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            other.GetComponent<Block>().TakeDamage(damage);
        }
    }
}
