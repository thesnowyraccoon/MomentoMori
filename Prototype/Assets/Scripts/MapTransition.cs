using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    public PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;

    void Start()
    {
        confiner = GameObject.FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
        }
    }
} 
