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

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Reason");

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

                    b.Property<string>("EntryPost");

                    b.Property<DateTime?>("EntryTime");

                    b.Property<int>("Society");

                    b.Property<string>("Status");

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

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Creator");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Reason");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Society");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.TakePartEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Activity");

                    b.Property<DateTime?>("Time");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("TakePart");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.VActivityInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Reason");

                    b.Property<string>("SocietyDescription");

                    b.Property<int>("SocietyId");

                    b.Property<string>("SocietyName");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("Time");

                    b.HasKey("Id");

                    b.ToTable("VActivityInfo");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.VMemberInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EntryPost");

                    b.Property<DateTime?>("EntryTime");

                    b.Property<string>("SocietyDescription");

                    b.Property<int>("SocietyId");

                    b.Property<string>("SocietyName");

                    b.Property<string>("Status");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("VMemberInfo");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.VSocietyInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("CategoryName");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreatorId");

                    b.Property<string>("CreatorName");

                    b.Property<string>("Description");

                    b.Property<int>("MemberCount");

                    b.Property<string>("Name");

                    b.Property<string>("Reason");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("VSocietyInfo");
                });

            modelBuilder.Entity("DotnetHomework.Data.SocietyManagementSystemEntities.VTakePartInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityDescription");

                    b.Property<int>("ActivityId");

                    b.Property<string>("ActivityName");

                    b.Property<string>("ActivityStatus");

                    b.Property<DateTime?>("ActivityTime");

                    b.Property<DateTime?>("ApplicationPeriod");

                    b.Property<int>("SocietyId");

                    b.Property<string>("SocietyName");

                    b.Property<string>("UserId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("VTakePartInfo");
                });
        }
    }
}
