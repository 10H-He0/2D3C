using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.IO;

public class change : MonoBehaviour
{
    public CinemachineConfiner cam;
    public Collider2D ins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "New tag")
        {
            cam.m_BoundingShape2D = ins;
        }
    }
}