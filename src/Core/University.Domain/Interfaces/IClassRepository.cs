using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface IClassRepository
{
    List<Class> GetAll();
    Class? GetById(int id);
    void Add(Class entity);
    void Update(Class entity);
    void Delete(Class entity);
}
