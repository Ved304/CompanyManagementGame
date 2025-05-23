using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameScene : MonoBehaviour
{
    [SerializeField] private GameObject _jobsPanel;
    [SerializeField] private GameObject _projectsPanel;
    [SerializeField] private GameObject _HRPanel;

    [SerializeField] private GameObject _employeeManager;
    [SerializeField] private TMP_Text _recruitmentCooldownTimer;

    [SerializeField] private GameObject _prefabPersonItem;
    [SerializeField] private GameObject _prefabJobItem;
    [SerializeField] private GameObject _prefabProjectItem;

    [SerializeField] private GameObject _HRContentRight;
    [SerializeField] private GameObject _HRContentLeft;

    private List<Person> _candidates = new List<Person>();

    public void SwitchToJobs()
    {
        _jobsPanel.SetActive(true);
        _projectsPanel.SetActive(false);
        _HRPanel.SetActive(false);
    }

    public void SwitchToProjects()
    {
        _jobsPanel.SetActive(false);
        _projectsPanel.SetActive(true);
        _HRPanel.SetActive(false);
    }

    public void SwitchToHR()
    {
        _jobsPanel.SetActive(false);
        _projectsPanel.SetActive(false);
        _HRPanel.SetActive(true);
    }

    public void StartRecruitment()
    {
        _candidates = _employeeManager.GetComponent<EmployeeManager>().CreateCandidateList();
        foreach (Person p in _candidates)
        {
            GameObject instantiated = Instantiate(_prefabPersonItem, _HRContentRight.transform);
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
            instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Salary.ToString();
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Skill.ToString();
            Debug.Log("Po inicjalizacji");
        }
    }

    private void Update()
    {
        int recruitmentCooldown = Mathf.RoundToInt(_employeeManager.GetComponent<EmployeeManager>().RecruitmentCooldown);
        _recruitmentCooldownTimer.text = recruitmentCooldown.ToString();
    }
}
