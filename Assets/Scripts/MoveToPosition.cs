using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    private Queue<Vector3> _targetPositions = new Queue<Vector3>();
    private Coroutine _moveCoroutine;

    private float _speed = 1;

    private void OnEnable() => EventManager.OnScreenClick += OnScreenClick;

    private void OnDisable() => EventManager.OnScreenClick -= OnScreenClick;

    private void OnScreenClick(Vector3 targetPosition)
    {
        _targetPositions.Enqueue(targetPosition);

        if (_moveCoroutine == null)
            _moveCoroutine = StartCoroutine(MoveToCoroutine());
    }

    private IEnumerator MoveToCoroutine()
    {
        while (_targetPositions.Count > 0)
        {
            Vector3 startPoint = transform.position;
            Vector3 targetPosition = _targetPositions.Dequeue();
            float progress = 0;

            while (progress < 1)
            {
                progress += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(startPoint, targetPosition, progress);
                yield return null;
            }

            transform.position = targetPosition;
        }

        _moveCoroutine = null;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}