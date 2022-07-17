using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAim : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
