using FluentMigrator;
using FluentMigrator.Builders.Create;

namespace University.Migrations;

[Migration(202507290959)]
public class _202507290959_Add_Initial : Migration
{
    public override void Up()
    {
        Create.Table("Students")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Family").AsString(100).NotNullable()
            .WithColumn("BirthDate").AsDate().NotNullable()
            .WithColumn("StudentCode").AsInt32().NotNullable().Unique()
            .WithColumn("IdentityCode").AsString(10).NotNullable().Unique()
            .WithColumn("PhoneNumber").AsString(20).NotNullable().Unique()
            .WithColumn("Address").AsString(200);

        Create.Table("Teachers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Family").AsString(50).NotNullable();

        Create.Table("Courses")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).NotNullable().Unique()
            .WithColumn("Unit").AsByte().NotNullable();

        Create.Table("Semesters")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("StartDate").AsDateTime().NotNullable()
            .WithColumn("EndDate").AsDateTime().NotNullable()
            .WithColumn("Active").AsBoolean().NotNullable();

        Create.Table("Classes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CourseId").AsInt32().NotNullable()
            .WithColumn("TeacherId").AsInt32().NotNullable()
            .WithColumn("SemesterId").AsInt32().NotNullable()
            .WithColumn("Capacity").AsByte().NotNullable();

        Create.Table("ClassSchedules")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("ClassId").AsInt32().NotNullable()
            .WithColumn("DayOfWeek").AsByte().NotNullable()
            .WithColumn("Start").AsTime().NotNullable()
            .WithColumn("End").AsTime().NotNullable()
            .WithColumn("Room").AsString(20).NotNullable();

        Create.Table("ClassEnrollments")
            .WithColumn("ClassId").AsInt32().NotNullable()
            .WithColumn("StudentId").AsInt32().NotNullable()
            .WithColumn("RegisterDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

        Create.PrimaryKey("PK_ClassEnrollments")
            .OnTable("ClassEnrollments")
            .Columns("StudentId", "ClassId");

        Create.ForeignKey("Fk_Class_Course")
            .FromTable("Classes")
            .ForeignColumn("CourseId")
            .ToTable("Courses")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Class_Teacher")
            .FromTable("Classes")
            .ForeignColumn("TeacherId")
            .ToTable("Teachers")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Class_Semester")
            .FromTable("Classes")
            .ForeignColumn("SemesterId")
            .ToTable("Semesters")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_ClassSchedule_Class")
            .FromTable("ClassSchedules")
            .ForeignColumn("ClassId")
            .ToTable("Classes")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_ClassEnrollment_Class")
            .FromTable("ClassEnrollments")
            .ForeignColumn("ClassId")
            .ToTable("Classes")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_ClassEnrollment_Student")
            .FromTable("ClassEnrollments")
            .ForeignColumn("StudentId")
            .ToTable("Students")
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
