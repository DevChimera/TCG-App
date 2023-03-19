using UnityEngine;

[CreateAssetMenu(fileName = "HermitCardScriptable", menuName = "HC-TCG/HermitCard", order = 0)]
public class HermitCardScriptable : ScriptableObject {

    public string Name;
    public int MaxHealth;
    public int Health;
    public string Description;
    public string PrimaryAttackName;
    public string SecondaryAttackName;
    public int PrimaryAttackDamage;
    public int SecondaryAttackDamage;
    public Utils.Types[] PrimaryAttackCost = new Utils.Types[3];
    public Utils.Types[] SecondaryAttackCost = new Utils.Types[3];
    public Utils.Types[] Strengths = new Utils.Types[1];
    public Utils.Types[] Weaknesses = new Utils.Types[1];
    public Utils.Types HermitType;
    public Utils.Rarity Rarity;
    public int index;

    public Color PrimaryColor = Color.red;
    public Color SecondaryColor = Color.red;
}
