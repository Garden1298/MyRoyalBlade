using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperAttackSlider : MonoBehaviour
{
    #region SerializeField
    [SerializeField] Slider slider_attack;
    [SerializeField] UIController controller;
    [SerializeField] AttackController attackController;
    #endregion

    private void Start()
    {
        slider_attack = this.GetComponent<Slider>();
    }

    void Update()
    {
        if (slider_attack.value == 1)
        {
            // ���� ����
            attackController.SuperAttack();

            //�ʱ�ȭ
            slider_attack.value = 0;
            slider_attack.gameObject.SetActive(false);
            controller.ResetAttackAmount();
        }
    }
}
