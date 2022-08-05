using UnityEngine;
using UnityEngine.UI;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private GameObject mousePressedLines;
    public Canvas parentCanvas;
    public Image mouseCursor;

    [SerializeField] private Vector2 clampPos;
    
    public void Start()
    {
        Cursor.visible = false;
    }


    public void Update()
    {
        /*RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);*/

        //Set fake mouse Cursor
        
        //Move the Object/Panel
        
        if (Input.GetMouseButton(0))
        {
           // mouseCursor.transform.position = mousePos;

           Vector3 pos;
           pos = Input.mousePosition;
           pos.x = Mathf.Clamp(pos.x, clampPos.x, clampPos.y);
           pos.y = transform.position.y;
           mouseCursor.enabled = true;
           transform.position = pos;
        }
       
        if (Input.GetMouseButtonUp(0))
        {
            mouseCursor.enabled = false;

        }
       
    }
    

  }
