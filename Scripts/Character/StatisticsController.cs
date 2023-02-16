using DependentObjects.Classes;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class StatisticsController : MonoBehaviour
    {
        public UnityEvent OnStatisticsChanged = new UnityEvent();
    
    
        [SerializeField] private StatisticsHolder baseStatistics;


        public StatisticsHolder GetStatistics()
        {
            return baseStatistics;
        }
    }
}
