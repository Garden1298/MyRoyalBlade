using System.Collections;
using System.Collections.Generic;
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
    Quaternion QI = Quaternion.identity;
    int leftBlockCnt = 0;
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
        for (int i = count-1; i >= 0; i--)
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
        int stage = PlayerPrefs.GetInt("Stage", 0);
        int curCount = Random.Range(6, 8) + stage;
        Debug.Log("curCount:" + curCount);

        for (int i = 0; i < curCount; i++)
        {
            Debug.Log(i);
            Pop();
        }

        leftBlockCnt = curCount;
    }

    // (오브젝트 풀링) 스택에서 꺼내고 setactive를 true로 바꿈
    public GameObject Pop()
    {
        Block block = blockStack.Pop();
        block.gameObject.SetActive(true);
        return block.gameObject;
    }

    // (오브젝트 풀링) setactive를 false로 바꾸고 스택에서 넣음
    public void Push(Block block)
    {
        block.gameObject.SetActive(false);
        blockStack.Push(block);

        leftBlockCnt--;
        if(leftBlockCnt==0)
        {
            StartLevel();
        }
    }
}
