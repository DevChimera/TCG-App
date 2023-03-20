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

    private void Start() {
        for (int i = 0; i < handObject.transform.childCount; i++)
        {
            Hand.Add(handObject.transform.GetChild(0).gameObject);
        }
    }

    public void ShowHand(){
        handShown = true;
        handRect.anchoredPositionTransition_y(155,0.2f,LeanEase.Linear);
    }

    public void HideHand(){
        handShown = false;
        handRect.anchoredPositionTransition_y(-135,0.2f,LeanEase.Linear);
    }
}
