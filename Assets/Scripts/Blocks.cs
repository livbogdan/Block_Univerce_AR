using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blocks : MonoBehaviour
{
    

    public Vector3 rotation;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}
