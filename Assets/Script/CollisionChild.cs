using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChild : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rbKnife;           //©—Í‚ğ‰Á‚¦‚é‘ÎÛ
    [SerializeField]
    private GameObject goKife;

    public AudioClip sound_can;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //Component‚ğæ“¾
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("•¿‚ÅG‚ê‚½");
        ////‰¹(sound_can)‚ğ–Â‚ç‚·
        //audioSource.PlayOneShot(sound_can);

    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {

        Debug.Log("•¿‚ÅG‚ê‚½");
        //‰¹(sound_can)‚ğ–Â‚ç‚·
        audioSource.PlayOneShot(sound_can);

    }
}
