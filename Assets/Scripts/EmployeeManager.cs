using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    private List<Person> _employeeList = new List<Person>();
    private List<Person> _candidateList = new List<Person>();

    void Start()
    {
        
    }

    public void CreateCandidateList()
    {
        _candidateList.Clear();
        _candidateList.Add(new Person());
        _candidateList.Add(new Person());
        _candidateList.Add(new Person());
    }
}
