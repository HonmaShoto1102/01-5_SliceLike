using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyChange : MonoBehaviour
{
#if UNITY_EDITOR

    public float Multiplier = 3f;//�d�͂̑傫��//�P���ʏ�
    private void Reset()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnValidate()
    {
        _rigidbody.centerOfMass = _centerMassPosition;
        // Start���ɓ����ĂȂ���Ԃ���Sleep�ɂȂ�̂ŉ������Ă�����
        if (_rigidbody.IsSleeping())
        {
            _rigidbody.WakeUp();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce((Multiplier - 1f) * Physics.gravity, ForceMode.Acceleration);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position + transform.rotation * _centerMassPosition, "center");
    }

#endif

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Vector3 _centerMassPosition = Vector3.zero;
}
