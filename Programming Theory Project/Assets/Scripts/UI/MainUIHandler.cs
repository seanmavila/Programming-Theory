using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public static MainUIHandler Instance { get; private set; }

    public interface IUIInfoContent
    {
        string GetName();

        string GetData();
    }

    public InfoPopup InfoPopup;

    protected IUIInfoContent m_CurrentContent;

    private void Awake()
    {
        Instance = this;
        InfoPopup.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Update()
    {
        if (m_CurrentContent == null)
        {
            return;
        }

        InfoPopup.Data.text = m_CurrentContent.GetData();

        InfoPopup.ClearContent();
       
    }

    public void SetNewInfoContent(IUIInfoContent content)
    {
        if (content == null)
        {
            InfoPopup.gameObject.SetActive(false);
        }
        else
        {
            InfoPopup.gameObject.SetActive(true);
            m_CurrentContent = content;
            InfoPopup.Name.text = content.GetName();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
