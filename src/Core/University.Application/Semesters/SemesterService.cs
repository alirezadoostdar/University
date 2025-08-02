using University.Application.Semesters.Contracts;
using University.Application.Semesters.Contracts.Dtos;
using University.Application.Semesters.Contracts.Exceptions;
using University.Domain.Entities;
using University.Domain.Interfaces;

namespace University.Application.Semesters;

public class SemesterService : ISemesterService
{
    private readonly ISemesterRepository _repository;
    private readonly IUnitOfWork _uow;

    public SemesterService(ISemesterRepository repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }

    public int Add(AddSemesterDto dto)
    {
        var semester = new Semester
        {
            Title = dto.Title,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Active = true
        };
        _repository.Add(semester);
        _uow.Save();
        return semester.Id;
    }

    public void Delete(int id)
    {
        var semester = _repository.GetById(id);
        if(semester is null)
            throw new SemesterNotFoundException();

        _repository.Delete(semester);
        _uow.Save();
    }

    public List<GetSemesterDto> GetAll()
    {
        var list = _repository.GetAll().Select(x => new GetSemesterDto(
            x.Id,
            x.Title,
            x.StartDate,
            x.EndDate,
            x.Active)).ToList();

        return list;
    }

    public GetSemesterDto GetById(int id)
    {
        var semester = _repository.GetById(id);
        if (semester is null)
            throw new SemesterNotFoundException();

        var dto = new GetSemesterDto(
            semester.Id,
            semester.Title,
            semester.StartDate,
            semester.EndDate,
            semester.Active);

        return dto;
    }

    public void Update(int id, UpdateSemesterDto dto)
    {
        var semester = _repository.GetById(id);
        if( semester is null)
            throw new SemesterNotFoundException();

        semester.Title = dto.Title;
        semester.StartDate = dto.StartDate;
        semester.EndDate = dto.EndDate;
        semester.Active = dto.Active;
        _repository.Update(semester);
        _uow.Save();
    }
}
