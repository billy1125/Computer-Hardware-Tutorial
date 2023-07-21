using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class RayCast : MonoBehaviour
{
    bool OultineAnimation = true;
    bool pingPong = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                ClassManager.instance.SelectModelName = hit.transform.tag;

                //float x = Mathf.RoundToInt(hit.point.x);
                //float y = Mathf.RoundToInt(hit.point.y);
                //float z = Mathf.RoundToInt(hit.point.z);
                //Debug.Log(x.ToString() + ", " + y.ToString() + ", " + z.ToString());

                if (hit.transform.gameObject.GetComponent<Outline>() != null) {
                    ClassManager.instance.CheckModelName = hit.transform.tag;
                    //if (hit.transform.gameObject.GetComponent<Outline>().eraseRenderer)
                    //{                                
                    //    hit.transform.gameObject.GetComponent<Outline>().eraseRenderer = false;
                    //    OultineAnimation = true;
                    //}
                    //else
                    //{
                    //    hit.transform.gameObject.GetComponent<Outline>().eraseRenderer = true;
                    //    OultineAnimation = false;
                    //}
                }

                //transform.position = new Vector3(x, 0, z);
            }
        }

        if (OultineAnimation)
            MakeOutlineAnimation();
    }

    void MakeOutlineAnimation()
    {
        Color c0 = GetComponent<OutlineEffect>().lineColor0;
        Color c1 = GetComponent<OutlineEffect>().lineColor1;

        if (pingPong)
        {
            c0.a += Time.deltaTime;
            c1.a += Time.deltaTime;

            if (c0.a >= 1)
                pingPong = false;
        }
        else
        {
            c0.a -= Time.deltaTime;
            c1.a -= Time.deltaTime;

            if (c0.a <= 0)
                pingPong = true;
        }

        c0.a = Mathf.Clamp01(c0.a);
        c1.a = Mathf.Clamp01(c1.a);
        GetComponent<OutlineEffect>().lineColor0 = c0;
        GetComponent<OutlineEffect>().lineColor1 = c1;
        GetComponent<OutlineEffect>().UpdateMaterialsPublicProperties();
    }

}
