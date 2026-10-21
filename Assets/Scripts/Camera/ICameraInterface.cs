
using UnityEngine;

public interface ICameraInterface
{
    Transform GetTarget();
    public void SetTarget(Transform Target);
    public void SetZoom(float zoom);



}
