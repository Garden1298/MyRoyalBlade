using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region SerializeField
    [Header("Jump")]
    [SerializeField] Button btn_Jump;
    [SerializeField]JumpController jumpController;
    #endregion

    #region private
    PlayerController playerController;
    Image jumpBar;
    int jumpAmount;
    #endregion

    private void Start()
    {
        playerController = PlayerController.Instance.playerController;
        jumpBar = btn_Jump.GetComponent<Image>();
    }

    private void Update()
    {
        Debug.Log("amount:"+jumpAmount);
        jumpBar.fillAmount = jumpAmount*0.01f;
    }

    public void BtnJump()
    {
        if (!playerController.isOnGround) return;
     
        jumpAmount += 10;
        jumpController.Jump();
        
        if(jumpAmount == 100)
        {
            jumpAmount = 0;
        }
    }
}
