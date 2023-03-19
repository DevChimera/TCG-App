using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HermitCard : MonoBehaviour
{
    public HermitCardScriptable hcs;

    public GameMaster gameMaster;

    public Image HermitBG;
    public Image Hermit;
    public Image HermitType;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI PrimaryAttackName;
    public TextMeshProUGUI PrimaryAttackDamage;
    public TextMeshProUGUI SecondaryAttackName;
    public TextMeshProUGUI SecondaryAttackDamage;

    public GameObject[] PrimarySlots;
    public GameObject[] SecondarySlots;

    public GameObject Rare;
    public GameObject UltraRare;

    public bool active = false;
    public Card crd;

    public bool isActiveHermit = false;

    private void Start() {

        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        crd.cardType = Utils.CardType.HermitCard;


        HermitBG.sprite =  gameMaster.util.HermitsBG[hcs.index];
        Hermit.sprite =  gameMaster.util.Hermits[hcs.index];
        HermitType.sprite =  gameMaster.util.TypesIcon[(int)hcs.HermitType];

        Name.text = hcs.Name;
        Health.text = hcs.Health.ToString();
        PrimaryAttackName.text = hcs.PrimaryAttackName;
        PrimaryAttackDamage.text = hcs.PrimaryAttackDamage + "";
        SecondaryAttackName.text = hcs.SecondaryAttackName;
        SecondaryAttackDamage.text = hcs.SecondaryAttackDamage + "";

        Rare.SetActive(hcs.Rarity == Utils.Rarity.Rare);
        UltraRare.SetActive(hcs.Rarity == Utils.Rarity.UltraRare);

        PrimaryAttackDamage.color = hcs.PrimaryColor;
        SecondaryAttackDamage.color = hcs.SecondaryColor;
        

        if(hcs.PrimaryAttackCost.Length == 1){
            PrimarySlots[0].SetActive(false);
            PrimarySlots[2].SetActive(false);

            PrimarySlots[1].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.PrimaryAttackCost[0]];
        }else if(hcs.PrimaryAttackCost.Length == 3){
            PrimarySlots[0].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.PrimaryAttackCost[0]];
            PrimarySlots[1].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.PrimaryAttackCost[1]];
            PrimarySlots[2].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.PrimaryAttackCost[2]];
        }else if(hcs.PrimaryAttackCost.Length == 2){

            PrimarySlots[1].SetActive(false);
            RectTransform rt = PrimarySlots[1].transform.parent.GetComponent<RectTransform>();

            rt.sizeDelta = new Vector2(20f, rt.sizeDelta.y);

            PrimarySlots[0].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.PrimaryAttackCost[0]];
            PrimarySlots[2].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.PrimaryAttackCost[1]];
        }

        if(hcs.SecondaryAttackCost.Length == 1){
            SecondarySlots[0].SetActive(false);
            SecondarySlots[2].SetActive(false);

            SecondarySlots[1].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.SecondaryAttackCost[0]];
        }else if(hcs.SecondaryAttackCost.Length == 3){
            SecondarySlots[0].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.SecondaryAttackCost[0]];
            SecondarySlots[1].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.SecondaryAttackCost[1]];
            SecondarySlots[2].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.SecondaryAttackCost[2]];
        }else if(hcs.SecondaryAttackCost.Length == 2){

            SecondarySlots[1].SetActive(false);
            RectTransform rt = SecondarySlots[1].transform.parent.GetComponent<RectTransform>();

            rt.sizeDelta = new Vector2(20f, rt.sizeDelta.y);

            SecondarySlots[0].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.SecondaryAttackCost[0]];
            SecondarySlots[2].GetComponent<Image>().sprite = gameMaster.util.TypesIcon[(int)hcs.SecondaryAttackCost[1]];
        }

    }

    public void ActivateHermit()
    {
        isActiveHermit = true;
        if(gameMaster.ActiveHermit) gameMaster.ActiveHermit.GetComponent<HermitCard>().DeActivateHermit();
        gameMaster.ActiveHermit = gameObject;
        transform.rotation = Quaternion.identity;
    }

    public void DeActivateHermit()
    {
        isActiveHermit = false;
        if(gameMaster.ActiveHermit == gameObject) gameMaster.ActiveHermit = null;
        transform.Rotate(new Vector3(0,0,-90));
    }
}
