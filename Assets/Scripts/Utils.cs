using UnityEngine;

[CreateAssetMenu(fileName = "Utils", menuName = "HC-TCG/Util", order = 1)]
public class Utils : ScriptableObject{

    public Sprite[] Hermits;
    public Sprite[] HermitsBG;
    public Sprite[] TypesIcon;
    public Sprite[] Effects;
    public Sprite[] HermitsEmoji;

    public Color32[] TypesBGColors;

    public RuntimeAnimatorController boardCardController;

    public enum Types{
        Builder = 0,
        Balanced = 1,
        Explorer = 2,
        Pvp = 3,
        Prankster = 4,
        Redstone = 5,
        Farm = 6,
        Miner = 7,
        Speedrunner = 8,
        Terraform = 9,
        Any = 10,
        None = 11
    }

    public enum Rarity{
        Common = 0,
        Rare = 1,
        UltraRare = 2
    }

    public enum CardType{
        HermitCard = 0,
        ItemCard = 1,
        EffectCard = 2,
        SingleUseEffectCard = 3,
        HealthCard = 4
    }
}
