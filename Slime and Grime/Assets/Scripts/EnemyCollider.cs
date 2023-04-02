using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullets"))
        {
            Destroy(gameObject);
        }
    }
}
