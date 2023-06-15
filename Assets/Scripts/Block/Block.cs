using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float maxHealth; //블럭의 최대 체력
    [SerializeField] float health; // 블럭의 체력
    [SerializeField] float speed; // 이동 속도
    [SerializeField] ParticleSystem p_explosionParticle; // 블럭이 삭제될때 사용되는 파티클
    [SerializeField] GameObject p_damageText; // 받은 공격력을 출력하는 텍스트
    #endregion

    #region private
    Vector2 originPos;
    BlockController blockController;
    #endregion

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    // (오브젝트 풀링) 블럭 생성
    public void Create(BlockController blockController)
    {
        this.blockController = blockController;
        gameObject.SetActive(false);
        originPos = this.transform.position;
    }

    // (오브젝트 풀링) 블럭 스택에 할당
    public void Push()
    {
        blockController.Push(this);
    }

    // 피격
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
        // 데미지 텍스트 생성
        GameObject text = Instantiate(p_damageText, transform.position, Quaternion.identity);
        text.GetComponent<TMP_Text>().text = damage.ToString();
    }

    //죽음
    public void DestroyBlock()
    {
        //파티클 생성
        Instantiate(p_explosionParticle, transform.position, Quaternion.identity);

        //초기화
        health = maxHealth;
        transform.position = originPos;

        //오브젝트풀에 넣기
        blockController.Push(this);
    }
}
