using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    #region Singleton
    private static StageController instance;
    public static StageController Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    #region SerializeField
    [SerializeField] StageSlider stageSlider;
    #endregion

    #region public
    public StageController stageController;
    public int Stage
    {
        get
        {
            return stage;
        }
        set
        {
            stage = value;
            stageSlider.ProgressStage();
        }
    }
    #endregion

    #region private 
    int stage = 0;
    #endregion

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }
}
