using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit =  Physics2D.Raycast(transform.position,transform.up);

        Debug.DrawRay(transform.position,Vector2.up, Color.red);

        if (hit)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
