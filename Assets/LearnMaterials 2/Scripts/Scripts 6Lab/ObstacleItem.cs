using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentValue;
    private Renderer rend;
    [SerializeField]
    private UnityEvent onDestroyObstacle;

    void Start()
    {
        currentValue = 1;
        onDestroyObstacle.AddListener(() => Destroy(gameObject));
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        StartCoroutine(GetDamage(0.2f));
    }

    private IEnumerator GetDamage(float value)
    {
        currentValue -= value;
        Color endColor = new Color((1 - currentValue) * 255, 0, 0);
        Color startColor = rend.material.color;

        float t = 0;
        while (t < 1)
        {
            rend.material.color = Color.Lerp(startColor, endColor, 1) * Time.deltaTime;
            t += Time.deltaTime;
            yield return null;
        }

        if (currentValue <= 0)
            onDestroyObstacle.Invoke();
    }
}
