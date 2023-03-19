using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public HermitCard hc;

    public TextMeshProUGUI health;

    public Image bg,healthBG;
    private void Start() {
        UpdateDetails();
    }

    public void UpdateDetails(){
        health.text = hc.hcs.Health.ToString();
        Color c;
        if(hc.hcs.Health > 200) c = new Color32(0,220,0,255);
        else if(hc.hcs.Health > 100) c = new Color32(255,155,0,255);
        else c = new Color32(220,0,0,255);
        bg.color = healthBG.color = c;
    }
}
