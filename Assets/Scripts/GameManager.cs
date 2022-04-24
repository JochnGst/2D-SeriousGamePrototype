using ClientFramework;
using ClientFramework.Interaction;
using GameUtilitys.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserCode;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;

    private Main _main;

    // Start is called before the first frame update
    void Start()
    {
        _main = new Main();
        playerController.getNextAction = GetMoveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerController.Surrounding.CurrentPosition is IGameAsset { Type: "Goal" })
        //{
        //    playerController.Stop();
        //    Debug.Log("Goal reached!");
        //    this.enabled = false;
        //}
    }

    private IPlayerAction GetMoveDirection(ISurrounding surrounding)
    {
        return _main.Player_NextStep(surrounding);
    }
}
