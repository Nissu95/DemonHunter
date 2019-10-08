using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : GeneralInput
{
    float m_MaxTime;
    float m_MinSwipeDistance;

    float m_StartTime;
    float m_EndTime;
    float m_SwipeDistance;
    float m_SwipeTime;

    Vector3 m_StartPos;
    Vector3 m_EndPos;

    public override void Update()
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

    public override void SetMaxTime(float _MaxTime)
    {
        m_MaxTime = _MaxTime;
    }

    public override void SetMinSwipeDistance(float _MinSwipeDistance)
    {
        m_MinSwipeDistance = _MinSwipeDistance;
    }
}
