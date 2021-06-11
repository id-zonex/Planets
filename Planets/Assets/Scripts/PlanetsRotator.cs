using UnityEngine;

public class PlanetsRotator : MonoBehaviour
{

    private void LateUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            RotatePlanet();
        }
    }

    private void RotatePlanet()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);
    }
}
