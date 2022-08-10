using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RightMoveADF.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Network> Networks { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<PropertyAddress> PropertyAddresses { get; set; } = null!;
        public virtual DbSet<PropertyDetail> PropertyDetails { get; set; } = null!;
        public virtual DbSet<PropertyDetailsSizing> PropertyDetailsSizings { get; set; } = null!;
        public virtual DbSet<PropertyMedia> PropertyMedia { get; set; } = null!;
        public virtual DbSet<PropertyPrice> PropertyPrices { get; set; } = null!;
        public virtual DbSet<PropertyRoom> PropertyRooms { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<UserRegister> UserRegisters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TC2S995\\SQLEXPRESS;Initial Catalog=RightMoveDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchId).HasColumnName("Branch_ID").ValueGeneratedOnAdd();


                
            });

            modelBuilder.Entity<Network>(entity =>
            {
                entity.ToTable("Network");

                entity.Property(e => e.NetworkId).HasColumnName("Network_ID").ValueGeneratedOnAdd();

                
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.AgentRef)
                    .HasName("PK_Property_1");

                entity.ToTable("Property");
               
                entity.Property(e => e.AgentRef)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_Ref");

                entity.Property(e => e.ContractMonths).HasColumnName("Contract_Months");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.DateAvailable)
                    .HasColumnType("date")
                    .HasColumnName("Date_Available");

                entity.Property(e => e.HouseFlatShare).HasColumnName("House_Flat_Share");

                entity.Property(e => e.LetType)
                    .HasMaxLength(50)
                    .HasColumnName("Let_Type");

                entity.Property(e => e.MinimumTerm).HasColumnName("Minimum_Term");

                entity.Property(e => e.NewHome).HasColumnName("New_Home");

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(50)
                    .HasColumnName("Property_Type");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.StudentProperty).HasColumnName("Student_Property");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date");
            });

            modelBuilder.Entity<PropertyAddress>(entity =>
            {
                entity.ToTable("Property_Address");

                entity.HasIndex(e => e.HouseNameNumber, "IX_Property_Address")
                    .IsUnique();
                entity.Property(e => e.Id)
       .HasColumnName("Id")
       .ValueGeneratedOnAdd();

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .HasColumnName("Address_2");

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .HasColumnName("Address_3");

                entity.Property(e => e.Address4)
                    .HasMaxLength(50)
                    .HasColumnName("Address_4");

                entity.Property(e => e.AgentRef)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_Ref");

                entity.Property(e => e.DisplayAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Display_Address");

                entity.Property(e => e.HouseNameNumber)
                    .HasMaxLength(50)
                    .HasColumnName("House_Name_Number");

                entity.Property(e => e.Postcode1)
                    .HasMaxLength(50)
                    .HasColumnName("Postcode_1");

                entity.Property(e => e.Postcode2)
                    .HasMaxLength(50)
                    .HasColumnName("Postcode_2");

                entity.Property(e => e.PovHeading).HasColumnName("POV_Heading");

                entity.Property(e => e.PovLatitude).HasColumnName("POV_Latitude");

                entity.Property(e => e.PovLongitude).HasColumnName("POV_Longitude");

                entity.Property(e => e.PovPitch).HasColumnName("POV_Pitch");

                entity.Property(e => e.PovZoom).HasColumnName("POV_Zoom");

                entity.Property(e => e.Town).HasMaxLength(50);

               
            });

            modelBuilder.Entity<PropertyDetail>(entity =>
            {
                entity.ToTable("Property_Details");

                entity.Property(e => e.Accessibility).HasMaxLength(50);

                entity.Property(e => e.AgentRef)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_Ref");
                entity.Property(e => e.Id)
       .HasColumnName("Id")
       .ValueGeneratedOnAdd();

                entity.Property(e => e.AllBillsInc).HasColumnName("All_Bills_Inc");

                entity.Property(e => e.BurglarAlarm).HasColumnName("Burglar_Alarm");

                entity.Property(e => e.BusinessForSale).HasColumnName("Business_For_Sale");

                entity.Property(e => e.CommUseClass).HasColumnName("Comm_Use_Class");

                entity.Property(e => e.Condition).HasMaxLength(50);

                entity.Property(e => e.CouncilTaxBand).HasColumnName("Council_Tax_Band");

                entity.Property(e => e.CouncilTaxExempt).HasColumnName("Council_Tax_Exempt");

                entity.Property(e => e.CouncilTaxInc).HasColumnName("Council_Tax_Inc");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DomesticRates).HasColumnName("Domestic_Rates");

                entity.Property(e => e.ElectricityBillInc).HasColumnName("Electricity_Bill_Inc");

                entity.Property(e => e.EntranceFloor)
                    .HasMaxLength(50)
                    .HasColumnName("Entrance_Floor");

                entity.Property(e => e.FurnishedType)
                    .HasMaxLength(50)
                    .HasColumnName("Furnished_Type");

                entity.Property(e => e.GasBillInc).HasColumnName("Gas_Bill_Inc");

                entity.Property(e => e.Heating).HasMaxLength(50);

                entity.Property(e => e.InternalArea).HasColumnName("Internal_Area");

                entity.Property(e => e.InternalAreaUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Internal_Area_Unit");

                entity.Property(e => e.InternetBillInc).HasColumnName("Internet_Bill_Inc");

                entity.Property(e => e.LandArea).HasColumnName("Land_Area");

                entity.Property(e => e.LandAreaUnit)
                    .HasMaxLength(50)
                    .HasColumnName("Land_Area_Unit");

                entity.Property(e => e.OilBillInc).HasColumnName("Oil_Bill_Inc");

                entity.Property(e => e.OutsideSpace)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Outside_Space");

                entity.Property(e => e.Parking)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PetsAllowed).HasColumnName("Pets_Allowed");

                entity.Property(e => e.ReceptionRooms).HasColumnName("Reception_Rooms");

                entity.Property(e => e.SatCableTvBillInc).HasColumnName("Sat_Cable_TV_Bill_Inc");

                entity.Property(e => e.SharersConsidered).HasColumnName("Sharers_Considered");

                entity.Property(e => e.SmokersConsidered).HasColumnName("Smokers_Considered");

                entity.Property(e => e.Summary).HasMaxLength(50);

                entity.Property(e => e.TvLicenceInc).HasColumnName("TV_Licence_Inc");

                entity.Property(e => e.WashingMachine).HasColumnName("Washing_Machine");

                entity.Property(e => e.WaterBillInc).HasColumnName("Water_Bill_Inc");

                entity.Property(e => e.YearBuilt).HasColumnName("Year_Built");

            });

            modelBuilder.Entity<PropertyDetailsSizing>(entity =>
            {
                entity.ToTable("Property_Details_Sizing");

                entity.Property(e => e.AgentRef)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_Ref");
                entity.Property(e => e.Id)
       .HasColumnName("Id")
       .ValueGeneratedOnAdd();

                entity.Property(e => e.AreaUnit)
                    .HasMaxLength(50)
                    .HasColumnName("Area_Unit");

               
            });

            modelBuilder.Entity<PropertyMedia>(entity =>
            {
                entity.ToTable("Property_Media");

                entity.Property(e => e.AgentRef)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_Ref");

                entity.Property(e => e.Caption).HasMaxLength(50);
                entity.Property(e => e.Id)
       .HasColumnName("Id")
       .ValueGeneratedOnAdd();
                entity.Property(e => e.MediaType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Media_Type");

                entity.Property(e => e.MediaUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Media_Update_Date");

                entity.Property(e => e.MediaUrl).HasColumnName("Media_URL");

                entity.Property(e => e.SortOrder).HasColumnName("Sort_Order");

                
            });

            modelBuilder.Entity<PropertyPrice>(entity =>
            {
                entity.ToTable("Property_Price");

                entity.Property(e => e.AdministrationFee)
                    .HasMaxLength(50)
                    .HasColumnName("Administration_Fee");

                entity.Property(e => e.AgentRef)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_Ref");
                entity.Property(e => e.Id)
       .HasColumnName("Id")
       .ValueGeneratedOnAdd();

                entity.Property(e => e.AnnualGroundRent).HasColumnName("Annual_Ground_Rent");

                entity.Property(e => e.AnnualServiceCharge).HasColumnName("Annual_Service_Charge");

                entity.Property(e => e.GroundRentPercentageIncrease).HasColumnName("Ground_Rent_Percentage_Increase");

                entity.Property(e => e.GroundRentReviewPeriodYears).HasColumnName("Ground_Rent_Review_Period_Years");

                entity.Property(e => e.PricePerUnitArea).HasColumnName("Price_Per_Unit_Area");

                entity.Property(e => e.PricePerUnitPerAnnum).HasColumnName("Price_Per_Unit_Per_Annum");

                entity.Property(e => e.PriceQualifier)
                    .HasMaxLength(50)
                    .HasColumnName("Price_Qualifier");

                entity.Property(e => e.RentFrequency)
                    .HasMaxLength(50)
                    .HasColumnName("Rent_Frequency");

                entity.Property(e => e.SharedOwnership).HasColumnName("Shared_Ownership");

                entity.Property(e => e.SharedOwnershipPercentage).HasColumnName("Shared_Ownership_Percentage");

                entity.Property(e => e.SharedOwnershipRent).HasColumnName("Shared_Ownership_Rent");

                entity.Property(e => e.SharedOwnershipRentFrequency).HasColumnName("Shared_Ownership_Rent_Frequency");

                entity.Property(e => e.TenureType)
                    .HasMaxLength(50)
                    .HasColumnName("Tenure_Type");

                entity.Property(e => e.TenureUnexpiredYears).HasColumnName("Tenure_Unexpired_Years");

            });

            modelBuilder.Entity<PropertyRoom>(entity =>
            {
                entity.ToTable("Property_Room");

                entity.Property(e => e.AgentRef)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_Ref");
                entity.Property(e => e.Id)
       .HasColumnName("Id")
       .ValueGeneratedOnAdd();

                entity.Property(e => e.RoomDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Room_Description");

                entity.Property(e => e.RoomDimensionUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Room_Dimension_Unit");

                entity.Property(e => e.RoomDimensionsText)
                    .HasMaxLength(50)
                    .HasColumnName("Room_Dimensions_Text");

                entity.Property(e => e.RoomLength).HasColumnName("Room_Length");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(50)
                    .HasColumnName("Room_Name");

                entity.Property(e => e.RoomPhotoUrl).HasColumnName("Room_Photo_URL");

                entity.Property(e => e.RoomWidth).HasColumnName("Room_Width");

            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("UserLogin");

                entity.Property(e => e.LogintTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserRegister>(entity =>
            {
                entity.ToTable("UserRegister");

                entity.Property(e => e.CreatedDts)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedDTS");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PostCode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
