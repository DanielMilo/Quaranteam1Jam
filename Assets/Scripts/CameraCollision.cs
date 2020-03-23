using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform referenceTransform;
    public float collisionOffset = 0.5f; //To prevent Camera from clipping through Objects

    Vector3 defaultPos;
    Vector3 directionNormalized;
    Transform parentTransform;
    float defaultDistance;

    Vector3 smoothVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.localPosition;
        directionNormalized = defaultPos.normalized;
        parentTransform = transform.parent;
        defaultDistance = Vector3.Distance(defaultPos, Vector3.zero);
    }

    // FixedUpdate for physics calculations
    void LateUpdate()
    {
        Vector3 currentPos = defaultPos;
        RaycastHit hit;
        Vector3 dirTmp = parentTransform.TransformPoint(defaultPos) - referenceTransform.position;
        if (Physics.SphereCast(referenceTransform.position, collisionOffset, dirTmp, out hit, defaultDistance))
        {
            currentPos = (directionNormalized * (hit.distance - collisionOffset));
        }

        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, currentPos, ref smoothVelocity, 2f);
    }
}