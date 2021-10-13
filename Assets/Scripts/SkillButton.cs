using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject meteorPrefab;
    [SerializeField]
    private GameObject lightningPrefab;
    private Button btn;
    

    void Start()
    {
        btn = GetComponent<Button>();
        btn.interactable = false;

    }
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
        if(gameManager.skillPoint >= 3 && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(3);
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
        if (gameManager.skillPoint >= 5 && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(5);
            int random = Random.Range(0, gameManager.enemiesList.Count);
            List<EnemyControllerBase> destroyEnemyList = new List<EnemyControllerBase>();
            for (int i = 0; i < random; i++)
            {
                GameObject meteor = Instantiate(meteorPrefab, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(meteor, 2.0f);
                yield return new WaitForSeconds(0.5f);
                //gameManager.enemiesList[i].DestroyEnemy();
                destroyEnemyList.Add(gameManager.enemiesList[i]);
                gameManager.enemiesList[i].SwitchGameObject(false);
                ScoreManager.instance.CountCombo();
            }
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
        if (gameManager.skillPoint >= 10 && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(10);
            gameManager.isStop = true;
            GameObject lightning = Instantiate(lightningPrefab, gameManager.stage.transform.position, Quaternion.identity);
            Destroy(lightning, 2.0f);
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                if(gameManager.enemiesList[i] != null)
                {
                    gameManager.enemiesList[i].StopEnemy();
                    GameObject lightningEffect = Instantiate(EffectDataBase.instance.lightningEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                    Destroy(lightningEffect, 5.0f);
                }
                
            }
            yield return new WaitForSeconds(5.0f);
            if (gameManager.enemiesList != null)
            {
                List<EnemyControllerBase> enemies = new List<EnemyControllerBase>();
                for(int i = 0; i < gameManager.enemiesList.Count; i++)
                {
                    enemies.Add(gameManager.enemiesList[i]);
                }
                Debug.Log(enemies.Count);

                for(int i = 0; i < enemies.Count ; i++)
                {
                  
                        enemies[i].AttackEnemy();
                        enemies[i].ResumeEnemy();
                        Debug.Log(i);
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
}
