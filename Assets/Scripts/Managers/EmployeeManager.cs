using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EmployeeManager : MonoBehaviour
{
    private List<Person> _employeeList = new List<Person>();
    private List<Person> _candidateList = new List<Person>();
    private float _recruitmentCooldown = GameManager.DAY;

    public void CreateCandidateList()
    {
        if(_recruitmentCooldown <= 0)
        {
            _candidateList.Clear();
            for(int i = 0; i < 12; i++)
            {
                _candidateList.Add(new Person());
            }
            _recruitmentCooldown = GameManager.DAY;
        }
    }

    public void Hire(string id)
    {
        foreach (Person p in _candidateList)
        {
            if (p.ID == id)
            {
                _employeeList.Add(p);
                _candidateList.Remove(p);
                break;
            }
        }
    }

    public void Fire(string id)
    {
        foreach (Person p in _employeeList)
        {
            if (p.ID == id)
            {
                _candidateList.Add(p);
                _employeeList.Remove(p);
                break;
            }
        }
    }

    public void AssignProject(string id, string projectName)
    {
        foreach (Person p in _employeeList)
        {
            if (p.ID == id)
            {
                p.AssignedProject = projectName;
                break;
            }
        }
    }

    public void UnassignProject(string id, string projectName)
    {
        foreach (Person p in _employeeList)
        {
            if (p.ID == id)
            {
                p.AssignedProject = null;
                break;
            }
        }
    }

    public void UnassignMany(string projectName)
    {
        foreach (Person p in _employeeList)
        {
            if (p.AssignedProject == projectName)
            {
                p.AssignedProject = null;
            }
        }
    }

    public List<Person> GetProjectMembers(string projectName)
    {
        List<Person> members = new List<Person>();

        foreach(Person p in _employeeList)
        {
            if(p.AssignedProject == projectName)
            {
                members.Add(p);
            }
        }

        return members;
    }

    public List<Person> Employees
    {
        get { return _employeeList; }
        private set { }
    }

    public List<Person> Candidates
    {
        get { return _candidateList; }
        private set { }
    }

    public float RecruitmentCooldown
    {
        get { return _recruitmentCooldown; }
        private set { }
    }

    private void Update()
    {
        if (_recruitmentCooldown > 0)
        {
            _recruitmentCooldown -= Time.deltaTime;
        }
    }
}
