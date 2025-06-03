using UnityEngine;


public class PuzzleManager : MonoBehaviour
{
    public int gridSize = 3; 
    public GameObject piecePrefab; 
    private PuzzlePiece[,] pieces; 
    private Vector2 emptySlot; 

    void Start()
    {
        GeneratePuzzle(); 
    }

    
    void GeneratePuzzle()
    {
        pieces = new PuzzlePiece[gridSize, gridSize]; 
        float pieceSize = 1f; 

        for (int y = 0; y < gridSize; y++) 
        {
            for (int x = 0; x < gridSize; x++) 
            {
               
                if (x == gridSize - 1 && y == gridSize - 1)
                {
                    emptySlot = new Vector2(x, y); 
                    continue; 
                }
                
                GameObject obj = Instantiate(piecePrefab, new Vector3(x * pieceSize, -y * pieceSize, 0), Quaternion.identity, transform);

                
                PuzzlePiece piece = obj.GetComponent<PuzzlePiece>();
                piece.Init(x, y, this); 
                pieces[x, y] = piece; 
            }
        }
    }

    
    public bool IsSlotEmpty(int x, int y)
    {
        return (emptySlot.x == x && emptySlot.y == y);
    }

    
    public void MovePiece(int x, int y)
    {
        
        if (Mathf.Abs(emptySlot.x - x) + Mathf.Abs(emptySlot.y - y) == 1)
        {
            
            pieces[(int)emptySlot.x, (int)emptySlot.y] = pieces[x, y];
            pieces[x, y] = null;

            
            pieces[(int)emptySlot.x, (int)emptySlot.y].transform.position = new Vector3(emptySlot.x, -emptySlot.y, 0);
            pieces[(int)emptySlot.x, (int)emptySlot.y].SetCurrentPos((int)emptySlot.x, (int)emptySlot.y);

            
            emptySlot = new Vector2(x, y);
        }
    }
}