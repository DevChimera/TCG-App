using System;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class GameMaster : MonoBehaviour
{

    public Utils util;

    public GameObject cardPrefab;
    public GameObject healthPrefab;

    public HermitCardScriptable[] HermitsSO;

    public GameObject SelectedCard;

    public GameObject handObject;
    public List<GameObject> Hand;

    public bool isOverFrame = false;

    public GameObject ActiveHermit;

    public bool handShown = true;

    public RectTransform handRect;
    public RectTransform DropDownArrowRect;

    private void Start() {
        for (int i = 0; i < handObject.transform.childCount; i++)
        {
            Hand.Add(handObject.transform.GetChild(0).gameObject);
        }
    }

    public void ShowHideHand(){
        handShown = !handShown;
        if(handShown)handRect.anchoredPositionTransition_y(155,0.2f,LeanEase.Linear);
        else handRect.anchoredPositionTransition_y(-135,0.2f,LeanEase.Linear);

        if(handShown) DropDownArrowRect.RotateTransition(0f,0f,180f,0.2f,LeanEase.Linear);
        else DropDownArrowRect.RotateTransition(0f,0f,-180f,0.2f,LeanEase.Linear);
    }
}
