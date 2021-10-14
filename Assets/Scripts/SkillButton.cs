using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    public const int icePoint = 3;
    public const int meteorPoint = 5;
    public const int lightningPoint = 10;
    

    
    
    public void OnClickIce()
    {
        StartCoroutine(Ice());
    }

    public void OnClickMeteor()
    {
        StartCoroutine(Meteor());
    }

    public void OnClickLightning()
    {
        StartCoroutine(lightning());
    }
    /// <summary>
    /// “G‘S‘Ì‚Ì“®‚«‚ğ~‚ß‚é
    /// </summary>
    /// <returns></returns>
    public IEnumerator Ice()
    {
        if(gameManager.skillPoint >= icePoint && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(icePoint);
            gameManager.uiManager.UpdateDisplaySkillButton();
            IceEffect();
            gameManager.isStop = true;
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                gameManager.enemiesList[i].StopEnemy();
                GameObject effect = Instantiate(EffectDataBase.instance.iceEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(effect, 5.0f);
            }
            yield return new WaitForSeconds(5.0f);
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                if (gameManager.enemiesList.Count == 0)
                {
                    break;
                }
                gameManager.enemiesList[i].ResumeEnemy();
            }
            gameManager.isStop = false;
        }
        
    }
    /// <summary>
    /// “G‚ğƒ‰ƒ“ƒ_ƒ€‚É”j‰ó‚·‚é
    /// </summary>
    /// <returns></returns>
    public IEnumerator Meteor()
    {
        if (gameManager.skillPoint >= meteorPoint && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(meteorPoint);
            gameManager.uiManager.UpdateDisplaySkillButton();
            MeteorEffect();
            int random = Random.Range(1, gameManager.enemiesList.Count);
            List<EnemyControllerBase> destroyEnemyList = new List<EnemyControllerBase>();
            for (int i = 0; i < random; i++)
            {
                GameObject meteor = Instantiate(EffectDataBase.instance.meteorEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(meteor, 2.0f);
                destroyEnemyList.Add(gameManager.enemiesList[i]);
                ScoreManager.instance.CountCombo();
                gameManager.uiManager.UpdateDisplayCombo();
            }
            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < destroyEnemyList.Count; i++)
            {
                destroyEnemyList[i].DestroyEnemy();
            }

        }
    }

    /// <summary>
    /// “G‘S‘Ì‚ÉUŒ‚‚µ‚Ä“®‚«‚ğ~‚ß‚é
    /// </summary>
    /// <returns></returns>
    public IEnumerator lightning()
    {
        if (gameManager.skillPoint >= lightningPoint && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(lightningPoint);
            gameManager.uiManager.UpdateDisplaySkillButton();
            LightningEffect();
            gameManager.isStop = true;

            yield return new WaitForSeconds(1.0f);

            List<EnemyControllerBase> destroyEnemyList = new List<EnemyControllerBase>();
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                if(gameManager.enemiesList[i] != null)
                {
                    gameManager.enemiesList[i].StopEnemy();
                    gameManager.enemiesList[i].enemyHP--;
                    ScoreManager.instance.CountCombo();
                    gameManager.uiManager.UpdateDisplayCombo();
                    GameObject effect = Instantiate(EffectDataBase.instance.enemyDestroyEffect, new Vector3(gameManager.enemiesList[i].transform.position.x, gameManager.enemiesList[i].transform.position.y + 0.25f, gameManager.enemiesList[i].transform.position.z), Quaternion.identity);
                    Destroy(effect, 1.0f);
                    if (gameManager.enemiesList[i].enemyHP <= 0)
                    {
                        destroyEnemyList.Add(gameManager.enemiesList[i]);
                        gameManager.enemiesList[i].SwitchGameObject(false);
                        continue;
                    }

                    GameObject lightningEffect = Instantiate(EffectDataBase.instance.lightningEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                    Destroy(lightningEffect, 5.0f);
                }
            }

            for (int i = 0; i < destroyEnemyList.Count; i++)
            {
                destroyEnemyList[i].DestroyEnemy();
            }
            yield return new WaitForSeconds(5.0f);

            if (gameManager.enemiesList != null)
            {
                for(int i = 0; i < gameManager.enemiesList.Count; i++)
                {
                    gameManager.enemiesList[i].ResumeEnemy();
                }

            }
            gameManager.isStop = false;
        }
    }

    private void UseSkillPoint(int point)
    {
        gameManager.skillPoint -= point;
        gameManager.uiManager.UpdateDisplaySkillGage();
    }

    private void IceEffect()
    {
        GameObject iceStartEffect = Instantiate(EffectDataBase.instance.iceStartEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(iceStartEffect, 1.0f);
        GameObject iceAttackEffect = Instantiate(EffectDataBase.instance.iceAttackEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(iceAttackEffect, 3.0f);
    }

    private void MeteorEffect()
    {
        GameObject meteorStartEffect = Instantiate(EffectDataBase.instance.meteorStartEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(meteorStartEffect, 1.0f);
    }

    private void LightningEffect()
    {
        GameObject lightningStartEffect = Instantiate(EffectDataBase.instance.lightningStartEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(lightningStartEffect, 1.0f);
        GameObject lightningAttackEffect = Instantiate(EffectDataBase.instance.lightningAttackEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(lightningAttackEffect, 4.0f);
    }
}
