using System.Collections;
using UnityEngine;

public class ViolettaSampleScript : SampleScript
{
    private float changeSpeed = 0.5f;
    private Vector3 targetScale = Vector3.zero;

    [SerializeField]
    private Transform target;

    [ContextMenu("Start")]
    public override void Use()
    {
        for (int i = 0; i < target.childCount; i++)
        {
            StartCoroutine(ScaleCoroutine(target.GetChild(i)));
        }
    }

    private IEnumerator ScaleCoroutine(Transform transform)
    {
        Vector3 start = transform.lossyScale;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            transform.localScale = Vector3.Lerp(start, targetScale, t);
            yield return null;
        }

        Destroy(transform.gameObject);
    }
}