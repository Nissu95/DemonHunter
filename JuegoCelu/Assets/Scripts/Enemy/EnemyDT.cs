using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDT : MonoBehaviour
{
    [SerializeField] EnemyData data;

    public EnemyData GetData()
    {
        return data;
    } 
}