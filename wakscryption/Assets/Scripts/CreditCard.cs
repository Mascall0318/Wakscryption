using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditCard : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject who;
    [Tooltip("카페 닉네임")]
    public string whoName;
    [Tooltip("프로젝트에서 맡은 역할")]
    public string whoPart;
    public Text Message;

    public RectTransform targetArea;
    public GameObject loadedPanel;

    public GameObject placeHoldCard;
    private int placeHoldIndex;
    private Vector3 placeHoldPosition;
    private Transform placeHoldParent;

    public Image emptyCard;
    public Sprite brightCard;
    private Sprite originCard;

    private Vector3 originalPosition;
    private Transform originalParent;
    private int originalIndex;

    void Start()
    {
        placeHoldPosition = placeHoldCard.transform.position;
        placeHoldParent = placeHoldCard.transform.parent;
        originalIndex = transform.GetSiblingIndex();
        originalParent = transform.parent;
        originalPosition = transform.position;
        originCard = emptyCard.sprite;
}

    public void OnDrag(PointerEventData eventData)
    {
        emptyCard.sprite = brightCard;

        if (originalParent == null)
        {
            originalParent = transform.parent;
        }

        transform.position = eventData.position;
        transform.SetParent(originalParent.parent.parent);

        placeHoldIndex = originalIndex;
        placeHoldCard.transform.position = originalPosition;
        placeHoldCard.transform.SetParent(originalParent);
        if (placeHoldCard.transform.GetSiblingIndex() > placeHoldIndex)
            placeHoldCard.transform.SetSiblingIndex(placeHoldIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent.parent.parent);
        if (RectTransformUtility.RectangleContainsScreenPoint(targetArea, eventData.position))
        {
            LoadPanel(loadedPanel);
            transform.position = targetArea.position;
            who.SetActive(true);
            Message.text = "[ " + whoPart + " ]\n" + whoName;
        }
        else
        {
            placeHoldCard.transform.SetParent(placeHoldParent);
            placeHoldCard.transform.position = placeHoldPosition;

            transform.position = originalPosition;
            transform.SetParent(originalParent);
            emptyCard.sprite = originCard;
            if (transform.GetSiblingIndex() > originalIndex)
                transform.SetSiblingIndex(originalIndex);
        }
    }

    public void LoadPanel(GameObject whichPanel)
    {
        whichPanel.SetActive(true);
    }

    public void ResetPanel()
    {
        placeHoldCard.transform.SetParent(placeHoldParent);
        placeHoldCard.transform.position = placeHoldPosition;

        transform.position = originalPosition;
        transform.SetParent(originalParent);
        emptyCard.sprite = originCard;
        if (transform.GetSiblingIndex() > originalIndex)
            transform.SetSiblingIndex(originalIndex);

        Message.text = "[ ]";
        who.SetActive(false);
    }
}
