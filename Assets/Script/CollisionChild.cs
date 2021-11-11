using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChild : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rbKnife;           //���͂�������Ώ�
    [SerializeField]
    private GameObject goKife;

    public AudioClip sound_can;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("���ŐG�ꂽ");
        ////��(sound_can)��炷
        //audioSource.PlayOneShot(sound_can);

    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {

        Debug.Log("���ŐG�ꂽ");
        //��(sound_can)��炷
        audioSource.PlayOneShot(sound_can);

    }
}
