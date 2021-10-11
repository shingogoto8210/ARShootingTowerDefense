using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHP : ItemControllerBase
{
    protected override void Item()
    {
        gameManager.defenseBase.dbHP += 3;
        gameManager.uiManager.UpdateDisplayHPGage();
    }
}
