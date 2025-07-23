using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject selectObj;
    public void OnPointerEnter(PointerEventData eventData)
    {
        selectObj.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        selectObj.SetActive(false);
    }
}
