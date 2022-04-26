using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


public class Builder : MonoBehaviour
{
    
    public GameObject[] blocks;

    [SerializeField]    
    private ARRaycastManager raycastManager;

    [SerializeField]
    private LayerMask blockLayer;
    private int selectedBlock;

    [Header("Score")]
    public static int score;
    public TextMeshProUGUI scoreText;

    public void Start()
    {
        score = 0;
    }

    public void Update()
    {
        Score();
    }

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    public void OnBuildButtonPressed()
    {
        List<ARRaycastHit> arHits = new List<ARRaycastHit>();
        RaycastHit hitInfo;
        Ray rayToCast = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        if (Physics.Raycast(rayToCast, out hitInfo, 1000f, blockLayer))
        {
            Vector3 buildablePosition = hitInfo.normal + hitInfo.transform.position;
            Quaternion buildableRotation = hitInfo.transform.rotation;
            Build(buildablePosition, buildableRotation);
            FindObjectOfType<AudioManager>().Play("Build");
        }
        else
        {
            raycastManager.Raycast(rayToCast, arHits, TrackableType.Planes);
            if (arHits.Count > 0)
            {
                Vector3 buildablePosition = new Vector3(Mathf.Round(arHits[0].pose.position.x / 1) * 1, arHits[0].pose.position.y, Mathf.Round(arHits[0].pose.position.z / 1) * 1);
                Quaternion buildableRotation = arHits[0].pose.rotation;
                Build(buildablePosition, buildableRotation);
                FindObjectOfType<AudioManager>().Play("Build");
            }
        }
    }

    public void SelectBlock(int block)
    {
        selectedBlock = block;

        FindObjectOfType<AudioManager>().Play("SelectBlock");
    }
    public void OnDestroyButtonPressed()
    {
        Ray rayToCast = Camera.main.ViewportPointToRay(new Vector2(.5f, .5f));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayToCast, out hitInfo, 200f, blockLayer))
        {
            Destroy(hitInfo.collider.gameObject);
            score++;
            FindObjectOfType<AudioManager>().Play("Destroy");
            
        }
        
    }

    void Build(Vector3 pos, Quaternion rot)
    {
        Instantiate(blocks [selectedBlock], pos, rot);
    }

    public void Score()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
