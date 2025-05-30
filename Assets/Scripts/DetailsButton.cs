using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailsButton : MonoBehaviour
{
    GameObject detailsPanel;
    GameObject projectsPanel;

    private void Start()
    {
        detailsPanel = GameObject.Find("DetailsPanel");
        projectsPanel = GameObject.Find("ProjectsPanel");
    }

    public void OnClickDetails()
    {
        GameObject projectsManager = GameObject.Find("ProjectsManager");
        GameObject canvas = GameObject.Find("Canvas");
        string projectName = transform.parent.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text;

        projectsPanel.SetActive(false);
    }
}
