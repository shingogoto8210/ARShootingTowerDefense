using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHP : ItemControllerBase
{
    [SerializeField]
    private int recoverPoint = 3;
    /// <summary>
    /// DefenseBase‚ÌHP‚ð‰ñ•œ‚·‚é
    /// </summary>
    protected override void Item()
    {
        //gameManager.defenseBase.dbHP += 3;
        //gameManager.defenseBase.dbHP = Mathf.Clamp(gameManager.defenseBase.dbHP + 3, 0, 10); 
        gameManager.defenseBase.UpdateDefenseBaseHP(recoverPoint);
        gameManager.uiManager.UpdateDisplayHPGage();
    }
}
