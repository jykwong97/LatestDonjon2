using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class puzzleLeverScriptA : MonoBehaviour
{
    [Tooltip("Distance at which the object is considered 'Near'")]
    public float nearDistance = 30f;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            if (anim.GetBool("LeverUp") == true)
            {
                anim.SetBool("LeverUp", false);
            }
            else
            {
                anim.SetBool("LeverUp", true);
            }
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < nearDistance) return true; // angleView < 35f && 
        else return false;
    }
}
