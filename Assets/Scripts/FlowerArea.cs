using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace App
{
    /// <summary>
    /// Manages a collection of flower plants and attached flowers
    /// </summary>
    public class FlowerArea : MonoBehaviour
    {
        public const float AreaDiameter = 20f;

        [SerializeField] private List<GameObject> flowerPlants;

        private Dictionary<Collider, Flower> nectarLookup;

        public List<Flower> Flowers { get; private set; }


        /// <summary>
        /// Reset flowers and flower plants
        /// </summary>
        public void ResetFlowers()
        {
            foreach (GameObject flowerPlant in flowerPlants)
            {
                float xRotation = Random.Range(-5f, 5f);
                float yRotation = Random.Range(-180f, 180f);
                float zRotation = Random.Range(-5f, 5f);

                flowerPlant.transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
            }

            foreach (Flower flower in Flowers)
            {
                flower.ResetFlower();
            }
        }

        /// <summary>
        /// Gets the <see cref="Flower"/> that a nectar collider belongs to
        /// </summary>
        /// <param name="collider">The nectar collider</param>
        /// <returns>The matching flower</returns>
        public Flower GetFlowerFromNectar(Collider collider)
        {
            return nectarLookup[collider];
        }

        private void Awake()
        {
            flowerPlants = new List<GameObject>();
            nectarLookup = new Dictionary<Collider, Flower>();
            Flowers = new List<Flower>();
        }

        private void Start()
        {
            FindChildFlowers(transform);
        }

        /// <summary>
        /// Recursively finds all flowers and flower plants that are children of a parent transform.
        /// </summary>
        /// <param name="parent">The parent of the children to check</param>
        private void FindChildFlowers(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);

                if (child.CompareTag("flower_plant"))
                {
                    flowerPlants.Add(child.gameObject);
                    FindChildFlowers(child);
                }
                else
                {
                    child.TryGetComponent(out Flower flower);
                    if (flower)
                    {
                        Flowers.Add(flower);
                        nectarLookup.Add(flower.NectarCollider, flower);
                    }
                    else
                        FindChildFlowers(child);
                }
            }
        }
    }
}