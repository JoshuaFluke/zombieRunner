using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    //is basically a public field
    [SerializeField] private float objectSpeed = 5;
    [SerializeField] private float resetPosition = -46.75f;
    [SerializeField] private float startPosition = 96;
    // Use this for initialization
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (GameManager.instance.GameOver != true)
        {
            transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.x <= resetPosition)
            {
                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }

    }
}
