using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralInput
{
    protected bool m_Jump = false;
    protected bool m_Crouch = false;
    protected bool m_Attack = false;

    public virtual void Update() { }
    public virtual void SetMaxTime(float _MaxTime) { }
    public virtual void SetMinSwipeDistance(float _MinSwipeDistance) { }

    public bool GetJump()
    {
        Debug.Log("Jump: " + m_Jump);
        return m_Jump;
    }

    public bool GetCrouch()
    {
        Debug.Log("Crouch: " + m_Crouch);
        return m_Crouch;
    }
    public bool GetAttack()
    {
        Debug.Log("Attack: " + m_Attack);
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
