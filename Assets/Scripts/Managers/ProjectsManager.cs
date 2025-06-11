using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectsManager : MonoBehaviour
{
    private List<Project> _jobList = new List<Project>();
    private List<Project> _projectList = new List<Project>();
    private float _jobsCooldown = 10 * GameManager.DAY;

    public void CreateJobList()
    {
        _jobList.Clear();
        for(int i = 0; i < 6; i++)
        {
            _jobList.Add(new Project());
        }
    }

    public void AcceptProject(string name)
    {
        foreach (Project p in _jobList)
        {
            if(p.Name == name)
            {
                p.IsTaken = true;
                _projectList.Add(p);
                _jobList.Remove(p);
                break;
            }
        }
    }

    public void CallAdvancing()
    {
        foreach (Project p in _projectList)
        {
            p.AdvanceProject();
        }
    }

    public List<Project> Jobs
    {
        get { return _jobList; }
        private set { }
    }

    public List<Project> Projects
    {
        get { return _projectList; }
        private set { }
    }

    private void Start()
    {
        CreateJobList();

        InvokeRepeating("CallAdvancing", GameManager.DAY, GameManager.DAY);
    }

    private void Update()
    {
        if(_jobsCooldown > 0)
        {
            _jobsCooldown -= Time.deltaTime;
        }
        else
        {
            CreateJobList();
            _jobsCooldown = 10 * GameManager.DAY;
        }

        foreach(Project p in _projectList)
        {
            if(p.Deadline < GameObject.Find("GameManager").GetComponent<GameManager>().CurrentDay)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().GivePenalty(p.Penalty);
                GameObject.Find("EmployeeManager").GetComponent<EmployeeManager>().UnassignMany(p.Name);
                _projectList.Remove(p);
            }
        }
    }
}
