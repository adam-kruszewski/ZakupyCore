namespace Kruchy.Model.DataTypes.Database
{
    public interface IUnitOfWork
    {
        void Start();

        void Finish();

        void Rollback();
    }
}