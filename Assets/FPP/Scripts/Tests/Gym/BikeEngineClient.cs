using UnityEngine;
using UnityEditor;
using FPP.Scripts.Ingredients.Bike.Engine;

namespace Nerdtron.BladeRacer.Test.Gym
{
    public class BikeEngineClient : MonoBehaviour
    {
        private BikeEngine _bikeEngine;
    
        void Start()
        {
            _bikeEngine = (BikeEngine) FindObjectOfType(typeof(BikeEngine));
        }
        
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 100, 200, 200));

            if (GUILayout.Button("Turn On", EditorStyles.miniButtonRight))
                _bikeEngine.TurnOn();
            
            if (GUILayout.Button("Turn Off"))
                _bikeEngine.TurnOff();
            
            if (GUILayout.Button("Toggle Turbo"))
                _bikeEngine.ToggleTurbo();
            
            GUILayout.EndArea();
        }
    }
}