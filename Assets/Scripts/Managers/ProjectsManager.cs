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
                _projectList.Add(p);
                _jobList.Remove(p);
                break;
            }
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
    }
}
