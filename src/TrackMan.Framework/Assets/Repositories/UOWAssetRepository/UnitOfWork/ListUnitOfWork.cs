using System;
using System.Collections.Generic;
using System.Linq;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.Assets.Repositories.UOWAssetRepository.UnitOfWork
{
    public class ListUnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private readonly List<UnitOfWorkItem> items = new List<UnitOfWorkItem>();

        public int InsertCount
        {
            get { return GetItemCountForAction(UnitOfWorkAction.Add); }
        }

        public int UpdateCount
        {
            get { return GetItemCountForAction(UnitOfWorkAction.Update); }
        }

        public int DeleteCount
        {
            get { return GetItemCountForAction(UnitOfWorkAction.Delete); }
        }

        public TEntity Get(TEntity entity)
        {
            var unitOfWorkItem = items.FirstOrDefault(item => item.Entity.Equals(entity));
            return unitOfWorkItem == null ? null : unitOfWorkItem.Entity;
        }

        public bool Contains(TEntity entity)
        {
            return Get(entity) != null;
        }

        public void AddInsert(TEntity entity, IEntityItem<TEntity> entityItem)
        {
            AssertEntityAndItemAreValid(entity, entityItem);

            items.Add(new UnitOfWorkItem(entity, entityItem, UnitOfWorkAction.Add));
        }

        public void AddUpdate(TEntity entity, IEntityItem<TEntity> entityItem)
        {
            AssertEntityAndItemAreValid(entity, entityItem);

            items.Add(new UnitOfWorkItem(entity, entityItem, UnitOfWorkAction.Update));
        }

        public void AddDelete(TEntity entity)
        {
            var unitOfWorkItem = items.FirstOrDefault(item => item.Entity.Equals(entity));
            if (unitOfWorkItem == null)
            {
                throw new InvalidOperationException(
                    string.Format("The entity ('{0}') you are attempting to delete is not in the current unit of work.", entity));
            }
            unitOfWorkItem.Action = UnitOfWorkAction.Delete;
        }

        public void Update()
        {
            Array.ForEach(items.ToArray(), item => item.Update());
            RemoveItemsWithActionNone();
        }

        public void Clear()
        {
            items.Clear();
        }

        #region Helper methods

        private void AssertEntityAndItemAreValid(TEntity entity, IEntityItem<TEntity> entityItem)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            if (entityItem == null)
                throw new ArgumentNullException("entityItem");
            if (Contains(entity))
            {
                throw new DuplicateWorkItemAddedException(
                    string.Format("The entity '{0}' has already been added to the current unit of work.", entity));
            }
        }

        private int GetItemCountForAction(UnitOfWorkAction action)
        {
            return items.Sum(item => item.Action == action ? 1 : 0);
        }

        private void RemoveItemsWithActionNone()
        {
            for(var i = items.Count - 1; i >= 0; i--)
            {
                if(items[i].Action == UnitOfWorkAction.None)
                    items.RemoveAt(i);
            }
        }

        #endregion

        #region UnitOfWorkItem Class

        private class UnitOfWorkItem
        {
            private readonly IEntityItem<TEntity> entityItem;
            public UnitOfWorkItem(TEntity entity, IEntityItem<TEntity> entityItem, UnitOfWorkAction action)
            {
                this.entityItem = entityItem;
                Entity = entity;
                Action = action;
            }

            public TEntity Entity { get; private set; }
            public UnitOfWorkAction Action { get; set; }

            public void Update()
            {
                switch(Action)
                {
                    case UnitOfWorkAction.Add:
                    case UnitOfWorkAction.Update:
                        entityItem.Update(Entity);
                        Action = UnitOfWorkAction.Update;
                        break;
                    case UnitOfWorkAction.Delete:
                        entityItem.Delete();
                        Action = UnitOfWorkAction.None;
                        break;
                }
            }
        }

        #endregion

        #region UnitOfWorkAction Enum

        private enum UnitOfWorkAction
        {
            Add,
            Update,
            Delete,
            None
        }

        #endregion
    }
}