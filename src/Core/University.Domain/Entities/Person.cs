namespace University.Domain.Entities;

public abstract class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Code { get; set; }
    public DateTime BirthDate { get; set; }
    public string NationalCode { get; set; }
    public string FatherName { get; set; }
    public Gender Gender { get; set; }
    public ContactInfo ContactInfo { get; set; }
}

public class ContactInfo
{
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}

public enum Gender : byte
{
    Male = 1 ,
    Female = 2
}

public enum PersonType : byte
{
    Student = 1 ,
    Teacher = 2 
}