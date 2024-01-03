using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GroupSelectCard : MonoBehaviour, IPointerClickHandler 
{
    [Header("테스트용으로 public전환")]
    public bool isUnlock;

    public Text groupName;
    public string groupNameIs;
    public Text groupExplaination;
    [TextArea]
    public string groupExplain;

    public RectTransform targetArea;
    public GameObject loadedPanel;

    private Vector2 originalCardSize = new Vector2();
    private Vector2 originaIconSize = new Vector2();

    public GameObject placeHoldCard;
    private int placeHoldIndex;
    private Vector3 placeHoldPosition;
    private Transform placeHoldParent;

    private Vector3 originalPosition;
    private Transform originalParent;
    private int originalIndex;

    public GameObject startButton;

    private bool isClcik = false;

    void Start()
    {
        originalCardSize = this.transform.GetComponent<RectTransform>().sizeDelta;
        if (isUnlock)
        {
            if (this.transform.childCount > 1 && this.transform.GetChild(1).gameObject.activeSelf == true)
                originaIconSize = this.transform.GetChild(1).transform.GetComponent<RectTransform>().sizeDelta;
        }
        else if (!isUnlock)
        {
            if (this.transform.childCount > 0 && this.transform.GetChild(0).gameObject.activeSelf == true)
                originaIconSize = this.transform.GetChild(0).transform.GetComponent<RectTransform>().sizeDelta;
        }
        originalIndex = transform.GetSiblingIndex();
        originalParent = transform.parent;
        originalPosition = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClcik)
        {

            groupName.text = "[" + groupNameIs + "]";
            if (isUnlock)
            {
                groupExplaination.text = groupExplain;
                startButton.SetActive(true);
            }
            else if (!isUnlock)
            {
                groupExplaination.text = "잠겨있습니다";
                startButton.SetActive(false);
            }
            placeHoldPosition = placeHoldCard.transform.position;
            placeHoldParent = placeHoldCard.transform.parent;

            if (originalParent == null)
            {
                originalParent = transform.parent;
            }

            loadedPanel.SetActive(true);

            placeHoldIndex = originalIndex;
            placeHoldCard.transform.position = originalPosition;
            placeHoldCard.transform.SetParent(originalParent);

            if (placeHoldCard.transform.GetSiblingIndex() > placeHoldIndex)
                placeHoldCard.transform.SetSiblingIndex(placeHoldIndex);

            transform.SetParent(originalParent.parent);
            transform.position = targetArea.position;

            RectTransform cardRectTransform = this.transform.GetComponent<RectTransform>();
            cardRectTransform.sizeDelta = new Vector2(originalCardSize.x * 1.5f, originalCardSize.y * 1.5f);
            if (isUnlock)
            {
                if (this.transform.childCount > 1 && this.transform.GetChild(1).gameObject.activeSelf == true)
                {
                    RectTransform iconRectTransform = this.transform.GetChild(1).GetComponent<RectTransform>();
                    iconRectTransform.sizeDelta = new Vector2(originaIconSize.x * 1.5f, originaIconSize.y * 1.5f);
                }
            }
            else if (!isUnlock)
            {
                if (this.transform.childCount > 0 && this.transform.GetChild(0).gameObject.activeSelf == true)
                {
                    RectTransform lockRectTransform = this.transform.GetChild(0).GetComponent<RectTransform>();
                    lockRectTransform.sizeDelta = new Vector2(originaIconSize.x * 1.5f, originaIconSize.y * 1.5f);
                }
            }


            isClcik = true;
        }
    }

    public void ResetPanel()
    {
        if (isClcik)
        {
            transform.position = originalPosition;
            transform.SetParent(originalParent);
            if (transform.GetSiblingIndex() > originalIndex)
                transform.SetSiblingIndex(originalIndex);


            RectTransform cardRectTransform = this.transform.GetComponent<RectTransform>();
            cardRectTransform.sizeDelta = originalCardSize;
            if (isUnlock)
            {
                if (this.transform.childCount > 1 && this.transform.GetChild(1).gameObject.activeSelf == true)
                {
                    RectTransform iconRectTransform = this.transform.GetChild(1).GetComponent<RectTransform>();
                    iconRectTransform.sizeDelta = originaIconSize;
                }
            }
            else if (!isUnlock)
            {
                if (this.transform.childCount > 0 && this.transform.GetChild(0).gameObject.activeSelf == true)
                {
                    RectTransform lockRectTransform = this.transform.GetChild(0).GetComponent<RectTransform>();
                    lockRectTransform.sizeDelta = originaIconSize;
                }
            }

            isClcik = false;
        }
    }
}
