namespace SorceressSpell.LibrarIoh.Collections
{
    public interface IPoolObject<in TProperties>
    {
        #region Methods

        void Activate(TProperties properties);

        void Deactivate();

        void Destroy();

        void Initialize(string name);

        bool IsActive();

        void LateUpdate(float deltaTime);

        void Update(float deltaTime);

        #endregion Methods
    }
}
