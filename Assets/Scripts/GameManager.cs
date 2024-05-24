using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region ������� ������� ����
    public GameObject firstLvl; // ������(�����)
    public GameObject hitterFirst;
    public GameObject sniperFirst;
    private bool isFirstLvlBegan;
    #endregion
    #region ������� ������� ����
    public GameObject secondLvl;
    public GameObject hitterSecond;
    public GameObject sniperSecond;
    private bool isSecondLvlBegan;
    #endregion
    //����
    public GameObject fires;
    #region ������� �������� ����
    public GameObject thirdLvl;
    public GameObject hitterThird;
    public GameObject sniperThird;
    public GameObject blackSniperThird;
    private bool isThirdLvlBegan;
    #endregion
    #region ������� ���������� ����
    public GameObject fourthLvl;
    public GameObject firstSpawner;
    public GameObject secondSpawner;
    private bool isFourthLvlBegan;
    #endregion
    #region ������� ������ ����
    public GameObject fifthLvl;
    public GameObject blackSniper;
    private bool isFifthLvlBegan;
    #endregion
    #region ������� ������� ����
    public GameObject sixthLvl;
    public GameObject toruses;
    private bool isSixthLvlBegan;
    #endregion
    #region ������� �������� ����
    public GameObject seventhLvl;
    public GameObject seventhShooter;
    public GameObject seventhHitter;
    public GameObject seventhToruses;
    private bool isSeventhLvlBegan;
    #endregion
    #region ������� �������� ����
    public GameObject eightthLvl;
    public GameObject eightthShooter;
    public GameObject eightthSniper;
    private bool isEightthLvlBegan;
    #endregion

    void Start()
    {
        #region ���������� �����
        isFirstLvlBegan = false;
        isSecondLvlBegan = false;
        isThirdLvlBegan = false;
        isFourthLvlBegan = false;
        isFifthLvlBegan = false;
        isSixthLvlBegan = false;
        isSeventhLvlBegan = false;
        isEightthLvlBegan = false;
        #endregion
    }

    void Update()
    {
        BeginFirstLevel();
        BeginSecondLevel();
        BeginThirdLevel();
        BeginFourthLevel();
        BeginFifthLevel();
        BeginSixthLevel();
        BeginSeventhLevel();
        BeginEightthLevel();
    }

    private void BeginFirstLevel()
    {
        if(firstLvl.GetComponent<CheckLvlBegin>().isInLvl && !isFirstLvlBegan)
        {
            hitterFirst.SetActive(true);
            sniperFirst.SetActive(true);
            isFirstLvlBegan = true;
        }
    }

    private void BeginSecondLevel()
    {
        if (secondLvl.GetComponent<CheckLvlBegin>().isInLvl && !isSecondLvlBegan)
        {
            hitterSecond.SetActive(true);
            sniperSecond.SetActive(true);
            isSecondLvlBegan = true;
            //�������� ����
            fires.SetActive(true);
        }
    }

    private void BeginThirdLevel()
    {
        if (thirdLvl.GetComponent<CheckLvlBegin>().isInLvl && !isThirdLvlBegan)
        {
            hitterThird.SetActive(true);
            sniperThird.SetActive(true);
            blackSniperThird.SetActive(true);
            isThirdLvlBegan = true;
            // ��������� ����
            fires.SetActive(false);
        }
    }

    private void BeginFourthLevel()
    {
        if (fourthLvl.GetComponent<CheckLvlBegin>().isInLvl && !isFourthLvlBegan)
        {
            firstSpawner.SetActive(true);
            secondSpawner.SetActive(true);
            isFourthLvlBegan = true;
        }
    }

    private void BeginFifthLevel()
    {
        if (fifthLvl.GetComponent<CheckLvlBegin>().isInLvl && !isFifthLvlBegan)
        {
            blackSniper.SetActive(true);
            isFifthLvlBegan = true;
        }
    }

    private void BeginSixthLevel()
    {
        if (sixthLvl.GetComponent<CheckLvlBegin>().isInLvl && !isSixthLvlBegan)
        {
            toruses.SetActive(true);
            isSixthLvlBegan = true;
        }
    }

    private void BeginSeventhLevel()
    {
        if (seventhLvl.GetComponent<CheckLvlBegin>().isInLvl && !isSeventhLvlBegan)
        {
            toruses.SetActive(false);
            seventhToruses.SetActive(true);
            seventhShooter.SetActive(true);
            seventhHitter.SetActive(true);
            isSeventhLvlBegan = true;
        }
    }

    private void BeginEightthLevel()
    {
        if (eightthLvl.GetComponent<CheckLvlBegin>().isInLvl && !isEightthLvlBegan)
        {
            seventhToruses.SetActive(false);
            eightthShooter.SetActive(true);
            eightthSniper.SetActive(true);
            isEightthLvlBegan = true;
        }
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("toNout");
    }
}
