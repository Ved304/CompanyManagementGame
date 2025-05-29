using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HireAndFireButton : MonoBehaviour
{
    private GameObject _employeeManager;

    private void Start()
    {
        _employeeManager = GameObject.Find("EmployeeManager");
    }

    public void OnClickHireAndFire()
    {
        GameObject canvas = GameObject.Find("Canvas");
        string personID = transform.parent.gameObject.transform.GetChild(4).GetComponent<TMP_Text>().text;

        if (transform.GetChild(0).GetComponent<TMP_Text>().text == "Hire")
        {
            _employeeManager.GetComponent<EmployeeManager>().Hire(personID);
        }
        else if (transform.GetChild(0).GetComponent<TMP_Text>().text == "Fire")
        {
            _employeeManager.GetComponent<EmployeeManager>().Fire(personID);
        }

        canvas.GetComponent<UIGameScene>().RefreshCandidates();
        canvas.GetComponent<UIGameScene>().RefreshEmployees();
    }
}
