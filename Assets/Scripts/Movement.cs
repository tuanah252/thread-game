using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    public float amplitude = 1.0f;
    private float startY;
    void Start()
    {
        startY = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            startY + amplitude * Mathf.Sin(speed * Time.time),
            transform.position.z);
    }


    // Start is called before the first frame update


    // Update is called once per frame

}
