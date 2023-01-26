using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private Jewel[,] grid = new Jewel[8,8];
    public RectTransform gridRectT;
    public int countLeftClick = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void Prepare_Grid(Jewel[,] grid)
    {
        this.grid = grid;
    }

    public void Replace(Jewel draggingJewel, Jewel aimJewel)
    {
        

    }


/*
    void Update()
    {
        // Handle input events
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (grid[(int)clickPos.x + 5, (int)clickPos.y] != null)
            {
                selectedObject = grid[(int)clickPos.x, (int)clickPos.y];
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (grid[(int)releasePos.x, (int)releasePos.y] != null && selectedObject != null)
            {
                SwitchObjects(selectedObject, grid[(int)releasePos.x, (int)releasePos.y]);
                selectedObject = null;
            }
        }

    
    }

    void SwitchObjects(GameObject obj1, GameObject obj2)
    {
        Vector2 obj1Pos = obj1.transform.position;
        obj1.transform.position = obj2.transform.position;
        obj2.transform.position = obj1Pos;

        // Check for matches after switching
        CheckMatches();
    }

    void CheckMatches()
    {
        // Check for horizontal and vertical matches and remove matched jewels
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (grid[x, y] != null)
                {
                    int matchCount = CheckHorizontal(x, y) + CheckVertical(x, y);
                    if (matchCount >= 2)
                    {
                        Destroy(grid[x, y]);
                        grid[x, y] = null;
                    }
                }
            }
        }

        // Move remaining jewels down and fill in blank spaces
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (grid[x, y] == null)
                {
                    MoveDown(x, y);
                }
            }
        }
    }

    int CheckHorizontal(int x, int y)
    {
        int matchCount = 0;
                for (int i = x - 1; i <= x + 1; i++)
                {
                    if (i >= 0 && i < 8)
                    {
                        if (grid[i, y] != null && grid[i, y].CompareTag(grid[x, y].tag))
                        {
                            matchCount++;
                        }
                    }
                }
                return matchCount;
    
    }
    int CheckVertical(int x, int y)
    {
        int matchCount = 0;
        for (int i = y - 1; i <= y + 1; i++)
        {
            if (i >= 0 && i < 8)
            {
                if (grid[x, i] != null && grid[x, i].CompareTag(grid[x, y].tag))
                {
                    matchCount++;
                }
            }
        }
        return matchCount;
    }

    void MoveDown(int x, int y)
    {
        for (int i = y; i < 8; i++)
        {
            if (grid[x, i] != null)
            {
                grid[x, i - 1] = grid[x, i];
                grid[x, i] = null;
                grid[x, i - 1].transform.position = new Vector2(x, i - 1);
            }
        }
    }

    void EndGame()
    {
        // Handle end of game logic, such as displaying a game over message and resetting the game
    }


*/
}

