using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onDestroyObstacle;

    private float currentValue;
    private Renderer rend;

    private void Start()
    {
        currentValue = 1;
        onDestroyObstacle.AddListener(() => Destroy(gameObject));
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }

    public void GetDamage(float value)
    {
        if (currentValue > 0)
        {
            currentValue -= value;
            rend.material.color = Color.Lerp(Color.white, Color.red, 1 - currentValue);
        }
        else
        {
            currentValue = 0;
            onDestroyObstacle?.Invoke();
        }
    }
}
