using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehavior : MonoBehaviour
{
    private SpriteRenderer myImage;
    [SerializeField, Range(0f, 1f)] float lerpTime;
    [SerializeField] Color myColor;
    private int colorIndex = 0;

    float t = 0f ;


    public Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, 1.1f,0f) * Time.deltaTime;
        if (transform.position.y <= -initPos.y)
        {
            transform.position = initPos;
            
        }
        /*
        myImage.color = Color.Lerp(myImage.color, myColor, lerpTime);
        Debug.Log("" +myColor.Length) ;
        Debug.Log("" + colorIndex);
        t = Mathf.Lerp(t, 1f, lerpTime);

        /*
        if(t > 0.9f)
        {
            t = 0;
            colorIndex++;
            colorIndex = (colorIndex >= myColor.Length) ? 0 : colorIndex;
        }
        /**/
    }
}
