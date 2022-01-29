using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopup : MonoBehaviour
{
    public Text Name;
    public Text Data;
    public RectTransform ContentTransform;

    public ContentEntry EntryPrefab;

    public void ClearContent()
    {
        foreach (Transform child in ContentTransform)
        {
            DestroyImmediate(child.gameObject, true);
        }
    }

    public void AddToContent(int count, Sprite Icon)
    {
        var newEntry = Instantiate(EntryPrefab, ContentTransform);

        newEntry.Count.text = count.ToString();
        newEntry.Icon.sprite = Icon;
    }
}
