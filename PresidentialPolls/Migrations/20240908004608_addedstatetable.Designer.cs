﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PresidentialPolls.Model;

#nullable disable

namespace PresidentialPolls.Migrations
{
    [DbContext(typeof(DBContexts.PollContext))]
    [Migration("20240908004608_addedstatetable")]
    partial class addedstatetable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("PresidentialPolls.Model.State", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ElectoralVotes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("States");
                });

            modelBuilder.Entity("PresidentialPolls.Model.StatesPollData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<float?>("DemocratPollPercentage")
                        .HasColumnType("REAL");

                    b.Property<float?>("RepublicanPollPercentage")
                        .HasColumnType("REAL");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Polls");
                });
#pragma warning restore 612, 618
        }
    }
}