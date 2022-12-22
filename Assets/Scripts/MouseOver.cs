using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        GetComponent<Renderer>().material.color = Color.black;
    }

    void OnMouseEnter(){
        GetComponent<Renderer>().material.color = Color.red; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
