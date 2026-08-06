using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Header("Player viewpoints")]
    [SerializeField]
    private PlayerViewPoint[] viewPoints;

    [Header("Transition")]
    [SerializeField]
    [Min(0f)]
    private float transitionDuration = 0.7f;

    private readonly Dictionary<int, Transform> pointsByPlayer =
        new Dictionary<int, Transform>();

    private Coroutine transitionRoutine;

    private void Awake()
    {
        BuildViewPointDictionary();
    }

    private void BuildViewPointDictionary()
    {
        pointsByPlayer.Clear();

        foreach (PlayerViewPoint viewPoint in viewPoints)
        {
            if (viewPoint == null)
            {
                continue;
            }

            if (pointsByPlayer.ContainsKey(viewPoint.PlayerId))
            {
                Debug.LogError(
                    $"Для игрока {viewPoint.PlayerId} назначено несколько точек обзора.");

                continue;
            }

            pointsByPlayer.Add(
                viewPoint.PlayerId,
                viewPoint.transform);
        }
    }

    public void ShowPlayer(int playerId, bool instantly = false)
    {
        if (!pointsByPlayer.TryGetValue(
                playerId,
                out Transform target))
        {
            Debug.LogError(
                $"Не найдена точка обзора для игрока {playerId}.");

            return;
        }

        if (transitionRoutine != null)
        {
            StopCoroutine(transitionRoutine);
            transitionRoutine = null;
        }

        if (instantly || transitionDuration <= 0f)
        {
            transform.SetPositionAndRotation(
                target.position,
                target.rotation);

            return;
        }

        transitionRoutine = StartCoroutine(
            MoveToViewPoint(target));
    }

    private IEnumerator MoveToViewPoint(Transform target)
    {
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;

        Vector3 targetPosition = target.position;
        Quaternion targetRotation = target.rotation;

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;

            float progress = Mathf.Clamp01(
                elapsedTime / transitionDuration);

            // Делает начало и конец движения более плавными.
            float smoothProgress =
                progress * progress * (3f - 2f * progress);

            transform.position = Vector3.Lerp(
                startPosition,
                targetPosition,
                smoothProgress);

            transform.rotation = Quaternion.Slerp(
                startRotation,
                targetRotation,
                smoothProgress);

            yield return null;
        }

        transform.SetPositionAndRotation(
            targetPosition,
            targetRotation);

        transitionRoutine = null;
    }
}
