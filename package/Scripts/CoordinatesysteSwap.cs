using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace GaussianSplatting.Runtime
{
    public class CoordinateSystemSwap : MonoBehaviour
    {
        // Names of the objects to be used
        private string object1Name = "GSCutout";
        private string object2Name = "GaussianSplats";

        void Start()
        {
            // Find the objects in the scene
            GameObject object1 = GameObject.Find(object1Name);
            GameObject object2 = GameObject.Find(object2Name);

            if (object1 == null || object2 == null)
            {
                UnityEngine.Debug.LogError($"Either {object1Name} or {object2Name} could not be found in the scene.");
                return;
            }

            // Save object2's current world transform values
            Vector3 originalPosition = object2.transform.position;
            Quaternion originalRotation = object2.transform.rotation;
            Vector3 originalScale = object2.transform.localScale;

            // Set object1 as the new parent of object2
            object2.transform.SetParent(object1.transform, true);

            // Restore the world position, rotation, and scale for object2
            object2.transform.position = originalPosition;
            object2.transform.rotation = originalRotation;
            object2.transform.localScale = originalScale;

            UnityEngine.Debug.Log($"{object2Name} is now using {object1Name}'s coordinate system while preserving its world transform.");
        }
    }
}

