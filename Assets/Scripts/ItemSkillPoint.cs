using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSkillPoint : ItemControllerBase
{
    protected override void Item()
    {
        //gameManager.skillPoint += 3;
        gameManager.skillPoint = Mathf.Clamp(gameManager.skillPoint += 3, 0, 10);
        gameManager.uiManager.UpdateDisplaySkillGage();
    }
}
