using UnityEngine;

public class Folower : MonoBehaviour
{
    Vector3 mousePosition = new Vector3();
    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        transform.position = mousePosition;
    }
}
