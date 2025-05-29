using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIGameScene : MonoBehaviour
{
    //Panels
    private GameObject _jobsPanel;
    private GameObject _projectsPanel;
    private GameObject _HRPanel;

    //HR panel
    private GameObject _employeeManager;
    [SerializeField] private TMP_Text _recruitmentCooldownTimer;
    private GameObject _HRContentRight;
    private GameObject _HRContentLeft;

    private List<Person> _candidates = new List<Person>();
    private List<Person> _employees = new List<Person>();

    //Job and project panel
    private GameObject _projectsManager;
    private GameObject _jobsContent;
    private GameObject _projectsContent;

    private List<Project> _projects = new List<Project>();
    private List<Project> _jobs = new List<Project>();

    //Prefabs
    [SerializeField] private GameObject _prefabPersonItem;
    [SerializeField] private GameObject _prefabJobItem;
    [SerializeField] private GameObject _prefabProjectItem;

    public void SwitchToJobs()
    {
        _jobsPanel.SetActive(true);
        _projectsPanel.SetActive(false);
        _HRPanel.SetActive(false);

        RefreshJobs();
    }

    public void SwitchToProjects()
    {
        _jobsPanel.SetActive(false);
        _projectsPanel.SetActive(true);
        _HRPanel.SetActive(false);

        RefreshProjects();
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

    public void RefreshJobs()
    {
        _jobs = _projectsManager.GetComponent<ProjectsManager>().Jobs;

        for (int i = 0; i < _jobsContent.transform.childCount; i++)
        {
            Destroy(_jobsContent.transform.GetChild(i).gameObject);
        }

        foreach (Project p in _jobs)
        {
            GameObject instantiated = Instantiate(_prefabJobItem, _jobsContent.transform);
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
            instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Duration.ToString();
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Reward.ToString();
            instantiated.transform.GetChild(3).GetComponent<TMP_Text>().text = p.Difficulty.ToString();
        }
    }

    public void RefreshProjects()
    {
        _projects = _projectsManager.GetComponent<ProjectsManager>().Projects;

        for (int i = 0; i < _projectsContent.transform.childCount; i++)
        {
            Destroy(_projectsContent.transform.GetChild(i).gameObject);
        }

        foreach (Project p in _projects)
        {
            GameObject instantiated = Instantiate(_prefabProjectItem, _projectsContent.transform);
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
            instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Duration.ToString();
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Reward.ToString();
            instantiated.transform.GetChild(3).GetComponent<TMP_Text>().text = p.Difficulty.ToString();
        }
    }

    private void Start()
    {
        _jobsPanel = GameObject.Find("JobsPanel");
        _projectsPanel = GameObject.Find("ProjectsPanel");
        _HRPanel = GameObject.Find("HRPanel");

        _employeeManager = GameObject.Find("EmployeeManager");
        _projectsManager = GameObject.Find("ProjectsManager");

        _HRContentRight = GameObject.Find("HRRightContent");
        _HRContentLeft = GameObject.Find("HRLeftContent");
        _jobsContent = GameObject.Find("JobsContent");
        _projectsContent = GameObject.Find("ProjectsContent");
    }

    private void Update()
    {
        int recruitmentCooldown = Mathf.RoundToInt(_employeeManager.GetComponent<EmployeeManager>().RecruitmentCooldown);
        _recruitmentCooldownTimer.text = recruitmentCooldown.ToString();
    }
}
