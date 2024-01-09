using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_aplicatieWeb.Data;

#nullable disable

namespace Proiect_aplicatieWeb.Migrations
{
    [DbContext(typeof(Proiect_aplicatieWebContext))]
    [Migration("20231226165122_CreateDatabase")]
    partial class CreateDatabase
    {
        
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Interventie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IdSpecializare")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SpecializareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecializareId");

                    b.ToTable("Interventie");
                });

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Medic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdSpecializare")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("SpecializareId")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SpecializareId");

                    b.ToTable("Medic");
                });

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Pacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Programare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdInterventie")
                        .HasColumnType("int");

                    b.Property<int>("IdMedic")
                        .HasColumnType("int");

                    b.Property<int>("IdPacient")
                        .HasColumnType("int");

                    b.Property<int>("InterventieId")
                        .HasColumnType("int");

                    b.Property<int>("MedicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ora")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterventieId");

                    b.HasIndex("MedicId");

                    b.HasIndex("PacientId");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Specializare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Specializare");
                });

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Interventie", b =>
                {
                    b.HasOne("Proiect_aplicatieWeb.Models.Specializare", "Specializare")
                        .WithMany()
                        .HasForeignKey("SpecializareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Medic", b =>
                {
                    b.HasOne("Proiect_aplicatieWeb.Models.Specializare", "Specializare")
                        .WithMany()
                        .HasForeignKey("SpecializareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("Proiect_aplicatieWeb.Models.Programare", b =>
                {
                    b.HasOne("Proiect_aplicatieWeb.Models.Interventie", "Interventie")
                        .WithMany()
                        .HasForeignKey("InterventieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_aplicatieWeb.Models.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_aplicatieWeb.Models.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interventie");

                    b.Navigation("Medic");

                    b.Navigation("Pacient");
                });
#pragma warning restore 612, 618
        }
    }
}
