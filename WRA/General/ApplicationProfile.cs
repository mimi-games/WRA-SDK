using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WRA.General.Cursor;
using WRA.General.Patterns.Singletons;

namespace WRA.General
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Profiles/Application Profile", fileName = "Application Profile")]
    public class ApplicationProfile : ScriptableSingleton<ApplicationProfile>
    {
        public SystemLanguage Language = SystemLanguage.English;
        public List<TextAsset> Langs;
        public bool CustomConsole = false;

        public CursorData CursorData;
        
        public List<KeyedData> fonts;
    }

    [Serializable]
    public class KeyedData
    {
        public string name;
        public Font defaultFont;
        public TMP_FontAsset tmpFont;
    }
}
