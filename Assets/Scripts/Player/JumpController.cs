using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] int jumpPower; // 점프 가중치
    [SerializeField] PlayerController playerController;
    #endregion

    #region private
    bool doJump;
    Rigidbody2D rb;
    #endregion

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //테스트용
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    public void SuperJump()
    {
        playerController.playerCollider.isTrigger = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpPower*1.5f);
        StartCoroutine(IsTriggerOff());
    }

    private IEnumerator IsTriggerOff()
    {
        yield return new WaitForSeconds(1f);
        playerController.playerCollider.isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            collision.GetComponent<Block>().DestroyBlock();
        }
    }
}
