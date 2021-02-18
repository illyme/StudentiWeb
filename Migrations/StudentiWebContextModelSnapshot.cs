﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentiWeb.Data;

namespace StudentiWeb.Migrations
{
    [DbContext(typeof(StudentiWebContext))]
    partial class StudentiWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentiWeb.Models.Disciplina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Nume")
                        .IsUnique()
                        .HasFilter("[Nume] IS NOT NULL");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("StudentiWeb.Models.Nota", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisciplinaID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<decimal>("Valoare_nota")
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("ID");

                    b.HasIndex("DisciplinaID");

                    b.HasIndex("StudentID", "DisciplinaID")
                        .IsUnique();

                    b.ToTable("Nota");
                });

            modelBuilder.Entity("StudentiWeb.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NrMatricol")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("NrMatricol")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentiWeb.Models.Nota", b =>
                {
                    b.HasOne("StudentiWeb.Models.Disciplina", "Disciplina")
                        .WithMany("Note")
                        .HasForeignKey("DisciplinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentiWeb.Models.Student", "Student")
                        .WithMany("Note")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
