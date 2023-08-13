using System.Collections.Generic;
using DependentObjects.Classes;
using DependentObjects.ScriptableObjects;
using UnityEngine;

namespace Character
{
    public class ActionController : MonoBehaviour
    {
        private List<ActionBase> activeActions = new List<ActionBase>();
        private List<Coroutine> coroutines = new List<Coroutine>();

        private ActionData actionData;

        public void BeginAction(ActionBase actionBase)
        {
            var cor = StartCoroutine(actionBase.ActionEngine(actionData));
            activeActions.Add(actionBase);
            coroutines.Add(cor);
        }

        public void BreakAction(ActionBase actionBase)
        {
        
        }

        public void BreakAction(string actionName)
        {
        
        }
    }
}
