using System;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    //public Text MyText;
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
    }
    
    public event Action EndGame;

    public event Action HiHitMe;

    public void OnEndGame()
    {
        EndGame?.Invoke();
    }

    public void OnHiHitMe()
    {
        HiHitMe?.Invoke();
    }

}
