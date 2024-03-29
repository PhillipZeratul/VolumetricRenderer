﻿using UnityEngine;

namespace Volumetric
{
    //[ExecuteInEditMode]
    public class VolumetricMaterialVolume : MonoBehaviour
    {
        // TODO: Scale with 1000m?
        private const float scatterScale = 0.00692f;
        private const float absorptScale = 0.00077f;

        public enum VolumeType
        {
            Constant,
            Box
        }

        public enum BlendType
        {
            Additive,
            AlphaBlend
        }

        public VolumeType volumeType;
        public BlendType blendType;

        [Space]
        [SerializeField]
        [ColorUsage(false, true)]
        private Color scatteringColor = new Color(0.58f, 0.58f, 0.58f);
        [SerializeField]
        //[Range(0.00001f, 10.0f)]
        private float absorption = 0.58f;
        [Range(0.0f, 0.99f)]
        public float phaseG = 0.002f;

        // Global emissive intensity
        // Ambient intensity
        // Water droplet density

        [Space]
        [SerializeField]
        public Texture3D noiseTex;
        [SerializeField]
        public Vector3 scrollingSpeed = new Vector3();
        [SerializeField]
        public Vector3 tiling = new Vector3();

        public Color ScatteringCoef
        {
            get { return scatteringColor * scatterScale; }
        }

        public float AbsorptionCoef
        {
            get { return absorption * absorptScale; }
        }

        private VolumetricRenderer volumetricRenderer;

        private void OnEnable()
        {
            // TODO: Better way to get volumetricRenderer.
            volumetricRenderer = GameObject.FindObjectOfType<VolumetricRenderer>();
            if (volumetricRenderer != null)
            {
                volumetricRenderer.RegisterMaterialVolume(this);
            }
        }

        private void OnDisable()
        {
            if (volumetricRenderer != null)
            {
                volumetricRenderer.UnregisterMaterialVolume(this);
            }
        }
    }
}