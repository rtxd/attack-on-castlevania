using System.Collections;
using UnityEngine;

namespace Assets
{
    public class ArrowScript : MonoBehaviour
    {
        public float force = 10;
        // Use this for initialization
        void Start()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}