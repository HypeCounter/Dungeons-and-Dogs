using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour {

    [SerializeField] GameObject target = null;

    private bool starTeleport = false;

  



    void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = Vector3.Slerp(other.transform.position, target.transform.position, 1f * Time.timeScale);
        }
    }
}
