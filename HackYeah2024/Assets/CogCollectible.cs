using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameManager.instance.cog++;
        Destroy(gameObject);
    }
}
