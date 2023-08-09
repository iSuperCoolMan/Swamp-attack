using UnityEngine;

public class MousePositionGetter
{
    public Vector3 GetMousePositionOnPlane(Plane plane)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float hitdist))
        {
            return ray.GetPoint(hitdist);
        }

        return Vector3.zero;
    }

    public Vector3 GetVector3From(Transform transform, Vector3 axis)
    {
        Vector3 mousePosition = GetMousePositionOnPlane(new Plane(axis, transform.position));
        return mousePosition - transform.position;
    }

    public Quaternion Get3DRotationFrom(Transform transform, Vector3 axis)
    {
        Vector3 vector3From = GetVector3From(transform, axis);
        return Quaternion.LookRotation(vector3From);
    }

    public Quaternion Get2DRotationFrom(Transform transform)
    {
        Vector3 vector3From = GetVector3From(transform, Vector3.forward);
        float angle = -Mathf.Atan2(vector3From.x, vector3From.y) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
