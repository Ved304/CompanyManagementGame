using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    private List<Person> _employeeList = new List<Person>();
    private List<Person> _candidateList = new List<Person>();
    private float _recruitmentCooldown = 5f;

    public List<Person> CreateCandidateList()
    {
        if(_recruitmentCooldown <= 0)
        {
            _candidateList.Clear();
            _candidateList.Add(new Person());
            _candidateList.Add(new Person());
            _candidateList.Add(new Person());
        }

        return _candidateList;
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
