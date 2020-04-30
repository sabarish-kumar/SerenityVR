using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Climber climber = null;
    public OVRInput.Controller controller = OVRInput.Controller.None;
    //public Material[] mat;
    public Vector3 Delta { private set; get; } = Vector3.zero;

    private Vector3 lastPosition = Vector3.zero;

    private GameObject currentPoint = null;
    private List<GameObject> contactPoints = new List<GameObject>();
    private MeshRenderer meshRenderer = null;
    //private MeshRenderer matRenderer;

    private void Awake()
    {
       meshRenderer = GetComponentInChildren<MeshRenderer>();
       //matRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        lastPosition = transform.position;
        
    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            GrabPoint();
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
            ReleasePoint();
    }

    private void FixedUpdate()
    {
        lastPosition = transform.position; 
    }

    private void LateUpdate()
    {
        Delta = lastPosition - transform.position;
    }
    private void GrabPoint()
    {
        currentPoint = Utility.GetNearest(transform.position, contactPoints);
        

        if (currentPoint)
        {
            climber.SetHand(this);
            meshRenderer.enabled = false;
            //matRenderer.sharedMaterial = 
        }
    }

    public void ReleasePoint()
    {
        if(currentPoint)
        {
            climber.ClearHand();
            meshRenderer.enabled = true;
        }

        currentPoint = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        AddPoint(other.gameObject);
    }

    private void AddPoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimbPoint"))
            contactPoints.Add(newObject);
    }

    private void OnTriggerExit(Collider other)
    {
        RemovePoint(other.gameObject);
    }

    private void RemovePoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimbPoint"))
            contactPoints.Remove(newObject);
    }
}
