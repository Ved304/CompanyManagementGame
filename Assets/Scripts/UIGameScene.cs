using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIGameScene : MonoBehaviour
{
    private GameObject _gameManager;

    [SerializeField] private TMP_Text _budgetText;
    [SerializeField] private TMP_Text _currentDay;

    //Panels
    private GameObject _detailsPanel;
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

    //Details panel
    private GameObject _detailsContentRight;
    private GameObject _detailsContentLeft;

    [SerializeField] private TMP_Text _projectName;
    [SerializeField] private TMP_Text _projectDeadline;
    [SerializeField] private TMP_Text _projectStatus;
    [SerializeField] private TMP_Text _projectReward;
    [SerializeField] private TMP_Text _projectDifficulty;

    //Prefabs
    [SerializeField] private GameObject _prefabPersonItem;
    [SerializeField] private GameObject _prefabJobItem;
    [SerializeField] private GameObject _prefabProjectItem;

    public void SwitchToProjects()
    {
        _projectsPanel.SetActive(true);
        _HRPanel.SetActive(false);

        RefreshProjects();
    }

    public void SwitchToHR()
    {
        _projectsPanel.SetActive(false);
        _HRPanel.SetActive(true);

        RefreshHR();
    }

    public void RefreshHR()
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
            instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Salary.ToString() + "$";
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Skill.ToString();
            instantiated.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "Hire";
            instantiated.transform.GetChild(4).GetComponent<TMP_Text>().text = p.ID;
        }

        _employees = _employeeManager.GetComponent<EmployeeManager>().Employees;

        for (int i = 0; i < _HRContentLeft.transform.childCount; i++)
        {
            Destroy(_HRContentLeft.transform.GetChild(i).gameObject);
        }

        foreach (Person p in _employees)
        {
            GameObject instantiated = Instantiate(_prefabPersonItem, _HRContentLeft.transform);
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
            instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Salary.ToString() + "$";
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Skill.ToString();
            instantiated.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "Fire";
            instantiated.transform.GetChild(4).GetComponent<TMP_Text>().text = p.ID;
        }
    }

    public void RefreshProjects()
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
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Reward.ToString() + "$";
            instantiated.transform.GetChild(3).GetComponent<TMP_Text>().text = p.Difficulty.ToString();
        }

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
            instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Reward.ToString() + "$";
            instantiated.transform.GetChild(3).GetComponent<TMP_Text>().text = p.Difficulty.ToString();
        }
    }

    public void RefreshDetails(string name)
    {
        _projects = _projectsManager.GetComponent<ProjectsManager>().Projects;

        foreach(Project p in _projects)
        {
            if(p.Name == name)
            {
                _projectName.text = p.Name;
                _projectDeadline.text = "day " + p.Deadline.ToString();
                _projectStatus.text = p.Duration.ToString();
                _projectReward.text = p.Reward.ToString() + "$";
                _projectDifficulty.text = p.Difficulty.ToString();
            }
        }

        _employees = _employeeManager.GetComponent<EmployeeManager>().Employees;

        for (int i = 0; i < _detailsContentRight.transform.childCount; i++)
        {
            Destroy(_detailsContentRight.transform.GetChild(i).gameObject);
        }

        foreach (Person p in _employees)
        {
            if(p.AssignedProject != name)
            {
                GameObject instantiated = Instantiate(_prefabPersonItem, _detailsContentRight.transform);
                instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
                instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Salary.ToString() + "$";
                instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Skill.ToString();
                instantiated.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "Assign";
                instantiated.transform.GetChild(4).GetComponent<TMP_Text>().text = p.ID;
            }
        }

        for (int i = 0; i < _detailsContentLeft.transform.childCount; i++)
        {
            Destroy(_detailsContentLeft.transform.GetChild(i).gameObject);
        }

        foreach (Person p in _employees)
        {
            if(p.AssignedProject == name)
            {
                GameObject instantiated = Instantiate(_prefabPersonItem, _detailsContentLeft.transform);
                instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = p.Name;
                instantiated.transform.GetChild(1).GetComponent<TMP_Text>().text = p.Salary.ToString() + "$";
                instantiated.transform.GetChild(2).GetComponent<TMP_Text>().text = p.Skill.ToString();
                instantiated.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "Remove";
                instantiated.transform.GetChild(4).GetComponent<TMP_Text>().text = p.ID;
            }
        }
    }

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager");

        _detailsPanel = GameObject.Find("DetailsPanel");
        _projectsPanel = GameObject.Find("ProjectsPanel");
        _HRPanel = GameObject.Find("HRPanel");

        _employeeManager = GameObject.Find("EmployeeManager");
        _projectsManager = GameObject.Find("ProjectsManager");

        _HRContentRight = GameObject.Find("HRRightContent");
        _HRContentLeft = GameObject.Find("HRLeftContent");
        _jobsContent = GameObject.Find("JobsContent");
        _projectsContent = GameObject.Find("ProjectsContent");
        _detailsContentRight = GameObject.Find("DetailsContentRight");
        _detailsContentLeft = GameObject.Find("DetailsContentLeft");
    }

    private void Update()
    {
        int recruitmentCooldown = Mathf.RoundToInt(_employeeManager.GetComponent<EmployeeManager>().RecruitmentCooldown);
        _recruitmentCooldownTimer.text = recruitmentCooldown.ToString();

        _budgetText.text = _gameManager.GetComponent<GameManager>().Budget.ToString() + "$";
        _currentDay.text = "Day: " + _gameManager.GetComponent<GameManager>().CurrentDay.ToString();
    }
}
