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
    [SerializeField] ParticleSystem p_coinParticle; // ���� �����ɶ� ���Ǵ� ��ƼŬ
    [SerializeField] GameObject p_damageText; // ���� ���ݷ��� ����ϴ� �ؽ�Ʈ
    [SerializeField] ScoreController scoreController; // ���� ��Ʈ�ѷ�
    #endregion


    #region private
    Vector2 originPos;
    BlockController blockController;
    Animator anim;
    #endregion

    #region public
    public bool isFalling = true;
    #endregion

    private void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            StartCoroutine(StartTranslationDown());
        }
    }

    // ���忡 ����
    public void HitShield()
    {
        isFalling = false;
    }

    // ���� �ɷ� ����
    private IEnumerator StartTranslationDown()
    {
        yield return new WaitForSeconds(0.5f);
        isFalling = true;
    }

    // (������Ʈ Ǯ��) �� ����
    public void Create(BlockController blockController)
    {
        this.blockController = blockController;
        scoreController = GameObject.Find("GameManager").GetComponent<ScoreController>();
        anim = GetComponent<Animator>();

        // ������Ʈ Ȱ��ȭ
        gameObject.SetActive(false);
        // ���� ��ġ ����
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

        //�ִϸ��̼�
        anim.SetTrigger("Hit");
        ShowDamage(damage);

        if (health <= 0)
        {
            DestroyBlock();
        }
    }

    // ����
    public void DestroyBlock()
    {
        //����&���� ����
        scoreController.IncreaseScore((int)maxHealth);
        scoreController.IncreaseCoin((int)maxHealth / 10);

        //��ƼŬ ����
        Instantiate(p_explosionParticle, transform.position, Quaternion.identity);
        Instantiate(p_coinParticle, transform.position, Quaternion.identity);

        //�ʱ�ȭ
        health = maxHealth;
        transform.position = originPos;

        //������ƮǮ�� �ֱ�
        Push();
    }

    // ������ ���
    private void ShowDamage(float damage)
    {
        // ������ �ؽ�Ʈ ����
        GameObject text = Instantiate(p_damageText, transform.position, Quaternion.identity);
        text.GetComponent<TMP_Text>().text = damage.ToString();
    }
}
