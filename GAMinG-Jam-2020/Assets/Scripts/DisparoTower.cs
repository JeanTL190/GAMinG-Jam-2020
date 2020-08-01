﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTower : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody2D rb;
    private Collider2D col;
    private Transform tEnemy;
    private Vector3 direcao;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(col!=null)
        {
            tEnemy = col.GetComponent<Transform>();
            direcao = tEnemy.position - transform.position;
            rb.velocity = direcao.normalized * speed;
        }
    }
    public void setCol(Collider2D c)
    {
        col = c;
    }
}