using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public void OnPointEnter(PointerEventData eventData)
    //  {

    //  }
    //   public void OnPointEnter(PointerEventData eventData)
    //  {

    //  }
    public string content;
    public string header;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData)
    {
       // TooltipSystem.Show(content,header);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
      //  TooltipSystem.Hide();
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
