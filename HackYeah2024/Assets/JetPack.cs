using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [SerializeField] private PlayerMovement pm;
    [SerializeField] private GameObject pack;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            pack.SetActive(true);
            pm.jumpPower = 20;
            Destroy(gameObject);
        }
    }
}
