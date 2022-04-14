namespace SorceressSpell.LibrarIoh.Collections
{
    public interface IPoolObjectProperties<TPoolObject>
    {
        #region Methods

        void ApplyTo(TPoolObject poolObject);

        #endregion Methods
    }
}
