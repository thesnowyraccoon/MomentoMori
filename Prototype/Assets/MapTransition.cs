using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
   [SerializeField] PolygonCollider2D mapBoundry;
   CinemachineConfiner2D confiner;

    private void Awake()
    {
       confiner = FindObjectsByType<CinemachineConfiner2D>();
    }

    private T FindObjectsByType<T>()
    {
        throw new NotImplementedException();
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           // CinemachineConfiner2D. = mapBoundry;
            confiner.BoundingShape2D = mapBoundry;
        }
    }
} 
