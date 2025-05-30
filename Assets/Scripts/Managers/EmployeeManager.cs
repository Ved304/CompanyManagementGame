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
