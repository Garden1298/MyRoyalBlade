using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float maxHealth; //���� �ִ� ü��
    [SerializeField] float health; // ���� ü��
    [SerializeField] float speed; // �̵� �ӵ�
    [SerializeField] ParticleSystem p_explosionParticle; // ���� �����ɶ� ���Ǵ� ��ƼŬ
    [SerializeField] GameObject p_damageText; // ���� ���ݷ��� ����ϴ� �ؽ�Ʈ
    #endregion

    #region private
    Vector2 originPos;
    BlockController blockController;
    #endregion

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    // (������Ʈ Ǯ��) �� ����
    public void Create(BlockController blockController)
    {
        this.blockController = blockController;
        gameObject.SetActive(false);
        originPos = this.transform.position;
    }

    // (������Ʈ Ǯ��) �� ���ÿ� �Ҵ�
    public void Push()
    {
        blockController.Push(this);
    }

    // �ǰ�
    public void TakeDamage(float damage)
    {
        health -= damage;

        ShowDamage(damage);

        if (health <= 0)
        {
            DestroyBlock();
        }
    }

    private void ShowDamage(float damage)
    {
        // ������ �ؽ�Ʈ ����
        GameObject text = Instantiate(p_damageText, transform.position, Quaternion.identity);
        text.GetComponent<TMP_Text>().text = damage.ToString();
    }

    //����
    public void DestroyBlock()
    {
        //��ƼŬ ����
        Instantiate(p_explosionParticle, transform.position, Quaternion.identity);

        //�ʱ�ȭ
        health = maxHealth;
        transform.position = originPos;

        //������ƮǮ�� �ֱ�
        blockController.Push(this);
    }
}
