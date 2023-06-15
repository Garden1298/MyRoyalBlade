using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region SerializeField
    [Header("Jump")]
    [SerializeField] Button btn_Jump; // ���� ��ư
    [SerializeField] Slider slider_Jump; // Ư�� ���� �����̴�
    [SerializeField] JumpController jumpController;

    [Header("Guard")]
    [SerializeField] Button btn_Guard; // ��� ��ư
    [SerializeField] GuardController guardController;

    [Header("Attack")]
    [SerializeField] Button btn_Attack; // ���� ��ư
    [SerializeField] Slider slider_Attack; // Ư�� ���� �����̴�
    [SerializeField] AttackController attackController;
    #endregion

    #region private
    PlayerController playerController;
    Image jumpBar; // ���� ��ư�� �̹���
    Image guardBar; // ��� ��ư�� �̹���
    Image attackBar; // ���� ��ư�� �̹���
    int jumpAmount; // ���� ���� ������
    int attackAmount; //���� ���� ������
    #endregion

    private void Start()
    {
        playerController = PlayerController.Instance.playerController;
        jumpBar = btn_Jump.GetComponent<Image>();
        guardBar = btn_Guard.GetComponent<Image>();
        attackBar = btn_Attack.GetComponent<Image>();
    }

    private void Update()
    {
        jumpBar.fillAmount = jumpAmount * 0.01f;
        attackBar.fillAmount = attackAmount * 0.01f;

        if(guardBar.fillAmount<1)
        {
            guardBar.fillAmount += Time.deltaTime * 0.01f;
        }
    }

    public void BtnJump()
    {
        if (!playerController.isOnGround) return;

        jumpAmount += 10;
        jumpController.Jump();

        if (jumpAmount == 100)
        {
            slider_Jump.gameObject.SetActive(true);
        }
    }

    public void BtnGuard()
    {
        if (guardBar.fillAmount == 1)
        {
            guardController.AttachGuard();
            guardBar.fillAmount = 0;
        }
    }

    public void BtnAttack()
    {
        attackAmount += 10;
        attackController.Attack();

        if (attackAmount == 100)
        {
           slider_Attack.gameObject.SetActive(true);
        }
    }

    public void ResetJumpAmount()
    {
        jumpAmount = 0;
    }

    public void ResetAttackAmount()
    {
        attackAmount = 0;
    }
}
