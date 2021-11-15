using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleCollision : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rbKnife;           //���͂�������Ώ�
    [SerializeField]
    private GameObject goKnife;
    [SerializeField]
    public AudioClip sound_can;
    [SerializeField]
    public Transform handle_pos;
    [SerializeField]
    public Vector3 force;
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
        this.transform.position = handle_pos.position;
        this.transform.rotation = handle_pos.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "paka" || collision.gameObject.tag == "pica" || collision.gameObject.tag == "chopp")
        {
            goKnife.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
            Invoke("SetColorBack", 0.1f);
            rbKnife.AddForce(force);
            Debug.Log("���ŐG�ꂽ");
            //��(sound_can)��炷
            audioSource.PlayOneShot(sound_can);
        }

        if (collision.gameObject.tag == "Ground")
        {
            goKnife.GetComponent<PlayerController>().ConstraintsFlag = false;
            rbKnife.constraints = RigidbodyConstraints.None;
            goKnife.GetComponent<PlayerController>().LosePanel.SetActive(true);
        }


    }

    private void SetColorBack()
    {
        goKnife.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }

}
