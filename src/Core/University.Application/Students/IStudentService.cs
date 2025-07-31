using University.Application.Students.Contracts.Dtos;

namespace University.Application.Students;

public interface IStudentService
{
    GetStudentDto GetById(int id);
    int Add(AddStudentDto dto);
    void Update(UpdateStudentDto dto);
    void Delete(int id);
    List<GetStudentDto> GetAll();
}
