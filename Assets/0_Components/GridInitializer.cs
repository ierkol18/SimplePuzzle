using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridInitializer : MonoBehaviour
{
    public GameObject[] jewelPrefabs;
    public int columns = 8;
    public int rows = 8;
    private GridLayoutGroup gridLayout;
    private List<GameObject> jewels = new List<GameObject>();

    void Start()
    {
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
            }
        }

        // Check for 3 adjacent jewels in each row and column
        CheckAdjacentJewels();
    }

    
    //Helper methods

    private void CheckAdjacentJewels()
    {
        // Check for 3 adjacent jewels in each row
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns - 2; x++)
            {
                if(GetJewel(x, y).name == GetJewel(x + 1, y).name && GetJewel(x, y).name == GetJewel(x + 2, y).name)
                    ReplaceJewel(x, y);
                if(x > 0 && GetJewel(x, y).name == GetJewel(x + 1, y).name && GetJewel(x, y).name == GetJewel(x - 1, y).name)
                    ReplaceJewel(x, y);
                if (x > 1 && GetJewel(x, y).name == GetJewel(x - 1, y).name && GetJewel(x, y).name == GetJewel(x - 2, y).name)
                    ReplaceJewel(x, y);
            }
        }

        // Check for 3 adjacent jewels in each columns
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows - 2; y++)
            {
                if (GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y + 2).name)
                    ReplaceJewel(x, y);
                if (y > 0 && GetJewel(x, y).name == GetJewel(x, y + 1).name && GetJewel(x, y).name == GetJewel(x, y - 1).name)
                    ReplaceJewel(x, y);
                if (y > 1 && GetJewel(x, y).name == GetJewel(x, y - 1).name && GetJewel(x, y).name == GetJewel(x, y - 2).name)
                    ReplaceJewel(x, y);
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

