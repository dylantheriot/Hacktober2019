using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneRotate : MonoBehaviour
{
    public GameObject phone;
    private float timer = 2;
    private float stopTimer = 0;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
      originalPos = new Vector3(phone.transform.position.x, phone.transform.position.y, phone.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimer > 10) {
            stopTimer = 0;
            phone.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        stopTimer += Time.deltaTime;
        phone.transform.Rotate(Vector3.right * timer);
        phone.transform.Rotate(Vector3.up * timer);
        phone.transform.position = originalPos;
    }
}
