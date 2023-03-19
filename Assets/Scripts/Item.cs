using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Utils.Types type;

    public Utils.Rarity rarity;

    public Image bg;

    public Image Type;

    public GameObject rarityAmount;

    public GameMaster gm;

    public Card crd;

    private void Start() {
        gm = FindAnyObjectByType<GameMaster>();
        int i = (int)type;

        Type.sprite = gm.util.TypesIcon[i];
        bg.color = gm.util.TypesBGColors[i];
        rarityAmount.SetActive(rarity == Utils.Rarity.Rare);

        crd.cardType = Utils.CardType.ItemCard;
    }
}
