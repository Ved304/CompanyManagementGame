using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HireAndFireButton : MonoBehaviour
{
    public void OnClickHireAndFire()
    {
        GameObject employeeManager = GameObject.Find("EmployeeManager");
        GameObject canvas = GameObject.Find("Canvas");
        string personID = transform.parent.gameObject.transform.GetChild(4).GetComponent<TMP_Text>().text;

        if (transform.GetChild(0).GetComponent<TMP_Text>().text == "Hire")
        {
            employeeManager.GetComponent<EmployeeManager>().Hire(personID);
        }
        else if (transform.GetChild(0).GetComponent<TMP_Text>().text == "Fire")
        {
            employeeManager.GetComponent<EmployeeManager>().Fire(personID);
        }
        else if(transform.GetChild(0).GetComponent<TMP_Text>().text == "Assign")
        {
            string projectName = GameObject.Find("Project Name Text (TMP)").GetComponent<TMP_Text>().text;
            employeeManager.GetComponent<EmployeeManager>().AssignProject(personID, projectName);
            canvas.GetComponent<UIGameScene>().RefreshDetails(projectName);
        }
        else if (transform.GetChild(0).GetComponent<TMP_Text>().text == "Remove")
        {
            string projectName = GameObject.Find("Project Name Text (TMP)").GetComponent<TMP_Text>().text;
            employeeManager.GetComponent<EmployeeManager>().UnassignProject(personID, projectName);
            canvas.GetComponent<UIGameScene>().RefreshDetails(projectName);
        }

        canvas.GetComponent<UIGameScene>().RefreshHR();
    }
}
