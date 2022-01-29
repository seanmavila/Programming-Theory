using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    public Camera gameCamera;
    public float panSpeed = 10.0f;
    public GameObject marker;

    private Unit m_Selected = null;

    private void Start()
    {
        marker.SetActive(false);
    }

    public void HandleSelection()
    {
        var ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var unit = hit.collider.GetComponentInParent<Unit>();
            m_Selected = unit;

            var uiInfo = hit.collider.GetComponentInParent<MainUIHandler.IUIInfoContent>();
            MainUIHandler.Instance.SetNewInfoContent(uiInfo);
        }
    }

    public void HandleAction()
    {
        var ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            m_Selected.GoTo(hit.point);
        }
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        gameCamera.transform.position = gameCamera.transform.position + new Vector3(move.y, 0, -move.x) * panSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if (m_Selected != null && Input.GetMouseButtonDown(1))
        {
            HandleAction();
        }

        MarkerHandling();
    }

    void MarkerHandling()
    {
        if (m_Selected == null && marker.activeInHierarchy)
        {
            marker.SetActive(false);
            marker.transform.SetParent(null);
        }
        else if(m_Selected != null && marker.transform.parent != m_Selected.transform)
        {
            marker.SetActive(true);
            marker.transform.SetParent(m_Selected.transform, false);
            marker.transform.localPosition = Vector3.zero;
        }
    }
}
