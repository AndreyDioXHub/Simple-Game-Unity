using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Camera _mainCamera;
    [SerializeField]
    private NavMeshAgent _myLegs;
    [SerializeField]
    private GameObject _projectTile;
    private Vector3 _mousePosition;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    Vector3 NewDestination()
    {
        Vector3 currentPoint = new Vector3(0,0,0);

        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            currentPoint = hit.point;
        }

        return currentPoint;
    }

    void Fire()
    {
        Instantiate(_projectTile, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = NewDestination();
        _myLegs.SetDestination(_mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }


}
