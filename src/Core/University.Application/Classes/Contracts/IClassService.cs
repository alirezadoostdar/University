using University.Application.Classes.Contracts.Dtos;

namespace University.Application.Classes.Contracts;

public interface IClassService
{
    int Add(AddClassDto dto);
    void Update(int id, UpdateClassDto dto);
    void Delete(int id);
    List<GetClassDto> GetAll();
    GetClassDto GetById(int id);
}
