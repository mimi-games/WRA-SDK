using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WRA.CharacterSystems.InventorySystem.Slots;

namespace WRA.CharacterSystems.InventorySystem.Managment
{
    public class Inventory : Container<InventorySlot, Item>
    {
        [SerializeField] private int xSize;
        [SerializeField] private int ySize;

        private List<InventorySlot> slots = new List<InventorySlot>();
        public Vector2Int containerSize => new Vector2Int(xSize, ySize);
    
        public override bool TryAddItem(Item containerItem)
        {
            var slot = FindEmptyPlace(containerItem);

            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].TryStack(containerItem as Item))
                {
                    OnContainerChanged.Invoke();
                    return true;
                }
            }

            if (slot == -Vector2Int.one)
                return false;

            var item = Instantiate(containerItem);
            slots.Add(new InventorySlot(item as Item, slot));

            OnContainerChanged.Invoke();
            return true;
        }
    
        public override bool TryAddItemAtSlot(Item containerItem, int slotId)
        {
            var position = ParseToVector2(slotId);
            if (CheckSlot(containerItem, position) || IsOutsideOfInventory(containerItem, position))
            {
                return false;
            }
        
            var item = Instantiate(containerItem);
            slots.Add(new InventorySlot(item as Item, position));

            OnContainerChanged.Invoke();
            return true;
        }

        public override bool TryMoveItem(Item containerItem, int slotId)
        {
            if (!IsPossibleToMoveItem(containerItem, slotId))
            {
                return false;
            }
            var position = ParseToVector2(slotId);
            slots.Find(ctg => ctg.Item == containerItem).Position = position;
            OnContainerChanged.Invoke();
            return true;
        }

        public override bool IsPossibleToAddItemAtSlot(Item containerItem, int slotId)
        {
            var position = ParseToVector2(slotId);
            if (CheckSlot(containerItem, position) || IsOutsideOfInventory(containerItem, position))
            {
                return false;
            }

            return true;
        }

        public override bool IsPossibleToMoveItem(Item containerItem, int slotId)
        {
            var position = ParseToVector2(slotId);
            if (CheckSlot(containerItem, position) || IsOutsideOfInventory(containerItem, position))
            {
                return false;
            }

            return true;
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerItem"></param>
        /// <returns></returns>

        public override bool TryRemoveItem(Item containerItem)
        {
            bool result = slots.Remove(slots.Find(ctg => ctg.Item == containerItem));

            OnContainerChanged.Invoke();
            return result;
        }

        public override Item[] GetItems()
        {
            var items = this.slots.Select(ctg => ctg.Item);
        

            return items.ToArray();
        }

        // public override InventorySlot[] GetSlots<Item, InventorySlot>()
        // {
        //     return slots.ToArray();
        // }

        public override InventorySlot[] GetSlots()
        {
            return slots.ToArray();
        }

        protected override bool CheckSlot(Item item, int slotId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position"></param>
        /// <returns>If position is outside inventory return true, else return false</returns>

        protected virtual bool IsOutsideOfInventory(Item item, Vector2Int position)
        {
            OutsideInfo = Vector2Int.zero;
            var outSideTemp = new Vector2Int((position.x + item.Size.x) - containerSize.x ,
                (position.y + item.Size.y) - containerSize.y);
            if (position.x < 0 || position.y < 0)
                return true;
            if (outSideTemp.x > 0 || outSideTemp.y > 0)
            {
                OutsideInfo = new Vector2Int(
                    outSideTemp.y > 0 ? outSideTemp.y : 0, outSideTemp.x > 0 ? outSideTemp.x : 0);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finding empty place
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Return position if found free slot, return new Vector2Int(-1-1) if not found.</returns>

        protected virtual Vector2Int FindEmptyPlace(Item item)
        {
            for (int i = 0; i < containerSize.y; i++)
            {
                for (int j = 0; j < containerSize.x; j++)
                {
                    if (!IsOutsideOfInventory(item, new Vector2Int(j, i)) && !CheckSlot(item, new Vector2Int(j, i)))
                    {
                        return new Vector2Int(j, i);
                    }
                }
            }

            return -Vector2Int.one;
        }

        /// <summary>
        /// Checking slots by item size and position
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position"></param>
        /// <returns>Return true if slot is busy, false if empty</returns>

        protected bool CheckSlot(Item item, Vector2Int position)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].IsInside(position, item))
                    return true;
            }

            return false;
        }

        protected Vector2Int ParseToVector2(int slotId)
        {
            return new Vector2Int(slotId % xSize, slotId / xSize);
        }
    }
}
