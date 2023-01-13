using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Camera Movement
    public Transform player;
    Vector3 target, mousePos, shakeOffset;

    Vector3 refVel = Vector3.zero;
    float cameraDistance = 3.5f;
    public float smoothTime = 0.3f, zStart;

    void Start()
    {
        target = player.position;
        zStart = transform.position.z;
    }

    void Update()
    {
        mousePos = CaptureMousePos();
        target = UpdateTargetPos();
    }

    void LateUpdate()
    {
        UpdateCameraPosition();
    }

    Vector3 CaptureMousePos()
    {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;
        float max = 0.9f;
        if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        {
            ret = ret.normalized;
        }
        return ret;
    }

    Vector3 UpdateTargetPos()
    {
        Vector3 mouseOffset = mousePos * cameraDistance;
        Vector3 ret = mouseOffset + player.position;
        ret += shakeOffset;
        ret.z = zStart;
        return ret;
    }

    void UpdateCameraPosition()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime);
        transform.position = tempPos;
    }

}