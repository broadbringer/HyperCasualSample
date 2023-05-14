using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class BoxesShelterFactory : MonoBehaviour
    {
        public BoxesShelter BoxesShelter;
        public Vector3 PlacePosition;

        private void Start() => 
            Instantiate(BoxesShelter, PlacePosition, Quaternion.identity);
    }
}