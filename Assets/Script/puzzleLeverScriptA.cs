using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class puzzleLeverScriptA : MonoBehaviour
{
    [Tooltip("Distance at which the object is considered 'Near'")]
    public float nearDistance = 30f;
    public ParticleSystem fireEffectA;
    public ParticleSystem fireEffectB;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;
    AN_HeroInteractive hero;

    puzzleDoorScript door;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fireEffectA.Stop();
        fireEffectB.Stop();
        hero = FindObjectOfType<AN_HeroInteractive>();
        door = FindObjectOfType<puzzleDoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            if (anim.GetBool("LeverUp") == true)
            {
                anim.SetBool("LeverUp", false);
                if (fireEffectA != null)
                {
                    if (!fireEffectA.isPlaying)
                    {
                        // Start the fire effect if it's not playing
                        fireEffectA.Play();
                        door.lockA = true;
                    }
                    else
                    {
                        // Stop the fire effect if it's playing
                        fireEffectA.Stop();
                        door.lockA = false;
                    }
                }

                if (fireEffectB != null)
                {
                    if (!fireEffectB.isPlaying)
                    {
                        // Start the fire effect if it's not playing
                        fireEffectB.Play();
                        door.lockB = true;
                    }
                    else
                    {
                        // Stop the fire effect if it's playing
                        fireEffectB.Stop();
                        door.lockB = false;
                    }
                }
            }
            else
            {
                anim.SetBool("LeverUp", true);
                if (fireEffectA != null)
                {
                    if (!fireEffectA.isPlaying)
                    {
                        // Start the fire effect if it's not playing
                        fireEffectA.Play();
                        door.lockA = true;
                    }
                    else
                    {
                        // Stop the fire effect if it's playing
                        fireEffectA.Stop();
                        door.lockA = false;
                    }
                }

                if (fireEffectB != null)
                {
                    if (!fireEffectB.isPlaying)
                    {
                        // Start the fire effect if it's not playing
                        fireEffectB.Play();
                        door.lockB = true;
                    }
                    else
                    {
                        // Stop the fire effect if it's playing
                        fireEffectB.Stop();
                        door.lockB = false;
                    }
                }
            }
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        float distance = Vector3.Distance(transform.position, hero.transform.position);
        if (distance < nearDistance)
            return true;
        else
            return false;
    }
}
