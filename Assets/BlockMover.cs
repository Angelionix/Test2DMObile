using UnityEngine;

public class BlockMover : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 position;
    private Vector3 lastPosition;
    public Transform startPosition;

    public delegate void OnWin();
    public static OnWin onWin;

    public delegate void OnLose();
    public static OnLose onLose;

    public void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        position = mousePosition;
        position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        transform.position = position;
    }
    private void OnMouseDown()
    {
        RaycastHit[] hits = Physics.RaycastAll(mousePosition, Vector3.forward);
        foreach (RaycastHit hit in hits)
        {
            Pocket pocket;
            bool t = hit.collider.TryGetComponent<Pocket>(out pocket);
            if (t)
            {
                pocket.IsEmpty = true;
                lastPosition = new Vector3(pocket.transform.position.x, pocket.transform.position.y,transform.position.z);
            }
        }
    }
    private void OnMouseUp()
    {
        RaycastHit[] hits = Physics.RaycastAll(mousePosition, Vector3.forward);
        if (hits.Length == 1)
        {
            transform.position = lastPosition;
        }
        foreach (RaycastHit hit in hits)
        {
            Pocket pocket;
            bool t = hit.collider.TryGetComponent<Pocket>(out pocket);
            if (t && pocket.IsEmpty)
            {
                pocket.IsEmpty = false;
                position = new Vector3(pocket.transform.position.x, pocket.transform.position.y, transform.position.z);
                transform.position = position;
                if (pocket.IsRightPocket && pocket.IsFieldPocket)
                {
                    onWin();
                }
                else if (!pocket.IsRightPocket && pocket.IsFieldPocket)
                {
                    onLose();
                }
            }
        }
    }

    public void PositionInit()
    {
        transform.position = new Vector3(startPosition.position.x, startPosition.position.y, transform.position.z);
    }

}
