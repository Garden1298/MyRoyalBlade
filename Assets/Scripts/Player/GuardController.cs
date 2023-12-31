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
    public bool isGuard; // ���� ��� ����
    #endregion

    private void Start()
    {
        guard = this.gameObject;
    }

    // ���� ����
    public void AttachGuard()
    {
        guard.SetActive(true);
        isGuard = true;
    }

    // ���� ����
    private IEnumerator DetachGuard()
    {
        yield return new WaitForSeconds(0.5f);
        guard.SetActive(false);
        isGuard = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            BlockController.Instance.HitShield();
            jumpController.PreventJump();
            StartCoroutine(DetachGuard());
        }
    }
}
