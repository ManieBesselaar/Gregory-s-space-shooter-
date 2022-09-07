using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform _target;

    private void LateUpdate()
    {
        transform.rotation = _target.rotation;
    }
}
