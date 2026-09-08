using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 跟随的目标（你的角色）
    public Transform target;
    // 平滑速度（数值越小越丝滑）
    public float smoothSpeed = 0.15f;
    // 相机偏移（2D游戏固定Z=-10，否则看不到角色）
    public Vector3 offset = new Vector3(0, 0, -10);

    // 固定在角色移动后更新相机，杜绝抖动
    void LateUpdate()
    {
        // 计算相机要去的位置
        Vector3 desiredPosition = target.position + offset;
        // 平滑移动相机
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // 更新相机位置
        transform.position = smoothedPosition;
    }
}