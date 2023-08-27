using UnityEngine;
using UnityEngine.Events;

public class Event : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _audioSource;
    private bool _isSignal = false;
    private float _minVolume = 0.1f;
    private float _maxVolume = 1f;
    private float _stepLoudVolume = 0.35f;

    private void Update() {
        if(_isSignal)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _stepLoudVolume * Time.deltaTime);
        }
        else if(_audioSource.isPlaying && _audioSource.volume > _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _stepLoudVolume * Time.deltaTime);
        }
        else if(_audioSource.isPlaying && _audioSource.volume <= _minVolume)
        {
            _audioSource.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.TryGetComponent<Thief>(out Thief thief))
        {
            _isSignal = true;
            _reached?.Invoke();
        }
    }

    private void OnTriggerExit2D() {
        _isSignal = false;
    }
}
