using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotnetHomework.Data;

namespace DotnetHomework.Migrations
{
    [DbContext(typeof(SocietyManagementSystemDbContext))]
    partial class SocietyManagementSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.ActivityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Society");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("Time");

                    b.HasKey("Id");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.MemberEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Society");

                    b.Property<int>("User");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.SocietyCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SocietyCategory");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.SocietyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<int>("Creator");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Society");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.TakePartEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Activity");

                    b.Property<int>("User");

                    b.HasKey("Id");

                    b.ToTable("TakePart");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.VSocietyInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<int>("CreatorId");

                    b.Property<string>("CreatorName");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("VSocietyInfo");
                });
        }
    }
}
