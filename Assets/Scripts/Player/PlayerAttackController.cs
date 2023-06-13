using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float meleeSpeed;
    [SerializeField] float damage;

    float timeUntilMelee;//counter

    private void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            //collision.GetComponent<Block>().TakeDamage(damage);
            Debug.Log("°ø°ÝÇÔ");
        }
    }
}
