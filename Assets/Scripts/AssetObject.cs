using Assets.Scripts.Interfaces;
using ClientFramework;
using GameUtilitys.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetObject : MonoBehaviour, IInteractable
{
    public IGameObject GameObject { get; } = new GameAsset();
    private bool _stationInstalled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!_stationInstalled && GameObject is GameAsset asset and { Station: not null} )
        {
            _stationInstalled = true;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.567f, 0.9798f);
            Debug.Log($"Station {asset.Station.GetType()} is installed.");
        }
    }
}
