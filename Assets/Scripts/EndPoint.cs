using Assets.Scripts.Interfaces;
using ClientFramework;
using GameUtilitys.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour, IInteractable
{
    public IGameObject GameObject { get; } = new GameAsset { Type = "Goal" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
