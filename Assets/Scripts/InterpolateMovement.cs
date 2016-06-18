using UnityEngine;
using System.Collections;

public class InterpolateMovement : MonoBehaviour {

    private Vector3 startPosition;
    public Vector3 endPosition;

    public float duration;
    private float startTime;
    private bool firstMove = true;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if (duration != 0)
        {

            if (firstMove)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, (Time.time - startTime) / (duration / 2));

                if (Time.time - startTime > (duration / 2))
                {
                    firstMove = false;
                    startTime = Time.time;
                }
            }//End if animating first
            else {

                transform.position = Vector3.Lerp(endPosition, startPosition, (Time.time - startTime) / (duration / 2));

                if (Time.time - startTime > (duration / 2))
                {
                    firstMove = true;
                    startTime = Time.time;
                }

            }
        }//End if duration != 0
    }
}
