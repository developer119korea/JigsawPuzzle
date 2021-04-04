using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Piece _selectedPiece = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("Piece"));
            if (hit.transform != null && hit.transform.CompareTag("Piece")) {
                Piece piece = hit.transform.gameObject.GetComponent<Piece>();
                if (!piece.IsPlaced) {
                    this._selectedPiece = piece;
                }
            }
        }

        if (this._selectedPiece != null && Input.GetMouseButtonUp((0))) {
            if (!this._selectedPiece.IsPlaced) {
                this._selectedPiece.GoBack();
            }
            this._selectedPiece = null;
        }

        if (this._selectedPiece != null && !this._selectedPiece.IsPlaced) {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, _selectedPiece.transform.position.z);
        }
    }
}
