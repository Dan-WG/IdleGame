using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Idle
{
    public class CameraShake : MonoBehaviour
    {
        //Making the camera shake effect, takes Transform (camera to shake), float duration, float magnitude
        public static IEnumerator Shake(Transform transform, float duration, float magnitude)
        {
            Vector3 originalPos = transform.localPosition; //Cache position before animation startы

            float elapsed = 0.0f;

            //We do a loop for animation
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z); //assign camera changed coordinates

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos; //We return cached coordinates
        }

    }
}
