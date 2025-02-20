using UnityEngine;
using System.Collections.Generic;

namespace FPP.Scripts.Ingredients.Track
{
    [CreateAssetMenu(fileName = "NewRaceTrack", menuName = "Ingredients/RaceTrack", order = 1)]
    public class RaceTrack : ScriptableObject
    {
        [Tooltip("The expected length of segments")]
        public float segmentLength;

        [Tooltip("Add segments in expected loading order")]
        public List<GameObject> segments = new();
    }
}