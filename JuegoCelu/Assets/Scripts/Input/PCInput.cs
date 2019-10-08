using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : GeneralInput
{
    public override void Update()
    {
        if (Input.GetButtonDown("Jump"))
            m_Jump = true;
        else
            m_Jump = false;

        if (Input.GetButtonDown("Crouch"))
            m_Crouch = true;
        else
            m_Crouch = false;

        if (Input.GetButtonDown("Fire1"))
            m_Attack = true;
        else
            m_Attack = false;
    }
}
