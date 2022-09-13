using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    public float distanceWithTarget(GameObject target)
    {
        return Vector2.Distance(transform.position, target.transform.position);
    }

    public bool isInRange(GameObject target, float _maxRange)
    {
        return distanceWithTarget(target) < _maxRange;
    }
}