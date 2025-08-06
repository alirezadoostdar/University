using FluentMigrator;
using FluentMigrator.Builders.Create;
using System.Reflection;

namespace University.Migrations;

[Migration(202507290959)]
public class _202507290959_Add_Initial : Migration
{
    public override void Up()
    {
        Create.Table("Persons")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Family").AsString(100).NotNullable()
            .WithColumn("Code").AsInt32().NotNullable().Unique()
            .WithColumn("BirthDate").AsDate().NotNullable()
            .WithColumn("NationalCode").AsString(10).NotNullable().Unique()
            .WithColumn("FatherName").AsString(100).NotNullable()
            .WithColumn("Gender").AsByte().NotNullable()
            .WithColumn("Type").AsByte().NotNullable()
            .WithColumn("PhoneNumber").AsString(20).NotNullable().Unique()
            .WithColumn("Address").AsString(200);

        Create.Table("Courses")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).NotNullable().Unique()
            .WithColumn("Unit").AsByte().NotNullable();

        Create.Table("Terms")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("StartDate").AsDateTime().NotNullable()
            .WithColumn("EndDate").AsDateTime().NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable();

        Create.Table("Classes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CourseId").AsInt32().NotNullable()
            .WithColumn("TeacherId").AsInt32().NotNullable()
            .WithColumn("TermId").AsInt32().NotNullable()
            .WithColumn("Capacity").AsByte().NotNullable();

        Create.Table("Sections")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("ClassId").AsInt32().NotNullable()
            .WithColumn("DayOfWeek").AsByte().NotNullable()
            .WithColumn("Start").AsTime().NotNullable()
            .WithColumn("End").AsTime().NotNullable()
            .WithColumn("Room").AsString(20).NotNullable();

        Create.Table("StudentsClasses")
            .WithColumn("ClassId").AsInt32().NotNullable()
            .WithColumn("StudentId").AsInt32().NotNullable()
            .WithColumn("RegisterDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

        Create.PrimaryKey("PK_StudentClass")
            .OnTable("StudentsClasses")
            .Columns("StudentId", "ClassId");

        Create.ForeignKey("Fk_Class_Course")
            .FromTable("Classes")
            .ForeignColumn("CourseId")
            .ToTable("Courses")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Class_Person")
            .FromTable("Classes")
            .ForeignColumn("TeacherId")
            .ToTable("Persons")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Class_Term")
            .FromTable("Classes")
            .ForeignColumn("TermId")
            .ToTable("Terms")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Section_Class")
            .FromTable("Sections")
            .ForeignColumn("ClassId")
            .ToTable("Classes")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_StudentsClasses_Class")
            .FromTable("StudentsClasses")
            .ForeignColumn("ClassId")
            .ToTable("Classes")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_StudentsClasses_Person")
            .FromTable("StudentsClasses")
            .ForeignColumn("StudentId")
            .ToTable("Persons")
            .PrimaryColumn("Id");

    }
    public override void Down()
    {
        Delete.ForeignKey("Fk_ClassEnrollment_Student");
        Delete.ForeignKey("Fk_ClassEnrollment_Class");
        Delete.ForeignKey("Fk_ClassSchedule_Class");
        Delete.ForeignKey("Fk_Class_Semester");
        Delete.ForeignKey("Fk_Class_Teacher");
        Delete.ForeignKey("Fk_Class_Course");
        Delete.Table("ClassEnrollments");
        Delete.Table("ClassSchedules");
        Delete.Table("Classes");
        Delete.Table("Semesters");
        Delete.Table("Courses");
        Delete.Table("Teachers");
        Delete.Table("Students");
    }
}
