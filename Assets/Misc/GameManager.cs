using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TestFunctions : MonoBehaviour
{

    private Renderer rend;
    public Color[] colors;
    public float speed;
    public Transform pointA, pointB;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //transform.position = Vector3.forward;

    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(pointA.position, pointB.position, speed = Time.deltaTime);
        //  float dist = Vector3.Distance(transform.position, pointA.position);
    }

    // Update is called once per frame


    void OnEnable()
    {

        //rend.material.color = colors[Random.Range(0, colors.Length)];    

    }

    void OnDisable()
    {
        //rend.material.color = colors[Random.Range(0, colors.Length)];
    }

    void OnMouseDown()
    {
        rend.material.color = colors[Random.Range(0, colors.Length)];
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnMouseEnter()
    {
        // rend.material.color = colors[Random.Range(0, colors.Length)];
    }

    void OnMouseUp()
    {
        //rend.material.color = colors[Random.Range(0, colors.Length)];
    }

    private void OnMouseDrag()
    {
        //rend.material.color = colors[Random.Range(0, colors.Length)];
    }
    private void OnMouseExit()
    {
        //rend.material.color = colors[Random.Range(0, colors.Length)];
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }*/
}
