using UnityEngine;
using WRA.CharacterSystems.SkillsSystem;

namespace WRA.CharacterSystems
{
    [RequireComponent(typeof(CharacterObject))]
    public class CharacterSystemBase : MonoBehaviour
    {
        public CharacterObject CharacterObject
        {
            get
            {
                if (characterObject == null)
                {
                    characterObject = GetComponent<CharacterObject>();
                }

                return characterObject;
            }
        }
        private CharacterObject characterObject;
        private CharacterData characterData;
        public void SetCharacterObject(CharacterObject characterObject)
        {
            this.characterObject = characterObject;
            OnInitDone();
        }
    
        public T GetCharacterSystem<T>() where T : CharacterSystemBase
        {
            return characterObject.GetCharacterSystem<T>();
        }
        
        public CharacterData GetCharacterData()
        {
            if (characterData == null)
            {
                characterData = new CharacterData(CharacterObject);
            }

            return characterData;
        }
        
        public virtual void OnInitDone() {}
    }
}
