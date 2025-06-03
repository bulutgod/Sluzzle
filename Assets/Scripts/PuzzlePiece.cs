using UnityEngine;


public class PuzzlePiece : MonoBehaviour
{
    private int correctX, correctY; 
    private int currX, currY;       
    private PuzzleManager manager;  

    
    public void Init(int x, int y, PuzzleManager m)
    {
        correctX = x;
        correctY = y;
        currX = x;
        currY = y;
        manager = m;
    }

    
    public void SetCurrentPos(int x, int y)
    {
        currX = x;
        currY = y;
    }

    
    void OnMouseDown()
    {
        
        if (manager.IsSlotEmpty(currX, currY + 1) ||
            manager.IsSlotEmpty(currX, currY - 1) ||
            manager.IsSlotEmpty(currX + 1, currY) ||
            manager.IsSlotEmpty(currX - 1, currY))
        {
            manager.MovePiece(currX, currY);
        }
    }
}