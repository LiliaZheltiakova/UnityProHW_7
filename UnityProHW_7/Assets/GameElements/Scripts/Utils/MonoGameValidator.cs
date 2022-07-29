#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;

namespace GameElements
{
    public static class MonoGameValidator
    {
        public static void ValidateGameElements(ref List<MonoBehaviour> gameElements)
        {
            var result = new HashSet<MonoBehaviour>();
            foreach (var gameElement in gameElements)
            {
                if (gameElement is IGameElement)
                {
                    result.Add(gameElement);
                }
            }

            gameElements = new List<MonoBehaviour>(result);
        }

        public static void ValidateGameServices(ref List<MonoBehaviour> services)
        {
            var result = new HashSet<MonoBehaviour>();
            foreach (var service in services)
            {
                if (service != null)
                {
                    result.Add(service);
                }
            }

            services =  new List<MonoBehaviour>(result);
        }
    }
}
#endif