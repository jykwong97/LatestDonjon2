using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_DoorKey : MonoBehaviour
{
    [Tooltip("True - red key object, false - blue key")]
    public bool isRedKey = true;
    AN_HeroInteractive hero;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    private void Start()
    {
        hero = FindObjectOfType<AN_HeroInteractive>(); // key will get up and it will saved in "inventary"
    }

    void Update()
    {
        if ( NearView() && Input.GetKeyDown(KeyCode.E) )
        {
            if (isRedKey) hero.RedKeyCount++;
            else hero.BlueKey = true;
            Destroy(gameObject);
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, hero.transform.position);
        if (distance < 30f) return true; // angleView < 35f && 
        else return false;
    }
}
