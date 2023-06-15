using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSlider : MonoBehaviour
{
    #region SerializeField
    [SerializeField] Slider slider_stage;
    [SerializeField] GameController gameController;
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
            gameController.PauseGame();
            gameController.SetText("Clear!");
        }
    }
    
}
