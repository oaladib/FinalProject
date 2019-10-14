using System;
using System.Linq;

namespace ProjectDB1
{
    class Program
    {

        static void testAddingDepartment(string deptname)
        {
            //Console.WriteLine("Hello World!");

            using (var context = new DBClasses.LogiTestDbContext())
            {
                var dept = new DBClasses.Department();
                dept.DeptName = deptname;
                context.Add(dept);
                context.SaveChanges();
            }

            Console.WriteLine("done department");
        }

        static void testAddingStudent(string afirstname, string afathername, string asurname, string firstname, string fathername, string surname,
            string email, string mobile, int departmentid, string regyear, string unnum, int userid, int groupid)
        {
            //Console.WriteLine("Hello World!");

            using (var context = new DBClasses.LogiTestDbContext())
            {
                var std = new DBClasses.Student();
                std.AFirstName = afirstname;
                std.FirstName = firstname;
                std.AFatherName = afathername;
                std.FatherName = fathername;
                std.ASurName = asurname;
                std.SurName = surname;
                std.Email = email;
                std.Mobile = mobile;
                std.DepartmentId = departmentid;
                std.RegYear = regyear;
                std.UnNum = unnum;
                std.UserId = userid;
                std.GroupId = groupid;

                context.Add(std);
                context.SaveChanges();

            }

            Console.WriteLine("done student");
        }

        static void testAddingTeacher(string afirstname, string firstname, string afathername,
            string fathername, string asurname, string surname,
            string email, string mobile, int userid)
        {
            //Console.WriteLine("Hello World!");

            using (var context = new DBClasses.LogiTestDbContext())
            {
                var std = new DBClasses.Teacher();
                std.AFirstName = afirstname;
                std.FirstName = firstname;
                std.AFatherName = afathername;
                std.FatherName = fathername;
                std.ASurName = asurname;
                std.SurName = surname;
                std.Email = email;
                std.Mobile = mobile;
                std.UserId = userid;
                context.Add(std);
                context.SaveChanges();

            }

            Console.WriteLine("done teacher");
        }

        static void testAddingUser(string username, string password, string hint, int type)
        {
            //Console.WriteLine("Hello World!");

            using (var context = new DBClasses.LogiTestDbContext())
            {
                var us = new DBClasses.User();
                us.UserName = username;
                us.Password = password;
                us.Hint = hint;
                us.Type = type;

                context.Add(us);
                context.SaveChanges();
            }

            Console.WriteLine("done user");
        }

        static void testAddingGroup(string groupsemester, int maxnum, int teacherid, string day, DateTime time)
        {
            //Console.WriteLine("Hello World!");

            using (var context = new DBClasses.LogiTestDbContext())
            {
                var gr = new DBClasses.Group();
                gr.GroupSemester = groupsemester;
                gr.MaxNum = maxnum;
                gr.TeacherId = teacherid;
                gr.Day = day;
                gr.Time = time;

                context.Add(gr);
                context.SaveChanges();
            }

            Console.WriteLine("done group");
        }

        static void testAddingAssignment(double mark, double decmark, int groupid, DateTime publishdate, DateTime deadline, DateTime tdeadline,
            string description, string template)//, string solution, string asstest, string note)
        {
            //Console.WriteLine("Hello World!");

            using (var context = new DBClasses.LogiTestDbContext())
            {
                var assi = new DBClasses.Assignment();
                assi.Mark = mark;
                assi.DecMark = decmark;
                assi.GroupId = groupid;
                assi.PublishDate = publishdate;
                assi.Deadline = deadline;
                assi.TDeadline = tdeadline;
                assi.Description = description;
                assi.Template = template;
                //assi.Solution = solution;
                //assi.AssTest = asstest;
                //assi.Note = note;

                context.Add(assi);
                context.SaveChanges();
            }

            Console.WriteLine("done assignment");
        }
        static void testAddingSub(int studentid, int assid, DateTime date, string solution, int tryid)//,double mark)
        {
            //Console.WriteLine("Hello World!");

            using (var context = new DBClasses.LogiTestDbContext())
            {
                var sub = new DBClasses.Submission();
                sub.StudentId = studentid;
                sub.AssId = assid;
                sub.Date = date;
                sub.Solution = solution;
                //sub.Mark = mark;
                sub.TryId = tryid;
                //sub.SubmissionId = submissionid;

                context.Add(sub);
                context.SaveChanges();
            }

            Console.WriteLine("done submission");
        }

        //static void testUpdateStudent()
        //{
        //    Console.WriteLine("Be!");

        //    using (var db = new DBClasses.LogiTestDbContext())
        //    {

        //        var query=
        //            (from p in db.Students
        //            where p.st

        //        var st=(from s in db.Students where(s =>s.))

        //        var blogs = db.Students
        //        .Where(b => b.Url.Contains("dotnet"))
        //        .ToList();
        //        var dept = new DBClasses.Department();
        //        dept.DeptName = "D Name";
        //        dept.DepartmentId = 44444;

        //        context.Add(dept);
        //        context.SaveChanges();

        //    }


        //    Console.WriteLine("End of application");
        //}




        //static void testReadDeparment()
        //{
        //    Console.WriteLine("Hello World!");

        //    using (var db = new DBClasses.LogiTestDbContext())
        //    {
        //        db.Departments.(4444)
        //        var q = (from d in db.Departments
        //                 where(d => d.name == )
        //                 select d
        //                 ).ToList();
        //        var dept = new DBClasses.Department();
        //        dept.DeptName = "D Name";
        //        dept.DepartmentId = 44444;

        //        context.Add(dept);
        //        context.SaveChanges();

        //    }


        //    Console.WriteLine("End of application");
        //}

        static void testquery()
        {
            using (var context = new DBClasses.LogiTestDbContext())
            {
                var group = context.Groups
                     .Single(b => b.GroupId == 1);

                var blog = context.Students
                     .Single(b => b.GroupId == group.GroupId);
                Console.WriteLine(blog.PersonId);
                Console.WriteLine(blog.FirstName);
                Console.WriteLine(blog.FatherName);
                Console.WriteLine(blog.SurName);
                Console.WriteLine(group.Day);
                Console.WriteLine(group.Time);

                var postCount = context.Entry(blog)
                .Collection(b => b.Submissions)
                .Query()
                .Count();
                Console.WriteLine(postCount.ToString());


            }
        }
        static void testupdate()
        {
            using (var context = new DBClasses.LogiTestDbContext())
            {
                var blog1 = context.Students.SingleOrDefault(b => b.PersonId == 2);
                blog1.UnNum = "201510160";
                context.SaveChanges();
                Console.WriteLine("Done");

                var blog = context.Students
                     .Single(b => b.UnNum == "201510160");
                Console.WriteLine(blog.PersonId);
                Console.WriteLine(blog.FirstName);
                Console.WriteLine(blog.FatherName);
                Console.WriteLine(blog.SurName);
            }
                
        }

        static void testdelete()
        {
            using (var context = new DBClasses.LogiTestDbContext())
            {
                var dept = context.Departments
                     .Single(b => b.DeptName == "Micaa");
                context.Remove(dept);
                context.SaveChanges();
                Console.WriteLine("Done !!! Depatment deleted");
            }
            
        }
        static void Main(string[] args)
        {
            //testAddingDepartment("Information Technology");
            //testAddingUser("osama.aladib","osama","osama",3);
            //testAddingUser("suhel.hammoud", "suhel", "suhel", 2);
            //testAddingDepartment("Micaa");
            //testAddingUser();
            //testAddingTeacher("سهيل","Suhel","محمد","Mohamad","حمود","Hammoud","suhel.hammoud@gmail.com","0963216549",2);
            //testAddingGroup("20192",20,1,"Sunday",System.DateTime.Now);
            //testAddingStudent("اسامه","محمد","الاديب","Osama","Mohamad","Aladib","osama.xfvisri.sdfsd","0994262725",1,"20141","201410160",1,1);
            //testAddingStudent("اسامه", "محمد", "الاديب", "Osama", "Mohamad", "Aladib", "osama.xfvksri.sdfsd", "0994262525", 44467, "20141", "201510160", 5, 2);
            //testAddingAssignment(2.5,0.4,1,System.DateTime.Now, System.DateTime.Now, System.DateTime.Now,"Hello world","Template");
            /*
             migrationBuilder.CreateIndex(
               name: "IX_Department_dept_name",
               schema: "Assignment",
               table: "Department",
               column: "dept_name",
               unique: true);
             */

            //try
            //{
            //testAddingSub(2, 1, System.DateTime.Now, "Hi", 1);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}

            //testquery();

            //testupdate();

            //testdelete();



        }
    }
}
