using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatAction : MonoBehaviour
{
	private List<GameObject> ListBrand = new List<GameObject>();
    private List<GameObject> ListSkill = new List<GameObject>();
    private List<GameObject> ListWeapon = new List<GameObject>();
    private BrandType[] skills = new BrandType[3];

    // Use this for initialization
    void Start()
    {
        ListBrand.Add(GameObject.Find("Brand1"));
        ListBrand.Add(GameObject.Find("Brand2"));
        ListBrand.Add(GameObject.Find("Brand3"));
        ListBrand.Add(GameObject.Find("Brand4"));
        ListBrand.Add(GameObject.Find("Brand5"));

        ListSkill.Add(GameObject.Find("btnSkill1"));
        ListSkill.Add(GameObject.Find("btnSkill2"));
        ListSkill.Add(GameObject.Find("btnSkill3"));

        ListWeapon.Add(GameObject.Find("btnWeapon1"));
        ListWeapon.Add(GameObject.Find("btnWeapon2"));
        ListWeapon.Add(GameObject.Find("btnWeapon3"));
        SGlobal.XSHitTest.Up2DEvent += new SHitTest.Up2DEventHandler(XSHitTest_Up2DEvent);
        skills[0] = BrandType.金;
        skills[1] = BrandType.木;
        skills[2] = BrandType.水;
        SetSkillColor();
        AddBrand();
    }

    void XSHitTest_Up2DEvent(RaycastHit2D hit)
    {
        SelectBrand(hit.transform.name);
    }

    void SelectBrand(string btnSkill)
    {
        bool hasSelect=false;
        foreach (var tmpBrand in ListBrand)
        {
            MBrand tmpPaiColor = tmpBrand.GetComponent<MBrand>();
            if (((btnSkill == "btnSkill1" && tmpPaiColor.Type == skills[0])
                || (btnSkill == "btnSkill2" && tmpPaiColor.Type == skills[1])
                || (btnSkill == "btnSkill3" && tmpPaiColor.Type == skills[2])
                ) && tmpPaiColor.IsSelect)
            {
                tmpBrand.transform.parent.Translate(0, -0.5f, 0);
                tmpPaiColor.IsSelect = false;
                tmpPaiColor.IsOut = true;
                Animator animator = tmpBrand.GetComponent<Animator>();
                animator.SetInteger("state", 2);
                hasSelect = true;
            }
            else if (tmpPaiColor.IsSelect)
            {
                hasSelect = false;
                break;
            }
        }
        if (hasSelect)
        {
            return;
        }
        if (btnSkill == "btnSkill1")
        {
            foreach (var tmpBrand in ListBrand)
            {
                MBrand tmpPaiColor = tmpBrand.GetComponent<MBrand>();
                if (tmpPaiColor.Type == skills[0] && tmpPaiColor.IsSelect == false)
                {
                    tmpBrand.transform.parent.Translate(0, 0.5f, 0);
                    tmpPaiColor.IsSelect = true;
                }
                else if (tmpPaiColor.IsSelect == true)
				{
                    tmpBrand.transform.parent.Translate(0 , -0.5f, 0);
                    tmpPaiColor.IsSelect = false;
                }
            }
        }
        else if (btnSkill == "btnSkill2")
        {
            foreach (var tmpBrand in ListBrand)
            {
                MBrand tmpPaiColor = tmpBrand.GetComponent<MBrand>();
                if (tmpPaiColor.Type == skills[1] && tmpPaiColor.IsSelect == false)
                {
                    tmpBrand.transform.parent.Translate(0, 0.5f, 0);
                    tmpPaiColor.IsSelect = true;
                }
                else if (tmpPaiColor.IsSelect == true)
                {
                    tmpBrand.transform.parent.Translate(0, -0.5f, 0);
                    tmpPaiColor.IsSelect = false;
                }
            }
        }
        else if (btnSkill == "btnSkill3")
        {
            foreach (var tmpBrand in ListBrand)
            {
                MBrand tmpPaiColor = tmpBrand.GetComponent<MBrand>();
                if (tmpPaiColor.Type == skills[2] && tmpPaiColor.IsSelect == false)
                {
                    tmpBrand.transform.parent.Translate(0, 0.5f, 0);
                    tmpPaiColor.IsSelect = true;
                }
                else if (tmpPaiColor.IsSelect == true)
                {
                    tmpBrand.transform.parent.Translate(0, -0.5f, 0);
                    tmpPaiColor.IsSelect = false;
                }
            }
        }
    }

    void SetSkillColor()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            Color downColor = new Color(0.8f, 0.8f, 0.8f);
            Color hoverColor = new Color(1.2f, 1.2f, 1.2f);
            SButton2D_2 tmpSButton2D_2 = ListSkill[i].GetComponent<SButton2D_2>();
            switch (skills[i])
            {
                case BrandType.金:
                    tmpSButton2D_2.SetColor(SGlobal.ThisGlobal.金, SGlobal.ThisGlobal.金 * downColor, SGlobal.ThisGlobal.金 * hoverColor);
                    break;
                case BrandType.木:
                    tmpSButton2D_2.SetColor(SGlobal.ThisGlobal.木, SGlobal.ThisGlobal.木 * downColor, SGlobal.ThisGlobal.木 * hoverColor);
                    break;
                case BrandType.水:
                    tmpSButton2D_2.SetColor(SGlobal.ThisGlobal.水, SGlobal.ThisGlobal.水 * downColor, SGlobal.ThisGlobal.水 * hoverColor);
                    break;
                case BrandType.火:
                    tmpSButton2D_2.SetColor(SGlobal.ThisGlobal.火, SGlobal.ThisGlobal.火 * downColor, SGlobal.ThisGlobal.火 * hoverColor);
                    break;
                case BrandType.土:
                    tmpSButton2D_2.SetColor(SGlobal.ThisGlobal.土, SGlobal.ThisGlobal.土 * downColor, SGlobal.ThisGlobal.土 * hoverColor);
                    break;
            }
        }
    }

    public void AddBrand()
    {
        foreach (var tmpBrand in ListBrand)
        {
            MBrand tmpMBrand = tmpBrand.GetComponent<MBrand>();
            if (tmpMBrand.IsOut)
            {
                Animator animator = tmpBrand.GetComponent<Animator>();
                animator.SetInteger("state", 1);
                animator.Play("ANMTBrand1");
                tmpMBrand.SetType((BrandType)Random.Range(0, 4));
                tmpMBrand.IsOut = false;
                tmpMBrand.IsSelect = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var tmpBrand in ListBrand)
        {
            MBrand tmpMBrand = tmpBrand.GetComponent<MBrand>();
            if (tmpMBrand.IsOut)
            {
                Animator animator = tmpBrand.GetComponent<Animator>();
                if (animator.GetInteger("state") == 0)
                {
                    AddBrand();
                }
            }
        }
    }
}
