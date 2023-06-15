using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject guard;
    [SerializeField] JumpController jumpController;
    #endregion

    #region public
    public bool isGuard; // °¡µå »ç¿ë À¯¹«
    #endregion

    private void Start()
    {
        guard = this.gameObject;
    }

    // ½¯µå ÀåÂø
    public void AttachGuard()
    {
        guard.SetActive(true);
        isGuard = true;
    }

    // ½¯µå ÇØÁ¦
    public void DetachGuard()
    {
        guard.SetActive(false);
        isGuard = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            BlockController.Instance.HitShield();
            jumpController.PreventJump();
            DetachGuard();
        }
    }
}
