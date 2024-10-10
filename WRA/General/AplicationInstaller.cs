using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Data;
using WRA.General.Cursor;
using WRA.PlayerSystems.LanguageSystem;
using Zenject;

namespace WRA.General
{
    public class AplicationInstaller : MonoInstaller
    {
        [SerializeField] private CursorManager cursorManager;
        [SerializeField] private LanguageManager languageManager;
        [SerializeField] private ApplicationProfile ApplicationProfile;
        [SerializeField] private StatisticsProfile statisticsProfile;
        
        public override void InstallBindings()
        {
            Container.Bind<CursorManager>().FromInstance(cursorManager).AsSingle();
            Container.Bind<LanguageManager>().FromInstance(languageManager).AsSingle();
            Container.Bind<ApplicationProfile>().FromInstance(ApplicationProfile).AsSingle();
            Container.Bind<StatisticsProfile>().FromInstance(statisticsProfile).AsSingle();
        }
    }
}
