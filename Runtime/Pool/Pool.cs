using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Collections
{
    public class Pool<TPoolObject, TPoolObjectProperties>
        where TPoolObject : IPoolObject<TPoolObjectProperties>, new()
        where TPoolObjectProperties : IPoolObjectProperties<TPoolObject>
    {
        #region Fields

        protected readonly List<TPoolObject> PoolCollection;

        #endregion Fields

        #region Constructors

        public Pool(int preAllocate)
            : this()
        {
            Allocate(preAllocate);
        }

        protected Pool()
        {
            PoolCollection = new List<TPoolObject>();
        }

        #endregion Constructors

        #region Methods

        public TPoolObject Activate(TPoolObjectProperties objectProperties)
        {
            TPoolObject poolObject = GetFirstUnused();

            if (poolObject == null)
            {
                poolObject = CreateNewPoolObject();
            }

            poolObject.Activate(objectProperties);

            return poolObject;
        }

        public void Activate(int number, TPoolObjectProperties objectProperties)
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

        public void DeActivateAll()
        {
            foreach (TPoolObject poolObject in PoolCollection)
            {
                poolObject.DeActivate();
            }
        }

        public virtual void DestroyAll()
        {
            foreach (TPoolObject poolObject in PoolCollection)
            {
                poolObject.Destroy();
            }

            PostDestroyAll();
        }

        public virtual void Update(float deltaTime)
        {
            foreach (TPoolObject poolObject in PoolCollection)
            {
                poolObject.Update(deltaTime);
            }
        }

        protected TPoolObject CreateNewPoolObject()
        {
            TPoolObject poolObject = CreatePoolObject();

            poolObject.Initialize(GetNewObjectName());
            poolObject.DeActivate();

            PoolCollection.Add(poolObject);

            return poolObject;
        }

        protected virtual TPoolObject CreatePoolObject()
        {
            return new TPoolObject();
        }

        protected virtual string GetNewObjectName()
        {
            return PoolCollection.Count.ToString();
        }

        protected virtual void PostDestroyAll()
        {
        }

        private TPoolObject GetFirstUnused()
        {
            if (PoolCollection.Count > 0)
            {
                foreach (TPoolObject poolObject in PoolCollection)
                {
                    if (!poolObject.IsActive())
                    {
                        return poolObject;
                    }
                }
            }

            return default(TPoolObject);
        }

        #endregion Methods
    }
}
