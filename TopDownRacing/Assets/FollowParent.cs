using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour
{
    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        parentTransform = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        updateTransformToFollowParent();
    }

    private void updateTransformToFollowParent()
    {
        Transform newParentTransform = GetComponentInParent<Transform>();
        if (parentTransform != newParentTransform)
        {
            GetComponent<Transform>().position += newParentTransform.position - parentTransform.position;
        }
    }
}
