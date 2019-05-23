using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_amera : MonoBehaviour {

    public Vector3 sur;
    public GameObject player;

    private void Start()
    {
        sur = transform.position - player.transform.position;
    }
    private void Update()
    {
        transform.position = player.transform.position + sur;
    }

    public void restartDown()
    {
        Application.LoadLevel(0);

    }
}
