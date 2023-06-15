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
    [SerializeField] int count; // 생성될 블럭의 개수
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

    // stage에 따라 블럭 생성
    private void BlockGenerator()
    {
        for (int i = count - 1; i >= 0; i--)
        {
            //생성할 블록 위치 {(블록 높이 * i) + (오프셋 * i)}
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

    // level에 따른 블럭 생성
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

    // 쉴드에 맞았을때 블럭들을 위로 밀침
    public void HitShield()
    {
        foreach(Block block in curBlock)
        {
            block.HitShield();
        }
    }

    // (오브젝트 풀링) 스택에서 꺼내고 setactive를 true로 바꿈
    public GameObject Pop()
    {
        Block block = blockStack.Pop();
        block.gameObject.SetActive(true);
        curBlock.Enqueue(block);
        return block.gameObject;
    }

    // (오브젝트 풀링) setactive를 false로 바꾸고 스택에서 넣음
    public void Push(Block block)
    {
        block.gameObject.SetActive(false);
        blockStack.Push(block);
        curBlock.Dequeue();

        leftBlockCnt--;

        // 남은 블럭이 없으면 다음 레벨 시작 & 블럭 생성
        if(leftBlockCnt==0)
        {
            Debug.Log("level start");
            StartLevel();
            StageController.Instance.Stage++;
        }
    }
}
