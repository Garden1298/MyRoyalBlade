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
    [SerializeField] int count; // ������ ���� ����
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

    // stage�� ���� �� ����
    private void BlockGenerator()
    {
        for (int i = count-1; i >= 0; i--)
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

    // (������Ʈ Ǯ��) ���ÿ��� ������ setactive�� true�� �ٲ�
    public GameObject Pop()
    {
        Block block = blockStack.Pop();
        block.gameObject.SetActive(true);
        return block.gameObject;
    }

    // (������Ʈ Ǯ��) setactive�� false�� �ٲٰ� ���ÿ��� ����
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
