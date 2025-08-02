using University.Application.Semesters.Contracts.Dtos;

namespace University.Application.Semesters.Contracts;

public interface ISemesterService
{
    GetSemesterDto GetById(int id);
    List<GetSemesterDto> GetAll();
    int Add(AddSemesterDto dto);
    void Update(int id, UpdateSemesterDto dto);
    void Delete(int id);
}
