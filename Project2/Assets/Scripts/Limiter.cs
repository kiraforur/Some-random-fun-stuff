using UnityEngine;

public class Limiter : MonoBehaviour
{
    void Awake()
    {
        // Отключаем V-Sync в коде, чтобы он не мешал лимиту
        QualitySettings.vSyncCount = 0;

        // Жестко ограничиваем FPS (например, до 60 кадра)
        Application.targetFrameRate = 60;
    }
}
