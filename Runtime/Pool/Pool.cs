using System;
using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Collections
{
    public class Pool<TObject>
        where TObject : IPoolObject, new()
    {
        #region Fields

        protected readonly List<TObject> PoolCollection;

        #endregion Fields

        #region Constructors

        public Pool(int preAllocate = 0)
            : this()
        {
            Allocate(preAllocate);
        }

        public Pool()
        {
            PoolCollection = new List<TObject>();
        }

        #endregion Constructors

        #region Methods

        public TObject Activate(IPoolObjectProperties<TObject> objectProperties)
        {
            if (!TryGetFirstUnused(out TObject poolObject))
            {
                poolObject = CreateNewPoolObject();
            }

            objectProperties.ApplyTo(poolObject);
            poolObject.Activate();

            return poolObject;
        }

        public void Activate(int number, IPoolObjectProperties<TObject> objectProperties)
        {
            for (int i = 0; i < number; i++)
            {
                Activate(objectProperties);
            }
        }

        public void Allocate(int number)
        {
            for (int i = 0; i < number; ++i)
            {
                CreateNewPoolObject();
            }
        }

        public void ApplyPropertiesToAll(IPoolObjectProperties<TObject> properties)
        {
            foreach (TObject obj in PoolCollection)
            {
                properties.ApplyTo(obj);
            }
        }

        public void ApplyProperties(Predicate<TObject> objectFilter, IPoolObjectProperties<TObject> properties)
        {
            foreach (TObject obj in PoolCollection.FindAll(objectFilter))
            {
                properties.ApplyTo(obj);
            }
        }

        public void DeactivateAll()
        {
            foreach (TObject poolObject in PoolCollection)
            {
                poolObject.Deactivate();
            }
        }

        public void DestroyAll()
        {
            foreach (TObject poolObject in PoolCollection)
            {
                poolObject.Destroy();
            }

            PostDestroyAll();
        }

        public void Update(float deltaTime)
        {
            foreach (TObject poolObject in PoolCollection)
            {
                if (poolObject.IsActive())
                {
                    poolObject.Update(deltaTime);
                }
            }
        }

        protected TObject CreateNewPoolObject()
        {
            TObject poolObject = Pool_CreatePoolObject();

            poolObject.Initialize(Pool_GetNewObjectName());
            poolObject.Deactivate();

            PoolCollection.Add(poolObject);

            return poolObject;
        }

        protected virtual TObject Pool_CreatePoolObject()
        {
            return new TObject();
        }

        protected virtual string Pool_GetNewObjectName()
        {
            return PoolCollection.Count.ToString();
        }

        protected virtual void Pool_PostDestroyAll()
        { }

        protected void PostDestroyAll()
        {
            Pool_PostDestroyAll();
        }

        private bool TryGetFirstUnused(out TObject obj)
        {
            if (PoolCollection.Count > 0)
            {
                foreach (TObject poolObject in PoolCollection)
                {
                    if (!poolObject.IsActive())
                    {
                        obj = poolObject;
                        return true;
                    }
                }
            }

            obj = default(TObject);
            return false;
        }

        #endregion Methods
    }
}
