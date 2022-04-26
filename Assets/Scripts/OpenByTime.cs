using System.Collections;
using UnityEngine;

public class OpenByTime : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public bool secondObject;
    private bool change;
    public float timeBetweenDisappears;
    private float timeBetweenDisappearsStore;
    public float disappearTime;
    private float disappearTimeStore;
    public float delayTime = 0.0f;
    // Use this for initialization
    void Start()
    {
        change = true;
        timeBetweenDisappearsStore = timeBetweenDisappears;
        disappearTimeStore = disappearTime;
        if (secondObject)
        {
            disappearTime += delayTime;
        }
        else
        {
            timeBetweenDisappears += delayTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (secondObject)
        {
            if (timeBetweenDisappears <= 0.0f)
            {
                change = true;
                timeBetweenDisappears = timeBetweenDisappearsStore;
            }
            timeBetweenDisappears -= Time.deltaTime;
            if (change)
            {
                object1.SetActive(false);
                object2.SetActive(true);
                secondObject = false;
                change = false;
            }
        }
        else
        {
            if (disappearTime <= 0.0f)
            {
                change = true;
                disappearTime = disappearTimeStore;
            }
            disappearTime -= Time.deltaTime;
            if (change)
            {
                object1.SetActive(true);
                object2.SetActive(false);
                secondObject = true;
                change = false;
            }
        }
    }
}
