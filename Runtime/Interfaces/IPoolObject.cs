namespace SorceressSpell.LibrarIoh.Collections
{
    public interface IPoolObject
    {
        #region Methods

        void Activate();

        void Deactivate();

        void Destroy();

        void Initialize(string name);

        bool IsActive();

        void Update(float deltaTime);

        #endregion Methods
    }
}
