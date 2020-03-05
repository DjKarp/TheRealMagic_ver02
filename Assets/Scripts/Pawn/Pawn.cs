﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    protected Transform m_Transform;

    public float HP;
    public float maxHP;

    [Header("Sprite самой полоски HP Bar'а.")]
    [SerializeField]
    protected Transform hpBar;
    protected float startHpBarValue;

    protected Animator m_Animator;


    protected virtual void Awake()
    {

        HP = maxHP;

        m_Transform = gameObject.transform;
        startHpBarValue = m_Transform.localScale.x;

        m_Animator = gameObject.GetComponent<Animator>();
        if (m_Animator == null) m_Animator = gameObject.GetComponentInChildren<Animator>();               
        
    }

    protected virtual void Update()
    {


    }

    public virtual void TakeDamage(float damage)
    {

        HP = Mathf.Clamp(HP - damage, 0.0f, maxHP);

        m_Animator.SetTrigger("Damage");

        CheckDie();

    }

    protected virtual void CheckDie()
    {

        if (HP <= 0.0f)
        {

            hpBar.localScale = new Vector3(0.0f, hpBar.localScale.y, hpBar.localScale.z);

            Die();

        }
        else
        {

            hpBar.localScale = new Vector3((startHpBarValue * HP) / maxHP, hpBar.localScale.y, hpBar.localScale.z);

        }

    }

    protected virtual void Die()
    {

        GameManager.Instance.EnemyPawn.Remove(this);
        GameManager.Instance.EnemyPawnTransform.Remove(m_Transform);

        m_Animator.SetTrigger("Die");

        Destroy(gameObject, 2.0f);

    }    

}
