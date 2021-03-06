﻿using Microsoft.EntityFrameworkCore;
using System;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Data.Repository
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<CustomerModelDB> Customer { get; set; }
        public DbSet<UserDetailsDB> UserDetails { get; set; }
        public DbSet<UserMasterDB> User { get; set; }
        public DbSet<UserLoginDetailsDB> UserLoginDetails { get; set; }
        public DbSet<CustomerCourseHierarchyDB> CustomerCourseHierarchy { get; set; }
        public DbSet<CustomerBranchesDB> CustomerBranch { get; set; }
        public DbSet<UserRoleDB> UserRole { get; set; }
        public DbSet<AcademicYearsDB> AcademicYears { get; set; }
        public DbSet<BankDB> Bank { get; set; }
        public DbSet<EducationInstituteDB> EducationInstitute { get; set; }
        public DbSet<CustomerCourseDB> CustomerCourse { get; set; }
        public DbSet<StudentDB> Student { get; set; }
        public DbSet<CustomerCourseSubjectMappingDB> CustomerCourseSubject { get; set; }
        public DbSet<StudentAdmissionDetailsDB> StudentAdmission { get; set; }
        public DbSet<StudentCoursesDB> StudentCourse { get; set; }
        public DbSet<StudentDetailsDB> StudentDetails { get; set; }
        public DbSet<StudentBranchesDB> StudentBranches { get; set; }
    }
}
