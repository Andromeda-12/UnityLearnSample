using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private InteractiveBox rememberedObject;

    private Camera cam;

    private const string InteractivePlane = "InteractivePlane";

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag(InteractivePlane))
                {
                    Instantiate(prefab, hit.point + hit.normal / 2, Quaternion.identity);
                }

                if (hit.collider.gameObject.GetComponent<InteractiveBox>() != null)
                {
                    if (rememberedObject is null)
                    {
                        rememberedObject = hit.collider.gameObject.GetComponent<InteractiveBox>();
                        return;
                    }

                    rememberedObject.AddNext(hit.collider.gameObject.GetComponent<InteractiveBox>());
                    rememberedObject = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<InteractiveBox>() != null)
                    Destroy(hit.collider.gameObject);
            }
        }
    }
}
