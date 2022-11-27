using System;
using Container;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIExtension.UI
{
    public abstract class Dragable<T> : ContainerHolder<T>, IBeginDragHandler, IEndDragHandler, IDragHandler where T : ContainerItem
    {
        [SerializeField] protected Color defaultColor = Color.white;
        [SerializeField] protected Color draggingColor = new (1,1,1, 0.7f);

        public ContainerItem ContainerItem
        {
            get => containerItem;
            set => containerItem = value;
        }

        protected Image Image
        {
            get
            {
                if (image == null)
                {
                    image = GetComponent<Image>();
                }

                return image;
            }
        }
        
        protected CanvasGroup CanvasGroup
        {
            get
            {
                if (canvasGroup == null)
                {
                    canvasGroup = GetComponent<CanvasGroup>();
                }

                return canvasGroup;
            }
        }
        
        protected Vector3 offset;
        
        private Image image;
        private CanvasGroup canvasGroup;
        private ContainerItem containerItem;

        public void SetIcon(Sprite sprite)
        {
            Image.sprite = sprite;
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            DragDropManager<T>.Instance.BeginDragItem(this);
            image.color = draggingColor;
            offset = (transform.position - Input.mousePosition);
            CanvasGroup.blocksRaycasts = false;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            DragDropManager<T>.Instance.EndDragItem();
            image.color = defaultColor;
            CanvasGroup.blocksRaycasts = true;
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition + offset;
        }
    }
}
