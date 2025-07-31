using University.Domain.Entities;
using University.Domain.Interfaces;

namespace Uninversity.Infarstructure.Repositories;

internal class EfStudentRepository : IStudentRepository
{
    private readonly IStudentRepository _studentRepository;

    public EfStudentRepository(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public int Add(Student student)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAll()
    {
        throw new NotImplementedException();
    }

    public Student GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Student student)
    {
        throw new NotImplementedException();
    }
}
