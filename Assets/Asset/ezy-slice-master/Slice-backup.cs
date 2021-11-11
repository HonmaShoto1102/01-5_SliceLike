//using UnityEngine;
//using EzySlice;
//public class Slicer : MonoBehaviour
//{
//    public Material[] materialAfterSlice;
//    public LayerMask sliceMask;
//    public bool isTouched;
//    public int SliceNum = 0;
//    public float ItemMass = 500;
//    public float ItemDrag = 2;
//    public float ItemAngularDrag = 0.2f;
//    public float speed = 10;
//    public GameObject DirtSplatterParticlesPrefab;
//    public AudioClip sound_paka, sound_chopp, sound_pica;
//    AudioSource audioSource;

//    private void Start()
//    {
//        SliceNum = 0;
//        audioSource = GetComponent<AudioSource>();
//    }
//    private void Update()
//    {
//        if (isTouched == true)
//        {
//            isTouched = false;
//            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(0.005f, 0.25f, 0.35f),
//                transform.rotation, sliceMask);


//            foreach (Collider objectToBeSliced in objectsToBeSliced)
//            {
//                SliceNum++;
//                if (SliceNum > materialAfterSlice.Length - 1)
//                {
//                    SliceNum = 0;
//                }
//                Destroy(objectToBeSliced.gameObject);
//                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice[SliceNum]);


//                if (slicedObject != null)
//                {

//                    GameObject lower = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice[SliceNum]);
//                    GameObject upper = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice[SliceNum]);
//                    upper.transform.position = objectToBeSliced.transform.position;
//                    lower.transform.position = objectToBeSliced.transform.position;

//                    if (objectToBeSliced.tag == "paka")
//                    {
//                        //音(sound_paka)を鳴らす
//                        audioSource.PlayOneShot(sound_paka);
//                    }
//                    if (objectToBeSliced.tag == "chopp")
//                    {
//                        //音(sound_chopp)を鳴らす
//                        audioSource.PlayOneShot(sound_chopp);
//                    }
//                    if (objectToBeSliced.tag == "pica")
//                    {
//                        //音(sound_pica)を鳴らす
//                        audioSource.PlayOneShot(sound_pica);
//                    }

//                    GameObject spl = Instantiate(DirtSplatterParticlesPrefab, objectToBeSliced.transform.position, Quaternion.identity);
//                    //スプラッシュエフェクト
//                    spl.GetComponent<ParticleSystem>().Play();
//                    Destroy(spl, 2.0f);
//                    MakeItPhysical(lower, 1);
//                    MakeItPhysical(upper, -1);
//                }
//            }





//        }



//    }
//    private void MakeItPhysical(GameObject obj, int direction)
//    {
//        obj.AddComponent<MeshCollider>().convex = true;

//        Rigidbody rb = obj.AddComponent<Rigidbody>();
//        rb.mass = ItemMass;
//        rb.constraints = RigidbodyConstraints.FreezePositionZ;
//        // | RigidbodyConstraints.FreezeRotationY
//        // | RigidbodyConstraints.FreezeRotationZ;
//        rb.drag = ItemDrag;
//        rb.angularDrag = ItemAngularDrag;
//        Vector3 force = obj.transform.forward * speed * direction;
//        rb.AddForce(force);

//    }

//    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
//    {
//        return obj.Slice(transform.position, transform.right, crossSectionMaterial);
//    }



//}
