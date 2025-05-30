using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Global constants
    public const float DAY = 10f;
    public const float MONTH = 30 * DAY;

    //Variables
    private int _budget;

    //Managers
    private GameObject _employeeManager;
    private GameObject _projectManager;

    public int Budget
    {
        get { return _budget; }
        private set { }
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }

    private void DeductMoney()
    {
        Debug.Log("Deducting");
        List<Person> employees = new List<Person>();
        employees = _employeeManager.GetComponent<EmployeeManager>().Employees;
        foreach (Person p in employees)
        {
            _budget -= p.Salary;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _employeeManager = GameObject.Find("EmployeeManager");
        _projectManager = GameObject.Find("ProjectManager");

        _budget = 10000;

        InvokeRepeating("DeductMoney", MONTH, MONTH);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
