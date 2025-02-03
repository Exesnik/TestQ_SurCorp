using UnityEngine;
using UnityEngine.Events;

public class Slide : MonoBehaviour
{
    public ConfigurableJoint joint;
    public Vector3 retractedPosition;
    public float pullDistance = 0.1f;
    public float threshold = 0.02f;     
    public UnityEvent OnRetracted;
    public UnityEvent OnReleased;

    private Vector3 startPos;
    private bool isRetracted;

    void Start()
    {
        if (joint == null)
            joint = GetComponent<ConfigurableJoint>();
        startPos = transform.localPosition;
    }

    void FixedUpdate()
    {
        
        float pos = Mathf.Clamp01((transform.localPosition.z - startPos.z) / pullDistance);

        if (!isRetracted && pos >= 1 - threshold)
        {
            isRetracted = true;
            if (OnRetracted != null)
                OnRetracted.Invoke();
        }
        else if (isRetracted && pos <= threshold)
        {
            isRetracted = false;
            if (OnReleased != null)
                OnReleased.Invoke();
        }
    }

    public void Pull()
    {
        joint.targetPosition = retractedPosition;
    }

    public void Release()
    {
        joint.targetPosition = Vector3.zero;
    }
}
