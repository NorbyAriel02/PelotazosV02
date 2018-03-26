using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject target;
    public float damping = 1;
    public float moveThreshold = 0.3f;

    private float m_Offset;
    private Transform tPlayer;
    private Rigidbody2D rbPlayer;
    private Rigidbody2D rbCam;

    private void Start()
    {
        tPlayer = target.transform;
        m_Offset = (tPlayer.position - transform.position).z;
        Debug.Log(m_Offset);
        rbPlayer = target.GetComponent<Rigidbody2D>();
        rbCam = GetComponent<Rigidbody2D>();
        transform.parent = null;
    }


    // Update is called once per frame
    private void Update()
    {
        // only update lookahead pos if accelerating or changed direction
        Vector3 MoveDelta = (new Vector3(tPlayer.position.x, tPlayer.position.y, -10) - transform.position);
        bool updateLookAheadTarget = (Mathf.Abs(MoveDelta.magnitude) > moveThreshold);
        
        if (updateLookAheadTarget && rbPlayer.velocity.magnitude > 1)
        {
            rbCam.velocity = rbPlayer.velocity;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(tPlayer.position.x, tPlayer.position.y, -m_Offset), Time.deltaTime);
        }
    }
}
