using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject[] jewelPrefabs;
    public int columns = 8;
    public int rows = 8;
    private GridLayoutGroup gridLayout;
    private List<GameObject> jewels = new List<GameObject>();
    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[8,8];
        gridLayout = GetComponent<GridLayoutGroup>();
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;

        // Instantiate the jewel prefabs and add them to the grid layout
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject selectedJewel = jewelPrefabs[Random.Range(0, jewelPrefabs.Length)];
                GameObject jewel = Instantiate(selectedJewel);
                jewel.transform.SetParent(transform);
                jewels.Add(jewel);
                grid[x,y] = jewel;
            }
        }

        // Check for 3 adjacent jewels in each row and column
        CheckAdjacentJewels();

        GameManager.instance.Prepare_Grid(grid);
    }


    //Helper methods
    private void CheckAdjacentJewels()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                // Check for 3 adjacent jewels in current row
                if (x < columns - 2 && GetJewel(x, y).name == GetJewel(x + 1, y).name && GetJewel(x, y).name == GetJewel(x + 2, y).name)
                {
                    // Check for 3 adjacent jewels in current column
                    if (y < rows - 2 && GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y + 2).name)
                        ReplaceJewel(x, y);
                    else if (y > 0 && y < rows - 1 && GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y - 1).name)
                        ReplaceJewel(x, y);
                    else if (y > 1 && GetJewel(x, y).name == GetJewel(x, y - 1).name && GetJewel(x, y).name == GetJewel(x, y - 2).name)
                        ReplaceJewel(x, y);
                }
                if  (x > 0 && x < columns - 1 && GetJewel(x, y).name == GetJewel(x + 1, y).name && GetJewel(x, y).name == GetJewel(x - 1, y).name)
                {
                    // Check for 3 adjacent jewels in current column
                    if (y < rows - 2 && GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y + 2).name)
                        ReplaceJewel(x, y);
                    else if (y > 0 && y < rows - 1 && GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y - 1).name)
                        ReplaceJewel(x, y);
                    else if (y > 1 && GetJewel(x, y).name == GetJewel(x, y - 1).name && GetJewel(x, y).name == GetJewel(x, y - 2).name)
                        ReplaceJewel(x, y);
                }
                if (x > 1 && GetJewel(x, y).name == GetJewel(x - 1, y).name && GetJewel(x, y).name == GetJewel(x - 2, y).name)
                {
                    // Check for 3 adjacent jewels in current column
                    if (y < rows - 2 && GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y + 2).name)
                        ReplaceJewel(x, y);
                    else if (y > 0 && y < rows - 1 && GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y - 1).name)
                        ReplaceJewel(x, y);
                    else if (y > 1 && GetJewel(x, y).name == GetJewel(x, y - 1).name && GetJewel(x, y).name == GetJewel(x, y - 2).name)
                        ReplaceJewel(x, y);
                }
            }
        }
    }


    private void ReplaceJewel(int x, int y)
    {
        GameObject currentJewel = jewels[x + y * columns];
        GameObject newJewel = currentJewel;

        while (newJewel == currentJewel)
            newJewel = jewelPrefabs[Random.Range(0, jewelPrefabs.Length)];
        
        jewels[x + y * columns] = newJewel;
    }

    //Getters & Setters
    public GameObject GetJewel(int x, int y)
    {
        return jewels[x + y * columns];
    }
}

