using UnityEngine;
using UnityEngine.EventSystems;

public class Jewel : MonoBehaviour
{
    public JewelUI jewelUI;
    public GameObject[] grid { get; private set; }
    public event System.Action onSlotChanged;
    public RectTransform rectT => transform as RectTransform;
    
}
