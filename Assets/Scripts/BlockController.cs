using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] GameObject blockGroup;
    [SerializeField] GameObject p_Block;
    [SerializeField] float blockheight;
    [SerializeField] float blockGenerateOffset;
    [SerializeField] int count; // ������ ���� ����
    #endregion

    #region private
    Quaternion QI = Quaternion.identity;
    #endregion

    private void Start()
    {
        BlockGenerator();
    }

    private void BlockGenerator()
    {
        int stage = PlayerPrefs.GetInt("Stage", 0);
        int count = Random.Range(6, 8) + stage;

        for (int i = 0; i < count; i++)
        {
            //������ ��� ��ġ {(��� ���� * i) + ������)
            Vector2 spawnPosition = new Vector2(blockGroup.transform.position.x, 
                                                blockGroup.transform.position.y + (blockheight * i) + (blockGenerateOffset*i));
            GameObject block = Instantiate(p_Block, spawnPosition, QI);
            block.transform.SetParent(blockGroup.transform);
        }
    }
}
