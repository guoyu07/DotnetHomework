using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotnetHomework.Data;

namespace DotnetHomework.Data.SocietyManagementSystemMigrations
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

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.MemberEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Society");

                    b.Property<string>("User");

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

                    b.Property<string>("Creator");

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

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("TakePart");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.VSocietyInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("CreatorId");

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
