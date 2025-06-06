using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcceptJobButton : MonoBehaviour
{
    public void OnClickAcceptJob()
    {
        GameObject projectsManager = GameObject.Find("ProjectsManager");
        GameObject canvas = GameObject.Find("Canvas");
        string projectName = transform.parent.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text;

        projectsManager.GetComponent<ProjectsManager>().AcceptProject(projectName);
        canvas.GetComponent<UIGameScene>().RefreshProjects();
    }
}
