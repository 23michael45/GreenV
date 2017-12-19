﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NetCoreMvcServer.Models;
using System;

namespace NetCoreMvcServer.Migrations
{
    [DbContext(typeof(GVContext))]
    [Migration("20171219092822_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("NetCoreMvcServer.Models.App_GroundTruthData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("device");

                    b.Property<int>("leftright");

                    b.Property<long>("timestamp");

                    b.HasKey("id");

                    b.ToTable("App_GroundTruthData");
                });

            modelBuilder.Entity("NetCoreMvcServer.Models.App_SensorData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("device");

                    b.Property<byte[]>("sendsorvalue");

                    b.Property<long>("timestampms");

                    b.Property<long>("timestamps");

                    b.HasKey("id");

                    b.ToTable("App_SensorData");
                });
#pragma warning restore 612, 618
        }
    }
}