using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager singleton;
    [SerializeField] float m_MaxTime = 0.5f;
    [SerializeField] float m_MinSwipeDistance = 50;

    GeneralInput input;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;

#if UNITY_IOS || UNITY_ANDROID
        input = new MobileInput();
        input.SetMaxTime(m_MaxTime);
        input.SetMinSwipeDistance(m_MinSwipeDistance);
#elif UNITY_STANDALONE_WIN
        input = new PCInput();
#endif
    }

    private void Update()
    {
        input.Update();
    }

    public GeneralInput GetInput()
    {
        return input;
    }
}
