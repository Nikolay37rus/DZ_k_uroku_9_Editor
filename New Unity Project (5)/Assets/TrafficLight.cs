using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [ExecuteAlways]
    public class TrafficLight : MonoBehaviour
    {
        public bool IsSwitched;

        private MeshRenderer meshRendererComponent;

        public Material Gray;
        public Material Red;
        public Material Green;

        private float timeToSwitch = 1;

        private void Start()
        {
            meshRendererComponent = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            if (Application.IsPlaying(gameObject))
            {
                timeToSwitch -= Time.deltaTime;
                if (timeToSwitch < 0)
                {
                    IsSwitched = !IsSwitched;
                    timeToSwitch = 1;
                }
            }

            meshRendererComponent.sharedMaterials = new[]
            {
            Gray,
            IsSwitched ? Gray : Red,
            Gray,
            IsSwitched ? Green : Gray,
            IsSwitched ? Red : Gray,
            Gray,
            IsSwitched ? Gray : Green
        };
        }
    }

