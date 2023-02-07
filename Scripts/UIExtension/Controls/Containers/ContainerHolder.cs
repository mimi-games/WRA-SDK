using UnityEngine;
using WRACore.Container;
using WRACore.DependentObjects.ScriptableObjects;

namespace WRACore.UIExtension.Controls.Containers
{
    public abstract class ContainerHolder : MonoBehaviour
    {
        public Container.Container Container => container;
        public ContainerItem HoldingItem => holdingItem;
        
        protected Container.Container container;
        protected ContainerItem holdingItem;
    
        public virtual void InitContainerHolder(Container.Container container, ContainerSlot holdingItem)
        {
            this.container = container;
            this.holdingItem = holdingItem == null ? null : holdingItem.Item;
        }

        public abstract void Reset();
    }
}
