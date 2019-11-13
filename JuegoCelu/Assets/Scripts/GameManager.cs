using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    [SerializeField] GameObject menuGO;

    void Awake()
    {
        //DontDestroyOnLoad(this);
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;
    }

    public void OnPlayerDeath()
    {
        menuGO.SetActive(true);
    }
}
