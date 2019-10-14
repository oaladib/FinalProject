using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDB1.Migrations
{
    public partial class _1012e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Assignment");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "Assignment",
                columns: table => new
                {
                    dept_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dept_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.dept_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Assignment",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    hint = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                schema: "Assignment",
                columns: table => new
                {
                    submission_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    solution = table.Column<string>(nullable: false),
                    mark = table.Column<double>(nullable: false),
                    try_id = table.Column<int>(nullable: false),
                    student_id = table.Column<int>(nullable: false),
                    assignment_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.submission_id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Assignment",
                columns: table => new
                {
                    person_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: false),
                    father_name = table.Column<string>(nullable: false),
                    sur_name = table.Column<string>(nullable: false),
                    a_first_name = table.Column<string>(nullable: false),
                    a_father_name = table.Column<string>(nullable: false),
                    a_sur_name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    mobile = table.Column<string>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    registration_year = table.Column<string>(nullable: true),
                    university_number = table.Column<string>(nullable: true),
                    dept_id = table.Column<int>(nullable: true),
                    group_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.person_id);
                    table.ForeignKey(
                        name: "ForeignKey_Person_User",
                        column: x => x.user_id,
                        principalSchema: "Assignment",
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_Student_Department",
                        column: x => x.dept_id,
                        principalSchema: "Assignment",
                        principalTable: "Department",
                        principalColumn: "dept_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Assignment",
                columns: table => new
                {
                    group_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    max_number = table.Column<int>(nullable: false),
                    group_semester = table.Column<string>(nullable: false),
                    day = table.Column<string>(nullable: false),
                    time = table.Column<DateTime>(nullable: false),
                    teacher_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.group_id);
                    table.ForeignKey(
                        name: "ForeignKey_Group_Teacher",
                        column: x => x.teacher_id,
                        principalSchema: "Assignment",
                        principalTable: "Person",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                schema: "Assignment",
                columns: table => new
                {
                    assignment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mark = table.Column<double>(nullable: false),
                    dec_mark = table.Column<double>(nullable: false),
                    publish_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    deadline = table.Column<DateTime>(nullable: false),
                    t_deadline = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    template = table.Column<string>(nullable: false),
                    solution = table.Column<string>(nullable: true),
                    assignment_test = table.Column<string>(nullable: true),
                    group_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.assignment_id);
                    table.ForeignKey(
                        name: "ForeignKey_Assignment_Group",
                        column: x => x.group_id,
                        principalSchema: "Assignment",
                        principalTable: "Group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_group_id",
                schema: "Assignment",
                table: "Assignment",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_dept_name",
                schema: "Assignment",
                table: "Department",
                column: "dept_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_teacher_id",
                schema: "Assignment",
                table: "Group",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Person_email",
                schema: "Assignment",
                table: "Person",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_mobile",
                schema: "Assignment",
                table: "Person",
                column: "mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_user_id",
                schema: "Assignment",
                table: "Person",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_dept_id",
                schema: "Assignment",
                table: "Person",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Person_group_id",
                schema: "Assignment",
                table: "Person",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Person_university_number",
                schema: "Assignment",
                table: "Person",
                column: "university_number",
                unique: true,
                filter: "[university_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_assignment_id",
                schema: "Assignment",
                table: "Submission",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_student_id",
                schema: "Assignment",
                table: "Submission",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_user_name",
                schema: "Assignment",
                table: "User",
                column: "user_name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Submission_Student",
                schema: "Assignment",
                table: "Submission",
                column: "student_id",
                principalSchema: "Assignment",
                principalTable: "Person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Submission_Assignment",
                schema: "Assignment",
                table: "Submission",
                column: "assignment_id",
                principalSchema: "Assignment",
                principalTable: "Assignment",
                principalColumn: "assignment_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Student_Group",
                schema: "Assignment",
                table: "Person",
                column: "group_id",
                principalSchema: "Assignment",
                principalTable: "Group",
                principalColumn: "group_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Student_Group",
                schema: "Assignment",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Submission",
                schema: "Assignment");

            migrationBuilder.DropTable(
                name: "Assignment",
                schema: "Assignment");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Assignment");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Assignment");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Assignment");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "Assignment");
        }
    }
}
