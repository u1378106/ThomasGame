using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;

    AudioManager audioManager;
    LevelHandler levelHandler;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        levelHandler = GameObject.FindObjectOfType<LevelHandler>();
        _distanceJoint.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "win")
        {
            levelHandler.winScreen.SetActive(true);
        }

        if (other.gameObject.tag == "Fire")
        {
            audioManager.gameoverAudio.Play();
            levelHandler.gameoverScreen.SetActive(true);
            Destroy(this);       
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioManager.grappleAudio.Play();
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
       
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }

        //Testing out to change web length at real time
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z));
        }
    }
}
