using UnityEngine;

public class Pocket : MonoBehaviour
{
    [SerializeField]private bool _isEmpty = true;
    [SerializeField] private bool _isRightPocket = false;
    [SerializeField] private bool _isFieldPocket;

    public bool IsEmpty
    {
        get 
        {
            return _isEmpty;
        }
        set
        {
            _isEmpty = value;
        }
    }

    public bool IsRightPocket
    {
        get
        {
            return _isRightPocket;
        }
    }

    public bool IsFieldPocket
    {
        get
        {
            return _isFieldPocket;
        }
    }
}
