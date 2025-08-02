using University.Application.Teachers.Contracts.Dtos;

namespace University.Application.Teachers.Contracts;

public interface ITeacherService
{
    GetTeacherDto GetById(int id);
    int Add(AddTeacherDto dto);
    void Update(int id, UpdateTeacherDto dto);
    void Delete(int id);
    List<GetTeacherDto> GetAll();
}
