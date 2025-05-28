using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    private List<Person> _employees = new List<Person>();

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

    public void RefreshCandidates()
    {
        _candidates = _employeeManager.GetComponent<EmployeeManager>().Candidates;

        for (int i = 0; i < _HRContentRight.transform.childCount; i++)
        {
            Destroy(_HRContentRight.transform.GetChild(i).gameObject);
        }

        foreach (Person p in _candidates)
        {
            GameObject instantiated = Instantiate(_prefabPersonItem, _HRContentRight.transform);
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
            instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Salary.ToString();
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Skill.ToString();
            instantiated.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "Hire";
            instantiated.transform.GetChild(4).GetComponent<TMP_Text>().text = p.ID;
        }
    }

    public void RefreshEmployees()
    {
        _employees = _employeeManager.GetComponent<EmployeeManager>().Employees;

        for (int i = 0; i < _HRContentLeft.transform.childCount; i++)
        {
            Destroy(_HRContentLeft.transform.GetChild(i).gameObject);
        }

        foreach (Person p in _employees)
        {
            GameObject instantiated = Instantiate(_prefabPersonItem, _HRContentLeft.transform);
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
            instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Salary.ToString();
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Skill.ToString();
            instantiated.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "Fire";
            instantiated.transform.GetChild(4).GetComponent<TMP_Text>().text = p.ID;
        }
    }

    public void HireOrFire(GameObject clickedButton)
    {
        string personID = clickedButton.transform.parent.gameObject.transform.GetChild(4).GetComponent<TMP_Text>().text;

        if(clickedButton.transform.GetChild(0).GetComponent<TMP_Text>().text == "Hire")
        {
            _employeeManager.GetComponent<EmployeeManager>().Hire(personID);
        }
        else if(clickedButton.transform.GetChild(0).GetComponent<TMP_Text>().text == "Fire")
        {
            _employeeManager.GetComponent<EmployeeManager>().Fire(personID);
        }

        RefreshCandidates();
        RefreshEmployees();
    }

    private void Update()
    {
        int recruitmentCooldown = Mathf.RoundToInt(_employeeManager.GetComponent<EmployeeManager>().RecruitmentCooldown);
        _recruitmentCooldownTimer.text = recruitmentCooldown.ToString();
    }
}
