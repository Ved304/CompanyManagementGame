using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
    [SerializeField] private GameObject _projectsPanel;
    [SerializeField] private GameObject _HRPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene(sceneName: "GameScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SwitchTo()
    {

    }

    public void SwitchToProjects()
    {
        _HRPanel.SetActive(false);
        _projectsPanel.SetActive(true);
    }

    public void SwitchToHR()
    {
        _HRPanel.SetActive(true);
        _projectsPanel.SetActive(false);
    }
}
