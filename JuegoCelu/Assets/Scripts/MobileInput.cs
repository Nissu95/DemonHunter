using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput singleton;

    [SerializeField] float m_MaxTime;
    [SerializeField] float m_MinSwipeDistance;

    float m_StartTime;
    float m_EndTime;
    float m_SwipeDistance;
    float m_SwipeTime;

    Vector3 m_StartPos;
    Vector3 m_EndPos;

    bool m_Jump = false;
    bool m_Crouch = false;
    bool m_Attack = false;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                m_StartTime = Time.time;
                m_StartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                m_EndTime = Time.time;
                m_EndPos = touch.position;

                m_SwipeDistance = (m_EndPos - m_StartPos).magnitude;
                m_SwipeTime = m_EndTime - m_StartTime;

                if (m_SwipeTime < m_MaxTime && m_SwipeDistance > m_MinSwipeDistance)
                    Swipe();
                else
                    m_Attack = true;
            }
        }
    }

    void Swipe()
    {
        Vector2 distance = m_EndPos - m_StartPos;

        /*if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))          //Horizontal Swipe
        {
            Debug.Log("Horizontal Swipe");
            if (distance.x > 0)
            {
                Debug.Log("Right Swipe");
            }
            if (distance.x < 0)
            {
                Debug.Log("Left Swipe");
            }
        }*/

        if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))          //Vertical Swipe
        {
            Debug.Log("Vertical Swipe");
            if (distance.y > 0)
                m_Jump = true;

            if (distance.y < 0)
                m_Crouch = true;
        }
    }

    public bool GetJump()
    {
        return m_Jump;
    }

    public bool GetCrouch()
    {
        return m_Crouch;
    }

    public bool GetAttack()
    {
        return m_Attack;
    }

    public void SetJump(bool _Jump)
    {
        m_Jump = _Jump;
    }

    public void SetCrouch(bool _Crouch)
    {
        m_Crouch = _Crouch;
    }

    public void SetAttack(bool _Attack)
    {
        m_Attack = _Attack;
    }
}
