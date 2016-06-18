using UnityEngine;
using System.Collections;

public class InterpolateRotation : MonoBehaviour {

    private Vector3 startRotation;
    public Vector3 endRotation;

    public float duration;
    private float startTime;
    private bool firstMove = true;
    int randomNumb1, randomNumb2, randomNumb3;
    int randomNumb4, randomNumb5, randomNumb6;

    Color startColor, endColor;



    // Use this for initialization
    void Start () {
        startRotation = transform.rotation.eulerAngles;
        startTime = Time.time;
        randomNumb1 = Random.Range(1, 256); // creates a number between 1 and 255
        randomNumb2 = Random.Range(1, 256); // creates a number between 1 and 255
        randomNumb3 = Random.Range(1, 256); // creates a number between 1 and 255
        randomNumb4 = Random.Range(1, 256); // creates a number between 1 and 255
        randomNumb5 = Random.Range(1, 256); // creates a number between 1 and 255
        randomNumb6 = Random.Range(1, 256); // creates a number between 1 and 255

        startColor = new Color(randomNumb1 / 255f, randomNumb1 / 255f, randomNumb1 / 255f, 1);
        endColor = new Color(randomNumb4 / 255f, randomNumb5 / 255f, randomNumb6 / 255f, 1);
        GetComponent<Light>().color = startColor;

        Debug.Log(startColor);
    }
	
	// Update is called once per frame
	void Update () {
        if (duration != 0)
        {

            if (firstMove)
            {
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), (Time.time - startTime) / (duration / 2));

                GetComponent<Light>().color = Vector4.Lerp(startColor, endColor, duration);

                if (Time.time - startTime > (duration / 2))
                {
                    firstMove = false;
                    startTime = Time.time;
                    startColor = endColor;
                    randomNumb4 = Random.Range(1, 256); // creates a number between 1 and 255
                    randomNumb5 = Random.Range(1, 256); // creates a number between 1 and 255
                    randomNumb6 = Random.Range(1, 256); // creates a number between 1 and 255
                    endColor = new Color(randomNumb4 / 255f, randomNumb5 / 255f, randomNumb6 / 255f, 1);
                }
            }//End if animating first
            else {

                transform.rotation = Quaternion.Lerp(Quaternion.Euler(endRotation), Quaternion.Euler(startRotation), (Time.time - startTime) / (duration / 2));

                GetComponent<Light>().color = Vector4.Lerp(startColor, endColor, duration);
                if (Time.time - startTime > (duration / 2))
                {
                    firstMove = true;
                    startTime = Time.time;
                    startColor = endColor;
                    randomNumb4 = Random.Range(1, 256); // creates a number between 1 and 255
                    randomNumb5 = Random.Range(1, 256); // creates a number between 1 and 255
                    randomNumb6 = Random.Range(1, 256); // creates a number between 1 and 255
                    endColor = new Color(randomNumb4 / 255f, randomNumb5 / 255f, randomNumb6 / 255f, 1);
                }

            }

        }//End if duration != 0


    }
}
