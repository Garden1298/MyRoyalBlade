using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperJumpSlider : MonoBehaviour
{
    #region SerializeField
    [SerializeField] Slider slider_jump;
    [SerializeField] UIController controller;
    [SerializeField] JumpController jumpController;
    #endregion

    private void Start()
    {
        slider_jump = this.GetComponent<Slider>();
    }

    void Update()
    {
        if(slider_jump.value == 1)
        {
            Debug.Log("superjump");
            jumpController.SuperJump();
            slider_jump.value = 0;
            slider_jump.gameObject.SetActive(false);
            controller.ResetJumpAmount();
        }
    }
}
