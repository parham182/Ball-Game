
using UnityEngine;
using UnityEngine.EventSystems;

public class Input : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 input;
    private Vector2 startPosition;

    public static Input Instance;

    void Awake()
    {
        Instance = this;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = eventData.position;
        input = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        input = eventData.position - startPosition;

        print(input.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        input = Vector2.zero;
    }
}
