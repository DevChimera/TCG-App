using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler,IPointerExitHandler
{

    public bool Selected = false;
    public GameMaster gameMaster;
    public bool inHand =  true;

    public Utils util;

    private RectTransform rectTransform;

    private Transform returnableParent;

    private CanvasGroup canvasGroup;

    private Canvas parentCanvas;

    public Vector3 Offset = Vector3.zero;

    public Utils.CardType cardType;

    public GameObject emptyTempPrefab;

    public GameObject Temp;

    private Image img;


    private void Start() {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        parentCanvas = transform.root.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = true;

        img = GetComponent<Image>();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!inHand || gameMaster.SelectedCard != null) return;

        rectTransform.pivot = new Vector2(0.5f,0.0f);
        img.raycastPadding = new Vector4(0,-50,0,0);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(!inHand) return;

        rectTransform.pivot = new Vector2(0.5f,0.5f);
        img.raycastPadding = new Vector4(0,0,0,0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!inHand) return;

        rectTransform.localScale = Vector3.one * 1.2f;

        returnableParent = rectTransform.parent;

        Temp = Instantiate(emptyTempPrefab);
        Temp.transform.SetParent(returnableParent,false);
        Temp.transform.SetSiblingIndex(transform.GetSiblingIndex());

        rectTransform.SetParent(rectTransform.root,false);

        canvasGroup.blocksRaycasts = false;
        gameMaster.SelectedCard = this.gameObject;

        gameMaster.HideHand();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!inHand) return;

        rectTransform.anchorMax = new Vector2(0.5f,0.5f);
        rectTransform.anchorMin = new Vector2(0.5f,0.5f);

        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, eventData.position, parentCanvas.worldCamera, out mousePos);
        Vector2 pivotOffset = new Vector2(-0.5f, 0.5f);
        Vector2 snapPos = mousePos - pivotOffset * rectTransform.rect.size;
        rectTransform.anchoredPosition = snapPos;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!inHand) return;
        rectTransform.SetParent(returnableParent,false);
        rectTransform.localScale = Vector3.one * 2f;

        rectTransform.SetSiblingIndex(Temp.transform.GetSiblingIndex());
        Destroy(Temp);

        canvasGroup.blocksRaycasts = true;
        if(!gameMaster.isOverFrame)gameMaster.SelectedCard = null;
        gameMaster.ShowHand();
    }
}
