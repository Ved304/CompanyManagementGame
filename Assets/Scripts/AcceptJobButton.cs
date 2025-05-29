using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcceptJobButton : MonoBehaviour
{
    private GameObject _projectsManager;

    private void Start()
    {
        _projectsManager = GameObject.Find("ProjectsManager");
    }

    public void OnClickAcceptJob()
    {
        GameObject canvas = GameObject.Find("Canvas");
        string projectName = transform.parent.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text;

        _projectsManager.GetComponent<ProjectsManager>().AcceptProject(projectName);
        canvas.GetComponent<UIGameScene>().RefreshJobs();
    }
}
