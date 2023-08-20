using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Perception : MonoBehaviour
{

    [SerializeField] float _viewDistance;
    [SerializeField] float _fieldOfViewAngle;

    Transform _target;

    public LayerMask _targetMask;

    private bool DetectPlayer()
    {
        // Check if there is a player in the AI's field of view

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, _viewDistance, _targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _fieldOfViewAngle / 2f)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget))
                {
                    _target = target;
                    return target;
                }
            }
        }

        return false;
    }
}
