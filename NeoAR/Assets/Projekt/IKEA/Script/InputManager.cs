using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
public class InputManager : MonoBehaviour
{
    //[SerializeField]  GameObject arObj;
    [SerializeField] Camera arCam;
    [SerializeField] ARRaycastManager _raycastManager;
    [SerializeField] GameObject crosshair;
    private Pose pose;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Touch touch;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCalculation();

        //anlegen wird über Touch realisiert
        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
        {
            return;
        }

        if (IsPointerOverUI(touch))
        {
            return;
        }

        //###1###
        //anlegen wird über Mousedown gemacht
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
        //    if (_raycastManager.Raycast(ray,_hits))
        //    {
        //        Pose pose = _hits[0].pose;
        //        Instantiate(DataHandler.Instance.selectedObject, pose.position, pose.rotation);
        //    }
        //}

        //###2###
        ////nach dem Touch wirdgetmouseDown event ignoriert
        //Ray ray = arCam.ScreenPointToRay(touch.position);
        //if (_raycastManager.Raycast(ray, _hits))
        //{
        //    Pose pose = _hits[0].pose;
        //    Instantiate(DataHandler.Instance.selectedObject, pose.position, pose.rotation);
        //}

        Instantiate(DataHandler.Instance.GetSelectedObject(), pose.position, pose.rotation);

    }


    bool IsPointerOverUI(Touch touch)
    {
        //wenn Event von dem Touch hoch zählt dann ist ein Touch ausgeführt
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        //###3###
        Ray ray = arCam.ScreenPointToRay(origin);
        if (_raycastManager.Raycast(ray, _hits))
        {
             pose = _hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0); //!!!!
        }
    }


}
