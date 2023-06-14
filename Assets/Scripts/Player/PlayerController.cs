using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    #region public
    public bool isOnGround;
    public PlayerController playerController;
    public BoxCollider2D playerCollider;
    public Animator anim;
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

    private void Start()
    {
        playerController = this.GetComponent<PlayerController>();
        playerCollider = this.GetComponent<BoxCollider2D>();
        anim = this.GetComponent<Animator>();
    }
}
