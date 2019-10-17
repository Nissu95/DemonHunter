using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitCollider : MonoBehaviour
{
    [SerializeField] GameObject m_HitCollider;

    public GameObject GetCollider()
    {
        return m_HitCollider;
    }
}
