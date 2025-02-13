using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15,35,45) * Time.deltaTime);


    }
}
