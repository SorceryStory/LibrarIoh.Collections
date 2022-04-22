namespace SorceressSpell.LibrarIoh.Collections
{
    public interface IPoolObjectProperties<in TPoolObject>
    {
        #region Methods

        void ApplyTo(TPoolObject poolObject);

        #endregion Methods
    }
}
