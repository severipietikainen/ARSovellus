using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField] GameObject spawnablePrefab;
    [SerializeField] GameObject spawnablePrefab1;
    [SerializeField] GameObject spawnablePrefab2;
    Camera arCam;
    GameObject spawnedObject;
 
    int spawnObject = 0;
    
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        if(spawnObject == 0)
                        {
                        SpawnPrefab(m_Hits[0].pose.position);
                       
                        }
                        if(spawnObject == 1)
                        {
                        SpawnPrefab1(m_Hits[0].pose.position);
                        
                        }
                         if(spawnObject == 2)
                        {
                        SpawnPrefab2(m_Hits[0].pose.position);
                       
                        }
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
                spawnObject += 1;
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    { 

        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
                
    }

      private void SpawnPrefab1(Vector3 spawnPosition)
    { 

        spawnedObject = Instantiate(spawnablePrefab1, spawnPosition, Quaternion.identity);
                     
    }

         private void SpawnPrefab2(Vector3 spawnPosition)
    { 

        spawnedObject = Instantiate(spawnablePrefab2, spawnPosition, Quaternion.identity);
                   
    }

    
}
