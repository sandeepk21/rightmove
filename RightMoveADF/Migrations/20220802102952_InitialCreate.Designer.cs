﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RightMoveADF.Models;

#nullable disable

namespace RightMoveADF.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20220802102952_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RightMoveADF.Models.Branch", b =>
                {
                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Branch_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchId"), 1L, 1);

                    b.Property<int>("Channel")
                        .HasColumnType("int");

                    b.Property<bool?>("Overseas")
                        .HasColumnType("bit");

                    b.HasIndex("AgentRef");

                    b.ToTable("Branch", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.Network", b =>
                {
                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<long?>("NetworkId")
                        .HasColumnType("bigint")
                        .HasColumnName("Network_ID");

                    b.HasIndex("AgentRef");

                    b.ToTable("Network", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.Property", b =>
                {
                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<int?>("ContractMonths")
                        .HasColumnType("int")
                        .HasColumnName("Contract_Months");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Create_Date");

                    b.Property<DateTime?>("DateAvailable")
                        .HasColumnType("date")
                        .HasColumnName("Date_Available");

                    b.Property<bool?>("HouseFlatShare")
                        .HasColumnType("bit")
                        .HasColumnName("House_Flat_Share");

                    b.Property<string>("LetType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Let_Type");

                    b.Property<int?>("MinimumTerm")
                        .HasColumnType("int")
                        .HasColumnName("Minimum_Term");

                    b.Property<bool?>("NewHome")
                        .HasColumnType("bit")
                        .HasColumnName("New_Home");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Property_Type");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("StudentProperty")
                        .HasColumnType("bit")
                        .HasColumnName("Student_Property");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Update_Date");

                    b.HasKey("AgentRef")
                        .HasName("PK_Property_1");

                    b.ToTable("Property", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyAddress", b =>
                {
                    b.Property<string>("Address2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Address_2");

                    b.Property<string>("Address3")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Address_3");

                    b.Property<string>("Address4")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Address_4");

                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<string>("DisplayAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Display_Address");

                    b.Property<string>("HouseNameNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("House_Name_Number");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Postcode1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Postcode_1");

                    b.Property<string>("Postcode2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Postcode_2");

                    b.Property<double?>("PovHeading")
                        .HasColumnType("float")
                        .HasColumnName("POV_Heading");

                    b.Property<double?>("PovLatitude")
                        .HasColumnType("float")
                        .HasColumnName("POV_Latitude");

                    b.Property<double?>("PovLongitude")
                        .HasColumnType("float")
                        .HasColumnName("POV_Longitude");

                    b.Property<double?>("PovPitch")
                        .HasColumnType("float")
                        .HasColumnName("POV_Pitch");

                    b.Property<double?>("PovZoom")
                        .HasColumnType("float")
                        .HasColumnName("POV_Zoom");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("AgentRef");

                    b.HasIndex(new[] { "HouseNameNumber" }, "IX_Property_Address")
                        .IsUnique();

                    b.ToTable("Property_Address", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyDetail", b =>
                {
                    b.Property<string>("Accessibility")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<bool?>("AllBillsInc")
                        .HasColumnType("bit")
                        .HasColumnName("All_Bills_Inc");

                    b.Property<int?>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<bool?>("BurglarAlarm")
                        .HasColumnType("bit")
                        .HasColumnName("Burglar_Alarm");

                    b.Property<bool?>("BusinessForSale")
                        .HasColumnType("bit")
                        .HasColumnName("Business_For_Sale");

                    b.Property<bool?>("CommUseClass")
                        .HasColumnType("bit")
                        .HasColumnName("Comm_Use_Class");

                    b.Property<string>("Condition")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("CouncilTaxBand")
                        .HasColumnType("bit")
                        .HasColumnName("Council_Tax_Band");

                    b.Property<bool?>("CouncilTaxExempt")
                        .HasColumnType("bit")
                        .HasColumnName("Council_Tax_Exempt");

                    b.Property<bool?>("CouncilTaxInc")
                        .HasColumnType("bit")
                        .HasColumnName("Council_Tax_Inc");

                    b.Property<bool?>("Deprecated")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Dishwasher")
                        .HasColumnType("bit");

                    b.Property<int?>("DomesticRates")
                        .HasColumnType("int")
                        .HasColumnName("Domestic_Rates");

                    b.Property<bool?>("ElectricityBillInc")
                        .HasColumnType("bit")
                        .HasColumnName("Electricity_Bill_Inc");

                    b.Property<string>("EntranceFloor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Entrance_Floor");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Floors")
                        .HasColumnType("int");

                    b.Property<string>("FurnishedType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Furnished_Type");

                    b.Property<bool?>("GasBillInc")
                        .HasColumnType("bit")
                        .HasColumnName("Gas_Bill_Inc");

                    b.Property<string>("Heating")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("InternalArea")
                        .HasColumnType("int")
                        .HasColumnName("Internal_Area");

                    b.Property<string>("InternalAreaUnit")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Internal_Area_Unit");

                    b.Property<bool?>("InternetBillInc")
                        .HasColumnType("bit")
                        .HasColumnName("Internet_Bill_Inc");

                    b.Property<int?>("LandArea")
                        .HasColumnType("int")
                        .HasColumnName("Land_Area");

                    b.Property<string>("LandAreaUnit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Land_Area_Unit");

                    b.Property<bool?>("OilBillInc")
                        .HasColumnType("bit")
                        .HasColumnName("Oil_Bill_Inc");

                    b.Property<string>("OutsideSpace")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Outside_Space");

                    b.Property<string>("Parking")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("PetsAllowed")
                        .HasColumnType("bit")
                        .HasColumnName("Pets_Allowed");

                    b.Property<int?>("ReceptionRooms")
                        .HasColumnType("int")
                        .HasColumnName("Reception_Rooms");

                    b.Property<bool?>("SatCableTvBillInc")
                        .HasColumnType("bit")
                        .HasColumnName("Sat_Cable_TV_Bill_Inc");

                    b.Property<bool?>("SharersConsidered")
                        .HasColumnType("bit")
                        .HasColumnName("Sharers_Considered");

                    b.Property<bool?>("SmokersConsidered")
                        .HasColumnType("bit")
                        .HasColumnName("Smokers_Considered");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("TvLicenceInc")
                        .HasColumnType("bit")
                        .HasColumnName("TV_Licence_Inc");

                    b.Property<bool?>("WashingMachine")
                        .HasColumnType("bit")
                        .HasColumnName("Washing_Machine");

                    b.Property<bool?>("WaterBillInc")
                        .HasColumnType("bit")
                        .HasColumnName("Water_Bill_Inc");

                    b.Property<int?>("YearBuilt")
                        .HasColumnType("int")
                        .HasColumnName("Year_Built");

                    b.HasIndex("AgentRef");

                    b.ToTable("Property_Details", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyDetailsSizing", b =>
                {
                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<string>("AreaUnit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Area_Unit");

                    b.Property<int?>("Maximum")
                        .HasColumnType("int");

                    b.Property<int?>("Minimum")
                        .HasColumnType("int");

                    b.HasIndex("AgentRef");

                    b.ToTable("Property_Details_Sizing", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyMediaPropertyMedium", b =>
                {
                    b.Property<string>("Caption")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Media_Type");

                    b.Property<DateTime?>("MediaUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Media_Update_Date");

                    b.Property<string>("MediaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Media_URL");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int")
                        .HasColumnName("Sort_Order");

                    b.ToTable("Property_Media_Property_Media", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyMedium", b =>
                {
                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<string>("Caption")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Media_Type");

                    b.Property<DateTime?>("MediaUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Media_Update_Date");

                    b.Property<string>("MediaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Media_URL");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int")
                        .HasColumnName("Sort_Order");

                    b.HasIndex("AgentRef");

                    b.ToTable("Property_Media", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyPrice", b =>
                {
                    b.Property<string>("AdministrationFee")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Administration_Fee");

                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<int?>("AnnualGroundRent")
                        .HasColumnType("int")
                        .HasColumnName("Annual_Ground_Rent");

                    b.Property<int?>("AnnualServiceCharge")
                        .HasColumnType("int")
                        .HasColumnName("Annual_Service_Charge");

                    b.Property<bool?>("Auction")
                        .HasColumnType("bit");

                    b.Property<int?>("Deposit")
                        .HasColumnType("int");

                    b.Property<double?>("GroundRentPercentageIncrease")
                        .HasColumnType("float")
                        .HasColumnName("Ground_Rent_Percentage_Increase");

                    b.Property<int?>("GroundRentReviewPeriodYears")
                        .HasColumnType("int")
                        .HasColumnName("Ground_Rent_Review_Period_Years");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("PricePerUnitArea")
                        .HasColumnType("int")
                        .HasColumnName("Price_Per_Unit_Area");

                    b.Property<int?>("PricePerUnitPerAnnum")
                        .HasColumnType("int")
                        .HasColumnName("Price_Per_Unit_Per_Annum");

                    b.Property<string>("PriceQualifier")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Price_Qualifier");

                    b.Property<string>("RentFrequency")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Rent_Frequency");

                    b.Property<bool?>("SharedOwnership")
                        .HasColumnType("bit")
                        .HasColumnName("Shared_Ownership");

                    b.Property<double?>("SharedOwnershipPercentage")
                        .HasColumnType("float")
                        .HasColumnName("Shared_Ownership_Percentage");

                    b.Property<double?>("SharedOwnershipRent")
                        .HasColumnType("float")
                        .HasColumnName("Shared_Ownership_Rent");

                    b.Property<int?>("SharedOwnershipRentFrequency")
                        .HasColumnType("int")
                        .HasColumnName("Shared_Ownership_Rent_Frequency");

                    b.Property<string>("TenureType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tenure_Type");

                    b.Property<int?>("TenureUnexpiredYears")
                        .HasColumnType("int")
                        .HasColumnName("Tenure_Unexpired_Years");

                    b.HasIndex("AgentRef");

                    b.ToTable("Property_Price", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyRoom", b =>
                {
                    b.Property<string>("AgentRef")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Agent_Ref");

                    b.Property<string>("RoomDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Room_Description");

                    b.Property<string>("RoomDimensionUnit")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Room_Dimension_Unit");

                    b.Property<string>("RoomDimensionsText")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Room_Dimensions_Text");

                    b.Property<double?>("RoomLength")
                        .HasColumnType("float")
                        .HasColumnName("Room_Length");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Room_Name");

                    b.Property<string>("RoomPhotoUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Room_Photo_URL");

                    b.Property<double?>("RoomWidth")
                        .HasColumnType("float")
                        .HasColumnName("Room_Width");

                    b.HasIndex("AgentRef");

                    b.ToTable("Property_Room", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LoggedInCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LogintTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Upassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.UserRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDts")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDTS");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsLock")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserRegister", (string)null);
                });

            modelBuilder.Entity("RightMoveADF.Models.Branch", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Branch_Property");

                    b.Navigation("AgentRefNavigation");
                });

            modelBuilder.Entity("RightMoveADF.Models.Network", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Network_Property");

                    b.Navigation("AgentRefNavigation");
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyAddress", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Property_Address_Property");

                    b.Navigation("AgentRefNavigation");
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyDetail", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Property_Details_Property");

                    b.Navigation("AgentRefNavigation");
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyDetailsSizing", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Property_Details_Sizing_Property");

                    b.Navigation("AgentRefNavigation");
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyMedium", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Property_Media_Property");

                    b.Navigation("AgentRefNavigation");
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyPrice", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Property_Price_Property");

                    b.Navigation("AgentRefNavigation");
                });

            modelBuilder.Entity("RightMoveADF.Models.PropertyRoom", b =>
                {
                    b.HasOne("RightMoveADF.Models.Property", "AgentRefNavigation")
                        .WithMany()
                        .HasForeignKey("AgentRef")
                        .HasConstraintName("FK_Property_Room_Property");

                    b.Navigation("AgentRefNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}