using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public Jewel[] jewelPrefabs;
    public int columns = 8;
    public int rows = 8;
    private GridLayoutGroup gridLayout;
    private List<Jewel> jewels = new List<Jewel>();
    private Jewel[,] grid = new Jewel[8, 8];

    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;

        // Instantiate the jewel prefabs and add them to the grid layout
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Jewel selectedJewel = jewelPrefabs[Random.Range(0, jewelPrefabs.Length)];
                while(!CanAdd(row, col, selectedJewel))
                    selectedJewel = jewelPrefabs[Random.Range(0, jewelPrefabs.Length)];

                Jewel jewel = Instantiate(selectedJewel).GetComponent<Jewel>();
                jewel.transform.SetParent(transform);
                jewels.Add(jewel);
                jewel.jewelUI.Prepare(jewel, grid);
                grid[row,col] = jewel;
            }
        }

        GameManager.instance.Prepare_Grid(grid);
    }

    private bool CanAdd(int row, int col, Jewel selectedJewel)
    {
        if(col == 0 && row == 0)
            return true;
            
        //Check if color is same with tops
        if(row >= 2)
            if (grid[row - 1, col].name.Contains(selectedJewel.name))
                if (grid[row - 2, col].name.Contains(selectedJewel.name))
                    return false;

        //Check if color is same with left
        if (col >= 2)
            if (grid[row, col - 1].name.Contains(selectedJewel.name))
                if (grid[row, col - 2].name.Contains(selectedJewel.name))
                    return false;
               
        return true;
    }

}

