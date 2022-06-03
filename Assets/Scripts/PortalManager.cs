using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float EnemyPeriod;

    [SerializeField] private Animator m_anim;

    void Start()
    {
        InvokeRepeating("InvokeEnemy", 0, EnemyPeriod);
    }

    void InvokeEnemy()
    {
        m_anim.SetTrigger("Spawn");
        Instantiate(EnemyPrefab, transform.position, transform.rotation);
     
    }
}