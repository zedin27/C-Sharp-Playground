using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl2 : MonoBehaviour
{
    [SerializeField] PlayerControl2 _playerControlScript;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _lerpSpeed;

    bool _iskeepLerping = false;
    float _lerpVal = 0f;

    private void LateUpdate()
    {
        if (!_playerControlScript.gameOver)
        {
            if (!_playerControlScript.HasFireFirstInput)
            return;
        if (_playerControlScript.IsIdle)
            MoveAway();
        else
            Lerp();
        }
    }

    private void MoveAway()
    {
        _iskeepLerping = false;
        transform.position = new Vector3(transform.position.x + 0.69f * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void Lerp()
    {
        if (!_iskeepLerping)
            _lerpVal = 0f;
        
        Vector3 newCameraPos = Vector3.Lerp(transform.position, _playerControlScript.transform.position + _offset, _lerpVal);
        transform.position = newCameraPos;
        _lerpVal += _lerpSpeed * Time.deltaTime;
        _iskeepLerping = true;
    }
}