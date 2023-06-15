using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    #region Singleton
    private static BlockController instance;
    public static BlockController Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    #region SerializeField
    [SerializeField] GameObject blockGroup;
    [SerializeField] GameObject p_Block;
    [SerializeField] float blockheight;
    [SerializeField] float blockGenerateOffset;
    [SerializeField] int count; // ������ ���� ����
    #endregion

    #region private
    Stack<Block> blockStack = new Stack<Block>();
    Queue<Block> curBlock = new Queue<Block>();
    Quaternion QI = Quaternion.identity;
    int leftBlockCnt = 0;
    int stage = 0;
    #endregion

    #region public
    public BlockController blockController;
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
        BlockGenerator();
    }

    // stage�� ���� �� ����
    private void BlockGenerator()
    {
        for (int i = count - 1; i >= 0; i--)
        {
            //������ ��� ��ġ {(��� ���� * i) + (������ * i)}
            Vector2 spawnPosition = new Vector2(blockGroup.transform.position.x,
                                                blockGroup.transform.position.y + (blockheight * i) + (blockGenerateOffset * i));
            Block block = Instantiate(p_Block, spawnPosition, QI).GetComponent<Block>();
            block.transform.SetParent(blockGroup.transform);
            block.Create(this);
            block.gameObject.name = "block" + i;
            blockStack.Push(block);
        }

        StartLevel();
    }

    // level�� ���� �� ����
    private void StartLevel()
    {
        Debug.Log(StageController.Instance);
        Debug.Log(PlayerController.Instance);

        int curCount = UnityEngine.Random.Range(6, 8) + StageController.Instance.Stage;
        curCount = Mathf.Clamp(curCount, 6, count);

        for (int i = 0; i < curCount; i++)
        {
            Pop();
        }

        leftBlockCnt = curCount;
    }

    // ���忡 �¾����� ������ ���� ��ħ
    public void HitShield()
    {
        foreach(Block block in curBlock)
        {
            block.HitShield();
        }
    }

    // (������Ʈ Ǯ��) ���ÿ��� ������ setactive�� true�� �ٲ�
    public GameObject Pop()
    {
        Block block = blockStack.Pop();
        block.gameObject.SetActive(true);
        curBlock.Enqueue(block);
        return block.gameObject;
    }

    // (������Ʈ Ǯ��) setactive�� false�� �ٲٰ� ���ÿ��� ����
    public void Push(Block block)
    {
        block.gameObject.SetActive(false);
        blockStack.Push(block);
        curBlock.Dequeue();

        leftBlockCnt--;

        // ���� ���� ������ ���� ���� ���� & �� ����
        if(leftBlockCnt==0)
        {
            Debug.Log("level start");
            StartLevel();
            StageController.Instance.Stage++;
        }
    }
}
