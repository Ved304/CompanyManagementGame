using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    private void Awake()
    {
        DragSystem[] controllers = FindObjectsOfType<DragSystem> ();

        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(_isDragActive && (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);
        
        if(_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);

            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                
                if(draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        _isDragActive = true;
    }

    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop()
    {
        _isDragActive = false;
    }

    bool IsDragged()
    {
        Vector2 endPosition;

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            endPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            endPosition = Input.GetTouch(0).position;
        }
        else
        {
            Debug.Log("Swipe Wrong");
            return false;
        }

        Vector2 swipeDelta = endPosition - _screenPosition;

        Debug.Log(endPosition.x);
        Debug.Log(endPosition.y);

        if(Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            Debug.Log("Swipe Horizontal");
            return true;
        }
        else
        {
            Debug.Log("Swipe Vertical");
            return false;
        }
    }
}
