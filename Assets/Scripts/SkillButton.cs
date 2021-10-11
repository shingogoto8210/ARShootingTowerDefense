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

    public IEnumerator Ice()
    {
        if(gameManager.skillPoint >= 10 && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(10);
            gameManager.isStop = true;
            gameManager.isSkill = true;
            //gameManager.uiManager.UpdateDisplaySkillButton();
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                gameManager.enemiesList[i].StopEnemy();
                GameObject effect = Instantiate(EffectDataBase.instance.iceEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(effect, 5.0f);
            }
            gameManager.isSkill = false;
            yield return new WaitForSeconds(5.0f);
            for (int i = 0; i < gameManager.enemiesList.Count; i++)
            {
                gameManager.enemiesList[i].ResumeEnemy();
            }
            gameManager.isStop = false;
            int random = Random.Range(1, gameManager.enemiesList.Count);

            for (int i = 0; i < random; i++)
            {
                gameManager.enemiesList[i].DestoryEnemy();
                ScoreManager.instance.CountCombo();
            }
        }
        
    }

    public IEnumerator Meteor()
    {
        if(gameManager.skillPoint >= 5 && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(5);
            gameManager.isSkill = true; ;
            //gameManager.uiManager.UpdateDisplaySkillButton();
            int random = Random.Range(1, gameManager.enemiesList.Count);
            for (int i = 0; i < random; i++)
            {
                GameObject meteor = Instantiate(meteorPrefab, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(meteor, 2.0f);
            }
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < random; i++)
            {
                gameManager.enemiesList[i].DestoryEnemy();
                ScoreManager.instance.CountCombo();
            }
            gameManager.isSkill = false ;

        }
    }

    public IEnumerator lightning()
    {
        if (gameManager.skillPoint >= 3 && gameManager.currentGameState == ARState.Play)
        {
            UseSkillPoint(3);
            gameManager.isSkill = true;
            //gameManager.uiManager.UpdateDisplaySkillButton();
            GameObject lightning = Instantiate(lightningPrefab, gameManager.stage.transform.position, Quaternion.identity);
            Destroy(lightning, 2.0f);
            yield return new WaitForSeconds(1.0f);
            int random = Random.Range(1, gameManager.enemiesList.Count);
            for (int i = 0; i < random; i++)
            {
                gameManager.enemiesList[i].StopEnemy();
                GameObject lightningEffect = Instantiate(EffectDataBase.instance.lightningEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                Destroy(lightningEffect, 5.0f);
            }
            gameManager.isSkill = false;
            yield return new WaitForSeconds(5.0f);
            for (int i = 0; i < random; i++)
            {
                gameManager.enemiesList[i].ResumeEnemy();
            }
        }
    }

    private void UseSkillPoint(int point)
    {
        gameManager.skillPoint -= point;
        gameManager.uiManager.UpdateDisplaySkillGage();
    }
}
