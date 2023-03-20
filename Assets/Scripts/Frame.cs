using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Frame : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    public GameMaster gameMaster;

    public Utils.CardType allowedType;

    public Color ogColor,hoveredColor;

    private void Start() {
       gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
       ogColor = GetComponent<Image>().color;
       float factor = 0.6f;
       hoveredColor = new Color(ogColor.r * factor,ogColor.g * factor,ogColor.b * factor,ogColor.a);
    }

    public void OnDrop(PointerEventData eventData)
    {

        Card cd = eventData.pointerDrag.transform.GetComponent<Card>();

        if(allowedType != cd.cardType) {
            gameMaster.SelectedCard = null;
            return;
        };
        
        if(gameMaster.SelectedCard){
            GameObject slot = transform.parent.gameObject;
            gameMaster.Hand.Remove(gameMaster.SelectedCard);
            GameObject newCard = Instantiate(gameMaster.SelectedCard);
            newCard.GetComponent<Card>().inHand = false;

            setScaleForCard(newCard);

            newCard.transform.SetParent(slot.transform,false);

            if(cd.cardType == Utils.CardType.HermitCard){
                GameObject newHealthCard = Instantiate(gameMaster.healthPrefab);
                setScaleForCard(newHealthCard);
                newHealthCard.GetComponent<Health>().hc = newCard.GetComponent<HermitCard>();
                newHealthCard.transform.SetParent(slot.transform.parent.GetChild(0),false);

                if(!gameMaster.ActiveHermit){
                    newCard.GetComponent<HermitCard>().ActivateHermit();
                }else{
                    newCard.GetComponent<HermitCard>().DeActivateHermit();
                }

            }

            Destroy(cd.Temp);
            Destroy(gameMaster.SelectedCard);
            gameMaster.SelectedCard = null;
            gameMaster.ShowHand();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = hoveredColor;
        gameMaster.isOverFrame = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = ogColor;
        gameMaster.isOverFrame = false;
    }

    void setScaleForCard(GameObject g){
        RectTransform rt = g.GetComponent<RectTransform>();

        rt.localScale = Vector3.one * 1.2f;

        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);

        rt.pivot = new Vector2(0.5f, 0.5f);

        rt.anchoredPosition = new Vector2(0f, 0f);
    }
}
