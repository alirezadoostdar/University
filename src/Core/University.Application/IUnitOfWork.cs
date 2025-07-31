namespace University.Application;

public interface IUnitOfWork
{
    void Save();
    void Commit();
    void Begin();
    void Rollback();
}
