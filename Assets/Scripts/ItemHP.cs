using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHP : ItemControllerBase
{
    protected override void Item()
    {
        //gameManager.defenseBase.dbHP += 3;
        gameManager.defenseBase.dbHP = Mathf.Clamp(gameManager.defenseBase.dbHP + 3, 0, 10); 
        gameManager.uiManager.UpdateDisplayHPGage();
    }
}
