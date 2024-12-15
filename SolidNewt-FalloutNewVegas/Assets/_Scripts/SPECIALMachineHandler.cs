using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SPECIALMachineHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player, uiContainer, crosshair, itemDisplay, b1,b2,b3,b4,b5,b6,b7,b8,b9,b10, selection;
    [SerializeField]
    private GameObject cameraS;

    private int select, sStat, pStat, eStat, cStat, iStat, aStat, lStat, skillpoints, tempskill;

    [SerializeField]
    private TMP_Text points;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(true);
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);
        b5.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(false);
        b8.SetActive(false);
        b9.SetActive(false);
        b10.SetActive(false);
        sStat = 5;
        pStat = 5;
        eStat = 5;
        cStat = 5;
        iStat = 5;
        aStat = 5;
        lStat = 5;
        skillpoints = 5;
        select = 0;
        selection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.inSpecial == true)
        {
            player.SetActive (false);
            cameraS.SetActive(true);
            uiContainer.SetActive(true);
            Debug.Log("heheXD");
            selection.SetActive(true);
        }
        else
        {
            player.SetActive(true);
            cameraS.SetActive(false);
            uiContainer.SetActive(false);
            selection.SetActive(false);
        }
        Debug.Log(select);
        SelectedArea();

        UpdateText();
    }

    public void NextButton()
    {
        if (select < 6)
        {
            select++;
        }
        else
        {
            select = 6;
        }
    }

    public void PrevButton()
    {
        if (select > 0)
        {
            select--;
        }
        else
        { select = 0; }
    }

    public void SkillUp()
    {
        int temp = tempskill;
        if (skillpoints >0)
        {
            temp++;
            skillpoints--;
            SetSelectedSkill(temp);
        }
        else
        {
            skillpoints = 0;
        }
    }

    public void SkillDown()
    {
        int temp = tempskill;
        if (skillpoints < 35)
        {
            temp--;
            if (temp>0)
            {
                skillpoints++;
            }
            else
            {
                temp = 1;
            }
            SetSelectedSkill(temp);
        }
        else
        {
            skillpoints = 35;
        }
    }

    private void SelectedArea()
    {
        switch (select) 
        {
            case 6:
                selection.transform.position = new Vector3(5.04f, 1.61f, 8.3f);
                LightBulb(lStat);
                tempskill = lStat;
                break;
            case 5:
                selection.transform.position = new Vector3(5.04f, 1.68f, 8.3f);
                LightBulb(aStat);
                tempskill = aStat;
                break;
            case 4:
                selection.transform.position = new Vector3(05.04f, 1.76f, 8.3f);
                LightBulb(iStat);
                tempskill = iStat;
                break;
            case 3:
                selection.transform.position = new Vector3(5.04f, 1.84f, 8.3f);
                LightBulb(cStat);
                tempskill = cStat;
                break;
            case 2:
                selection.transform.position = new Vector3(5.04f, 1.91f, 8.3f);
                LightBulb(eStat);
                tempskill = eStat;
                break;
            case 1:
                selection.transform.position = new Vector3(5.04f, 1.99f, 8.3f);
                LightBulb(pStat);
                tempskill = pStat;
                break;
            case 0:
                selection.transform.position = new Vector3(5.04f, 2.065f, 8.3f);
                LightBulb(sStat);
                tempskill = sStat;
                break;
        }

    }
 private void SetSelectedSkill( int temp)
    {
        switch (select)
        {
            case 6:
                lStat = temp;
                break;
            case 5:
                aStat = temp;
                break;
            case 4:
                iStat = temp;
                break;
            case 3:
                cStat = temp;
                break;
            case 2:
                eStat = temp;
                break;
            case 1:
                pStat = temp;
                break;
            case 0:
                sStat = temp;
                break;
        }
    }


    private void UpdateText()
    {
        points.text = skillpoints.ToString();
    }

    private void LightBulb(int skill) 
    {
        switch(skill)
        {
            case 10:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(true);
                break;
            case 9:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(true);
                b10.SetActive(false);
                break;
            case 8:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(true);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
            case 7:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(true);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
            case 6:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(true);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
            case 5:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(true);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
            case 4:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(true);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
            case 3:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(true);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
            case 2:
                b1.SetActive(false);
                b2.SetActive(true);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
            case 1:
                b1.SetActive(true);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;
/*            case 0:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                break;*/
        }
    }
}
