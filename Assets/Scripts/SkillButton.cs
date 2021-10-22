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
    /// �G�S�̂̓������~�߂�
    /// </summary>
    /// <returns></returns>
    public IEnumerator Ice()
    {
        if(gameManager.skillPoint >= icePoint && gameManager.currentGameState == ARState.Play )
        {
            //isSkill��true�̂Ƃ��͑��̃X�L�����g���Ȃ�
            gameManager.isSkill = true;
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
            gameManager.isSkill = false;
            gameManager.uiManager.UpdateDisplaySkillButton();
        }

    }
    /// <summary>
    /// �G�Ƀ����_���Ƀ_���[�W��^����
    /// </summary>
    /// <returns></returns>
    public IEnumerator Meteor()
    {
        if (gameManager.skillPoint >= meteorPoint && gameManager.currentGameState == ARState.Play)
        {
            gameManager.isSkill = true;
            UseSkillPoint(meteorPoint);
            gameManager.uiManager.UpdateDisplaySkillButton();
            MeteorEffect();
            int random = Random.Range(1, gameManager.enemiesList.Count);
            //�X�L���Ŕj�󂳂ꂽEnemy�͂��̃��X�g�ɓ����
            List<EnemyControllerBase> destroyEnemyList = new List<EnemyControllerBase>();

            //�����_���ȓG��覐΂𗎂Ƃ�
            for (int i = 0; i < random; i++)
            {
                GameObject meteor = Instantiate(EffectDataBase.instance.meteorEffect, gameManager.enemiesList[i].transform.position, Quaternion.identity);
                ScoreManager.instance.CountCombo();
                gameManager.uiManager.UpdateDisplayCombo();
                Destroy(meteor, 2.0f);
                gameManager.enemiesList[i].enemyHP--;
                if (gameManager.enemiesList[i].enemyHP <= 0)
                {
                    destroyEnemyList.Add(gameManager.enemiesList[i]);
                    //gameManager.enemiesList[i].SwitchGameObject(false);
                }
            }
            yield return new WaitForSeconds(1.0f);

            //覐΂��������G�̏ꏊ�Ŕ����G�t�F�N�g�𐶐�
            for(int i = 0; i < random; i++)
            {
                GameObject effect = Instantiate(EffectDataBase.instance.enemyDestroyEffect, new Vector3(gameManager.enemiesList[i].transform.position.x, gameManager.enemiesList[i].transform.position.y + 0.25f, gameManager.enemiesList[i].transform.position.z), Quaternion.identity);
                Destroy(effect, 1.0f);

            }

            //覐΂œ|�����G��Destroy���āCgameManager�̃��X�g���������
            for (int i = 0; i < destroyEnemyList.Count; i++)
            {
                destroyEnemyList[i].DestroyEnemy();
            }

            gameManager.isSkill = false;
            gameManager.uiManager.UpdateDisplaySkillButton();

        }
    }

    /// <summary>
    /// �G�S�̂ɍU�����ē������~�߂�
    /// </summary>
    /// <returns></returns>
    public IEnumerator lightning()
    {
        if (gameManager.skillPoint >= lightningPoint && gameManager.currentGameState == ARState.Play)
        {
            gameManager.isSkill = true;
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
            gameManager.isSkill = false;
            gameManager.uiManager.UpdateDisplaySkillButton();
        }
    }

    /// <summary>
    /// �X�L���|�C���g������C�X�L���Q�[�W�̍X�V������
    /// </summary>
    /// <param name="point"></param>
    private void UseSkillPoint(int point)
    {
        gameManager.skillPoint -= point;
        gameManager.uiManager.UpdateDisplaySkillGage();
    }

    /// <summary>
    /// �X�̃G�t�F�N�g�𐶐�
    /// </summary>
    private void IceEffect()
    {
        GameObject iceStartEffect = Instantiate(EffectDataBase.instance.iceStartEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(iceStartEffect, 1.0f);
        GameObject iceAttackEffect = Instantiate(EffectDataBase.instance.iceAttackEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(iceAttackEffect, 3.0f);
    }

    /// <summary>
    /// 覐΂̃G�t�F�N�g�𐶐�
    /// </summary>
    private void MeteorEffect()
    {
        GameObject meteorStartEffect = Instantiate(EffectDataBase.instance.meteorStartEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(meteorStartEffect, 1.0f);
    }

    /// <summary>
    /// ���̃G�t�F�N�g�𐶐�
    /// </summary>
    private void LightningEffect()
    {
        GameObject lightningStartEffect = Instantiate(EffectDataBase.instance.lightningStartEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(lightningStartEffect, 1.0f);
        GameObject lightningAttackEffect = Instantiate(EffectDataBase.instance.lightningAttackEffect, gameManager.stage.transform.position, Quaternion.identity);
        Destroy(lightningAttackEffect, 4.0f);
    }
}
