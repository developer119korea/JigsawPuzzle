using UnityEngine;
using UnityEngine.Rendering;

public class Piece : MonoBehaviour
{
    private const float PlacedSensitivity = 1.0f;
    private static int SortIndex = 0;

    public bool IsPlaced
    {
        get; private set;
    }

    private Vector3 _placedPosition = Vector3.zero;
    private Vector3 _unplacedPosition = Vector3.zero;
    [SerializeField] private SortingGroup _sortingGroup = null;

    public void GoBack()
    {
        this.transform.position = _unplacedPosition;
    }

    private void Awake()
    {
        IsPlaced = false;
        _sortingGroup.sortingOrder = 100;
        _placedPosition = this.transform.position;
        _unplacedPosition = new Vector3(Random.Range(5, 11f), Random.Range(2.5f, -7));
        this.transform.position = _unplacedPosition;
    }

    private void Update()
    {
        if (!IsPlaced && Vector3.Distance(transform.position, _placedPosition) < PlacedSensitivity) {
            transform.position = _placedPosition;
            IsPlaced = true;
            _sortingGroup.sortingOrder = SortIndex;
            SortIndex++;
        }
    }
}
