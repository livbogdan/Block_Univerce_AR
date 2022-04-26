using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Touch touch;
    public float speedMod;



    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3
                    (
                    transform.position.x,
                    transform.position.y + touch.deltaPosition.y * speedMod,
                    transform.position.z
                    );                                
            }
        }
    }
}
