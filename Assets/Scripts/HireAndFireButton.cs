using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HireAndFireButton : MonoBehaviour
{
    public void OnClickHireAndFire()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        canvas.GetComponent<UIGameScene>().HireOrFire(clickedButton);
    }
}
