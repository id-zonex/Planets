using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private ParalaxItem[] paralaxItems;

    private void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        foreach (ParalaxItem item in paralaxItems)
            MoveItem(item);
    }

    private void Move()
    {
        foreach (ParalaxItem item in paralaxItems)
            SetNextPosition(item);
    }

    private void SetNextPosition(ParalaxItem item)
    {
        float xDirection = Input.GetAxisRaw("Mouse X");
        float yDirection = Input.GetAxisRaw("Mouse Y");

        item.NextPosition = item.Image.position + new Vector3(xDirection, 0, yDirection);
    }

    private void MoveItem(ParalaxItem item)
    {
        Vector3 _ = Vector3.zero;

        item.Image.position = Vector3.SmoothDamp(item.Image.position, item.NextPosition, ref _, Time.deltaTime * item.Smoothnes);
    }
}
