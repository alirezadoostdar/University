using University.Application.Courses.Contracts.Dtos;

namespace University.Application.Courses.Contracts;

public interface ICourseService
{
    List<GetCourseDto> GetAll();
    GetCourseDto GetById(int id);
    int Add(AddCourseDto dto);
    void Update(int id, UpdateCourseDto dto);
    void Delete(int id);
}
