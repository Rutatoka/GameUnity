using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;
    public Tooltip tooltip;

    private void Awake()
    {
        current = this;
    }
    public static void Show(string content, string header="")
    {
        current.tooltip.SetText(content, header);
        current.tooltip.gameObject.SetActive(true);
    }

    // Update is called once per frame
   public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);

    }
}
