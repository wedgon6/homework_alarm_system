using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CercleInstate : MonoBehaviour
{
    public GameObject TempLate;
    public int Count;
    public float Radius;


    private void Start()
    {
        int angelStep = 360 / Count;
        
        for(int i = 0; i < Count; i++)
        {
            GameObject newGameOndject = Instantiate(TempLate, new Vector3(0, 0, 0), Quaternion.identity);
            Transform newObjectTransform = newGameOndject.GetComponent<Transform>();

            newObjectTransform.position = new Vector3(Mathf.Cos(angelStep*(i+1)*Mathf.Deg2Rad), 
                Mathf.Sin(angelStep*(i+1)*Mathf.Deg2Rad),0);
        }
    }
}
