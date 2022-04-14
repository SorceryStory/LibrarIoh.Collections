namespace SorceressSpell.LibrarIoh.Collections
{
    public interface IPoolObject<TProperties>
    {
        #region Methods

        void Activate(TProperties properties);

        void DeActivate();

        void Destroy();

        void Initialize(string name);

        bool IsActive();

        void LateUpdate(float deltaTime);

        void Update(float deltaTime);

        #endregion Methods
    }
}
