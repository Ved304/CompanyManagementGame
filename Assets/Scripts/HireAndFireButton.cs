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

        canvas.GetComponent<UIGameScene>().RefreshHR();
    }
}
