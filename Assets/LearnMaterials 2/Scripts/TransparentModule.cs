using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[HelpURL("https://docs.google.com/document/d/1Cmm__cbik5J8aHAI6PPaAUmEMF3wAcNo3rpgzsYPzDM/edit?usp=sharing")]
public class TransparentModule : MonoBehaviour
{
    private float defaultAlpha;
    private Material mat;
    private bool toDefault;

    [SerializeField]
    [Min(0)]
    private float changeSpeed;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        defaultAlpha = mat.color.a;
        toDefault = false;
    }

    [ContextMenu("Activate")]
    public void ActivateModule()
    {
        float target = toDefault ? defaultAlpha : 0;
        StopAllCoroutines();
        StartCoroutine(ChangeTransparencyCoroutine(new Color(mat.color.r, mat.color.g, mat.color.b, target)));
        toDefault = !toDefault;
    }
    [ContextMenu("Reset")]

    public void ReturnToDefaultState()
    {
        toDefault = true;
        ActivateModule();
    }

    private IEnumerator ChangeTransparencyCoroutine(Color target)
    {
        Color start = mat.color;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            mat.color = Color.Lerp(start, target, t);
            yield return null;
        }
        mat.color = target;
    }
}
