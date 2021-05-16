using System;
using UnityEngine;

namespace App
{
    public class Flower : MonoBehaviour
    {
        [Tooltip("Full Flower Color")] [SerializeField]
        private Color fullFlowerColor = new Color(1f, 0f, 0.3f);

        [Tooltip("Empty Flower Color")] [SerializeField]
        private Color emptyFlowerColor = new Color(0.5f, 0f, 1f);

        [SerializeField] private Collider nectarCollider = default;
        [SerializeField] private Collider flowerCollider = default;
        
        public Collider NectarCollider => nectarCollider;
        public float NectarAmount { get; private set; }
        public bool hasNectar => NectarAmount < 0f;
        public Vector3 FlowerUpVector => nectarCollider.transform.up;
        public Vector3 FlowerCenterPosition => nectarCollider.transform.position;

        /// <summary>
        /// Attempts to remove nectar from the flower
        /// </summary>
        /// <param name="amount">The amount of nectar to remove</param>
        /// <returns>The actual amount successfully removed.</returns>
        public float Feed(float amount)
        {
            //Track amount
            float nectarTaken = Mathf.Clamp(amount, 0f, NectarAmount);

            //Subtract
            NectarAmount -= amount;
            if (NectarAmount <= 0)
            {
                //No nectar remaining
                NectarAmount = 0;

                //Disable
                flowerCollider.gameObject.SetActive(false);
                nectarCollider.gameObject.SetActive(false);

                //Change Color
                _flowerMaterial.SetColor(BaseColor, emptyFlowerColor);
            }

            return nectarTaken;
        }

        
        /// <summary>
        /// Resets the flower
        /// </summary>
        public void ResetFlower()
        {
            NectarAmount = 1f;
            flowerCollider.gameObject.SetActive(true);
            nectarCollider.gameObject.SetActive(true);
            _flowerMaterial.SetColor(BaseColor, fullFlowerColor);
        }

        private void Awake()
        {
            MeshRenderer meshRend = GetComponent<MeshRenderer>();
            _flowerMaterial = meshRend.material;
            ResetFlower();
        }
        
        private Material _flowerMaterial;
        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    }
}