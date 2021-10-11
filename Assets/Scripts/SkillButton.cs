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
    

    void Start()
    {
        //GetComponent<Button>().
    }
    public void OnClickIce()
    {
        StartCoroutine(Ice());
    }

    public void OnClickMeteor()
    {
        Meteor();
    }

    public void OnClickLightning()
    {
        lightning();
    }

    public IEnumerator Ice()
    {
        if(gameManager.skillPoint >= 10)
        {
            //gameManager.uiManager.UpdateDisplaySkillButton(false);
            gameManager.skillPoint -= 10;
            gameManager.uiManager.UpdateDisplaySkillGage();

            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                gameManager.enemiesList[i].StopEnemy();
                GameObject effect = Instantiate(EffectDataBase.instance.enemyStopEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(effect, 5.0f);
            }
            yield return new WaitForSeconds(5.0f);
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                gameManager.enemiesList[i].ResumeEnemy();
            }
        }
        
    }

    public void Meteor()
    {
        if(gameManager.skillPoint >= 10)
        {
            gameManager.skillPoint -= 10;
            gameManager.uiManager.UpdateDisplaySkillGage();
            int random = Random.Range(1, gameManager.enemiesList.Count);
            Debug.Log(gameManager.enemiesList.Count);
            Debug.Log(random);
            int i = 0;
            for (i = 0; i < random; i++)
            {
                GameObject meteor = Instantiate(meteorPrefab, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                gameManager.enemiesList[i].DestoryEnemy();
                Destroy(meteor, 2.0f);
                ScoreManager.instance.CountCombo();
            }   
        }
    }

    public void lightning()
    {
        if (gameManager.skillPoint >= 10)
        {
            GameObject lightning = Instantiate(lightningPrefab, gameManager.stage.transform.position, Quaternion.identity);
            Destroy(lightning, 2.0f);
            gameManager.skillPoint -= 10;
            gameManager.uiManager.UpdateDisplaySkillGage();
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                gameManager.enemiesList[i].AttackEnemy();
                GameObject effect = Instantiate(EffectDataBase.instance.enemyAttackEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(effect, 1.0f);
                ScoreManager.instance.CountCombo();
            }
        }
    }
}
