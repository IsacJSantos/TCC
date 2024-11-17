using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class DragHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform dragObjRect;
    [SerializeField]
    private TextMeshProUGUI dragObjRectText;
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;
    [SerializeField]
    private CommandSelector currentSelector;

    public void OnBegingDrag(BaseEventData eventData)
    {
        currentSelector = eventData.selectedObject.GetComponent<CommandSelector>();
        dragObjRectText.text = currentSelector.CommandName;
        dragObjRect.gameObject.SetActive(true);
    }

    public void OnDrag(BaseEventData eventData)
    {
        dragObjRect.position = eventData.currentInputModule.input.mousePosition;
    }

    public void OnEndDrag(BaseEventData eventData)
    {
        dragObjRect.gameObject.SetActive(false);

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        graphicRaycaster.Raycast((PointerEventData)eventData, raycastResults);

        if (raycastResults == null || raycastResults.Count == 0) return;

        IBeltContainer beltContainer = raycastResults[0].gameObject.GetComponent<IBeltContainer>();

        if (beltContainer == null) return;

        beltContainer.OnDropCommand(currentSelector);
        currentSelector = null;
    }
}
