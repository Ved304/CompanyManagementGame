using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectsManager : MonoBehaviour
{
    private List<Project> _jobList = new List<Project>();
    private List<Project> _projectList = new List<Project>();
    private float _jobsCooldown = 100f;

    public void CreateJobList()
    {
        _jobList.Clear();
        _jobList.Add(new Project());
        _jobList.Add(new Project());
        _jobList.Add(new Project());
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
            _jobsCooldown = 100f;
        }
    }
}
