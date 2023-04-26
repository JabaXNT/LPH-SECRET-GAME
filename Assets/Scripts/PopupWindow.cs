using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PopupWindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject popupWindow;
    public string textToShow;

    private Text popupText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (popupWindow != null)
        {
            popupWindow.SetActive(true);
            popupWindow.GetComponentInChildren<TextMeshProUGUI>().text = textToShow;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Скрываем всплывающее окно
        popupWindow.SetActive(false);
    }
}
