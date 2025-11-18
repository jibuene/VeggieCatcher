using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbg : MonoBehaviour
{
    Material material;
    Vector2 offset;

    [SerializeField] float xVelocity, yVelocity;
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity / 100, yVelocity / 100);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
