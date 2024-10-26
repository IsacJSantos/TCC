using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform dragObjRect;
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;

    public void OnBegingDrag(BaseEventData eventData)
    {
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

        CommandBeltContainer beltContainer = raycastResults[0].gameObject.GetComponent<CommandBeltContainer>();

        if (beltContainer == null) return;

        beltContainer.OnDropCommand(eventData.selectedObject.GetComponent<CommandSelector>());

    }
}
