using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePosition : MonoBehaviour
{
    Vector3 hitPosition;
    Camera camera;
    [SerializeField] GameObject tester;
    [SerializeField] GameObject tester2;
    [SerializeField] Transform midPoint;
    [SerializeField] RectTransform buttons;
    RaycastHit hit;
    Vector2 mousePosition;
    bool instantiates = false;
    private void Awake()
    {
        camera = FindObjectOfType<Camera>();
    }
    public void CheckPoint()
    {

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && !instantiates) //check if the ray hit something
        {
            hitPosition = hit.point; //use this position for what you want to do
            mousePosition = Input.mousePosition;
            ShowButtons();
        }
        if (!instantiates)
        {       
            instantiates = true;
            StartCoroutine(Delay(1f));
        }
    }

    private void ShowButtons()
    {
        buttons.gameObject.SetActive(true);
        buttons.transform.position = mousePosition;
    }

    public void InstantiateObject(int i)
    {
        instantiates = true;
        GameObject obj = tester;
        if (i == 2)
            obj = tester2;

        GameObject blocki = Instantiate(obj, hitPosition, Quaternion.identity,transform);
        blocki.transform.LookAt(midPoint);
        blocki.transform.Rotate(-180f, 0f, 0f);
        StartCoroutine(Delay(1f));
    }
    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        instantiates = false;
    }
}
