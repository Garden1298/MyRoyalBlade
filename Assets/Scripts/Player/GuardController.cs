using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject guard;
    #endregion

    private void Start()
    {
        guard = this.gameObject;
    }

    // ���� ����
    public void AttachGuard()
    {
        guard.SetActive(true);
    }

    // ���� ����
    public void DetachGuard()
    {
        guard.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            BlockController.Instance.HitShield();
            DetachGuard();
        }
    }
}
