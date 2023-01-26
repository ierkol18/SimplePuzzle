using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class JewelUI : MonoBehaviour, IPointerDownHandler
{
    private Jewel[,] grid = new Jewel[8, 8];
    public RectTransform rectT { get; set; }
    public Jewel jewel { get; private set; }

    public JewelUI Prepare(Jewel jewel, Jewel[,] grid)
    {
        rectT = transform as RectTransform;
        this.grid = grid;
        this.jewel = jewel;
        this.jewel.jewelUI = this;

        name = jewel.ToString();

        jewel.onSlotChanged += onSlotChanged;

        return this;
    }
    public void onSlotChanged()
    {
      
        if (draggingJewel)
            Destroy(draggingJewel.gameObject);
        
        /*
        if (!slot.isEmpty)
          CreateItemImage();
        */
    }

    private Jewel draggingJewel;
    private Jewel selectedJewel;
    private Jewel aimJewel;
    float clickTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        //TODO: Buraya don amaci ne anlamadim
        //if (draggingJewel != null || selectedJewel != null)  return;

        clickTime = Time.time;

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Select left clicked jewel as selectedJewel
            if(GameManager.instance.countLeftClick == 0)
                selectedJewel = this.jewel;
            
            //Select left clicked jewel as aimJewel
            else
                aimJewel = this.jewel;

        }
        else
            DragStart();
    }

    static Coroutine dragCR;
    static JewelUI draggingJewelUI, hoveringJewelUI;
    static EventSystem m_EventSystem;
    static GraphicRaycaster raycaster;
    
    void DragStart()
    {
        draggingJewel = this.jewel;
        draggingJewelUI = this;

        if (dragCR != null)
            StopCoroutine(dragCR);

        dragCR = StartCoroutine(DragCR());
    }

    IEnumerator DragCR()
    {

        RectTransform draggingJewelRect = draggingJewel.rectT;
        draggingJewelRect.SetParent(GameManager.instance.gridRectT, true);
        
        yield return new WaitForEndOfFrame();


        if (!m_EventSystem)
            m_EventSystem = FindObjectOfType<EventSystem>();

        if (!raycaster)
            raycaster = FindObjectOfType<GraphicRaycaster>();


        Vector3 gap = draggingJewelRect.position - Input.mousePosition;

        JewelUI cachedJewelUI = null;
        Debug.Log(draggingJewelUI);

        while (draggingJewelUI != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                DragEnd();
                yield break;
            }

            draggingJewelRect.position = Input.mousePosition + gap;

            PointerEventData data = new PointerEventData(m_EventSystem);
            Debug.Log(data);
            data.position = draggingJewelRect.position + new Vector3(draggingJewelRect.sizeDelta.x / 4, -draggingJewelRect.sizeDelta.y / 4, 0);
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(data, results);
            Debug.Log(results);


            for (int i = 0; i < results.Count; i++)
            {
                MonoBehaviour monoBehaviour = results[i].gameObject.GetComponent<MonoBehaviour>();
                Debug.Log(monoBehaviour);
                if (monoBehaviour is JewelUI hoveringJewelUI_ && cachedJewelUI != hoveringJewelUI_)
                {
                    cachedJewelUI = hoveringJewelUI = hoveringJewelUI_;

                    Debug.Log("JewelUI");
                    draggingJewelRect.SetParent(GameManager.instance.gridRectT, true);
                    draggingJewelRect.SetAsLastSibling();
                    draggingJewelRect.sizeDelta = hoveringJewelUI.rectT.sizeDelta;

                    break;
                }

            }

            yield return null;
        }

        dragCR = null;
    }


    void DragEnd()
    {
        Debug.Log("DragEnd");
        draggingJewelUI = null;

        if (dragCR != null)
            StopCoroutine(dragCR);

        dragCR = null;

        if (hoveringJewelUI != null)
        {
            draggingJewel.rectT.SetParent(GameManager.instance.gridRectT, true);
            Debug.Log("Replace oluyor");
            GameManager.instance.Replace(draggingJewel, aimJewel);
        }

        hoveringJewelUI = null;
    }

}
