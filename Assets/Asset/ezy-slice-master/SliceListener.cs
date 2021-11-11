using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    public Slicer slicer;
    public PlayerController playerController;

    public AudioClip sound_picon;
    AudioSource audioSource;

    [SerializeField]
    public Animator FlagAnimator;
    public GameObject winResult;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //FlagAnimator = FlagAnimator.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
        slicer.isTouched = true;
        if (other.gameObject.tag == "Goal")
        {
           
            //sound
            if (playerController.GoalFlag == true)
            {
                slicer.GetComponent<Slicer>().MakeParticle(hitPos, 2);//hitPosじゃなくて旗のところに生成みたいです　ここで旗の座標入っていい

                //音(sound_picon)を鳴らす
                audioSource.PlayOneShot(sound_picon);

                //旗
                FlagAnimator.SetTrigger("FlagOn");

                playerController.GoalFlag = false;

                winResult.SetActive(true);


            }
            

        }
    }
   
}
