using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SignalEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _audioSource;

    private IEnumerator _signal;
    private float _minVolume = 0.1f;
    private float _maxVolume = 1f;
    private float _stepLoudVolume = 0.1f;
    private float _waitingSeconds = 0.3f;

    private void Update()
    {
        if (_signal != null && _audioSource.isPlaying && _audioSource.volume <= _minVolume)
        {
            _audioSource.Stop();
            StopCoroutine(_signal);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _reached?.Invoke();
            _signal = ChangeSignalVolume(_maxVolume);
            StartCoroutine(_signal);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            if (_signal != null)
            {
                StopCoroutine(_signal);
            }

            _signal = ChangeSignalVolume(_minVolume);
            StartCoroutine(_signal);
        }
    }

    private IEnumerator ChangeSignalVolume(float target)
    {
        var wait = new WaitForSeconds(_waitingSeconds);

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _stepLoudVolume);
            yield return wait;
        }
    }
}
