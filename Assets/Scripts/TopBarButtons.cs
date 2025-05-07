using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBarButtons : MonoBehaviour
{
    [SerializeField] private GameObject _projectsPanel;
    [SerializeField] private GameObject _managementPanel;
    [SerializeField] private GameObject _HRPanel;

    public void SwitchToProjects()
    {
        _projectsPanel.SetActive(true);
        _managementPanel.SetActive(false);
        _HRPanel.SetActive(false);
    }

    public void SwitchToManagement()
    {
        _projectsPanel.SetActive(false);
        _managementPanel.SetActive(true);
        _HRPanel.SetActive(false);
    }

    public void SwitchToHR()
    {
        _projectsPanel.SetActive(false);
        _managementPanel.SetActive(false);
        _HRPanel.SetActive(true);
    }
}
