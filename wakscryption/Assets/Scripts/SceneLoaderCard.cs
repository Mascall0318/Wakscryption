using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderCard : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string sceneName;
    public Text sceneText;
    public string printedSceneText;
    public RectTransform targetArea;
    public float delayTime = 1.0f;

    public Image crossIcon;
    public Image emptyCard;
    public Image selectedCard;
    public Sprite brightCard;
    public Sprite brightSelectedCard;
    private Sprite originCard;
    private Sprite originalSelectedCard;
    public Sprite brightCross;
    private Sprite originCross;

    public GameObject placeHoldCard;
    private int placeHoldIndex;
    private Vector3 placeHoldPosition;
    private Transform placeHoldParent;

    private Vector3 originalPosition;
    private Transform originalParent;
    private int originalIndex;


    void Start()
    {
        placeHoldPosition = placeHoldCard.transform.position;
        placeHoldParent = placeHoldCard.transform.parent;
        originalIndex = transform.GetSiblingIndex();
        originalPosition = transform.position;
        originCross = crossIcon.sprite;
        originCard = emptyCard.sprite;
        originalSelectedCard = selectedCard.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        selectedCard.sprite = brightSelectedCard;
        crossIcon.sprite = brightCross;
        emptyCard.sprite = brightCard;
        sceneText.text = "- " + printedSceneText + " -";

        if (originalParent == null)
        {
            originalParent = transform.parent;
        }

        transform.position = eventData.position;
        transform.SetParent(originalParent.parent);

        placeHoldIndex = originalIndex;
        placeHoldCard.transform.position = originalPosition;
        placeHoldCard.transform.SetParent(originalParent);
        if (placeHoldCard.transform.GetSiblingIndex() > placeHoldIndex)
            placeHoldCard.transform.SetSiblingIndex(placeHoldIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent.parent);
        if (RectTransformUtility.RectangleContainsScreenPoint(targetArea, eventData.position))
        {
            Invoke("LoadScene", delayTime);
            transform.position = targetArea.position;
        }
        else
        {
            placeHoldCard.transform.SetParent(placeHoldParent);
            placeHoldCard.transform.position = placeHoldPosition;

            selectedCard.sprite = originalSelectedCard;
            transform.position = originalPosition;
            transform.SetParent(originalParent);
            crossIcon.sprite = originCross;
            emptyCard.sprite = originCard;
            if(transform.GetSiblingIndex()>originalIndex)
                transform.SetSiblingIndex(originalIndex);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
