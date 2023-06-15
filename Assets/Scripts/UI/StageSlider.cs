using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSlider : MonoBehaviour
{
    #region SerializeField
    [SerializeField] Slider slider_stage;
    #endregion

    private void Start()
    {
        slider_stage = this.GetComponent<Slider>();
    }

    public void ProgressStage()
    {
        slider_stage.value += 0.2f;

        if (slider_stage.value == 1)
        {
            Debug.Log("게임 클리어");
        }
    }
}
