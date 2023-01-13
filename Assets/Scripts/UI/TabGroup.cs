using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
#pragma warning disable CS0436 // Type conflicts with imported type
    public List<TabButton> tabButtons;

    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;

    public TabButton selectedTab;

    public List<GameObject> objectToSwap;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons= new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabIdle;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelect(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }

        selectedTab = button;

        selectedTab.Select();

        ResetTabs();
        button.background.sprite = tabIdle;

        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectToSwap.Count; i++)
        {
            if (i == index)
            {
                objectToSwap[i].SetActive(true);
            }
            else
            {
                objectToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab){continue;}
            button.background.sprite = tabIdle;
        }
    }
}
