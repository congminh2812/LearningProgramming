﻿// <auto-generated />
using System;
using LearningProgramming.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningProgramming.Persistence.Migrations
{
    [DbContext(typeof(LearningProgrammingAppDbContext))]
    partial class LearningProgrammingAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearningProgramming.Domain.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("books", "app-service");
                });

            modelBuilder.Entity("LearningProgramming.Domain.Chapter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("book_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("chapters", "app-service");
                });

            modelBuilder.Entity("LearningProgramming.Domain.Lesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ChapterId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("lessons", "app-service");
                });

            modelBuilder.Entity("LearningProgramming.Domain.LessonComponent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ComponentType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("component_type");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint")
                        .HasColumnName("lesson_id");

                    b.Property<int>("Position")
                        .HasColumnType("integer")
                        .HasColumnName("position");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("lesson_components", "app-service");
                });

            modelBuilder.Entity("LearningProgramming.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("users", "identity-service", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("LearningProgramming.Domain.UserLogin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("ExpiresTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expires_time");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("login_time");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("provider_key");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("refresh_token");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("user_logins", "identity-service", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("LearningProgramming.Domain.UserProgress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean")
                        .HasColumnName("completed");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("completed_at");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint")
                        .HasColumnName("lesson_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("user_progresses", "app-service");
                });

            modelBuilder.Entity("LearningProgramming.Domain.Chapter", b =>
                {
                    b.HasOne("LearningProgramming.Domain.Book", "Book")
                        .WithMany("Chapters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LearningProgramming.Domain.Lesson", b =>
                {
                    b.HasOne("LearningProgramming.Domain.Chapter", null)
                        .WithMany("Lessons")
                        .HasForeignKey("ChapterId");
                });

            modelBuilder.Entity("LearningProgramming.Domain.LessonComponent", b =>
                {
                    b.HasOne("LearningProgramming.Domain.Lesson", "Lesson")
                        .WithMany("LessonComponents")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LearningProgramming.Domain.UserLogin", b =>
                {
                    b.HasOne("LearningProgramming.Domain.User", "User")
                        .WithOne("UserLogin")
                        .HasForeignKey("LearningProgramming.Domain.UserLogin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningProgramming.Domain.UserProgress", b =>
                {
                    b.HasOne("LearningProgramming.Domain.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningProgramming.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningProgramming.Domain.Book", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("LearningProgramming.Domain.Chapter", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LearningProgramming.Domain.Lesson", b =>
                {
                    b.Navigation("LessonComponents");
                });

            modelBuilder.Entity("LearningProgramming.Domain.User", b =>
                {
                    b.Navigation("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}
