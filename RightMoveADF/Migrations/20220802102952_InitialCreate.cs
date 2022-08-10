using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightMoveADF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Property_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    New_Home = table.Column<bool>(type: "bit", nullable: true),
                    Student_Property = table.Column<bool>(type: "bit", nullable: true),
                    House_Flat_Share = table.Column<bool>(type: "bit", nullable: true),
                    Create_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Available = table.Column<DateTime>(type: "date", nullable: true),
                    Contract_Months = table.Column<int>(type: "int", nullable: true),
                    Minimum_Term = table.Column<int>(type: "int", nullable: true),
                    Let_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property_1", x => x.Agent_Ref);
                });

            migrationBuilder.CreateTable(
                name: "Property_Media_Property_Media",
                columns: table => new
                {
                    Media_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Media_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort_Order = table.Column<int>(type: "int", nullable: true),
                    Media_Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogintTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    LoggedInCount = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDTS = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegister", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Branch_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<int>(type: "int", nullable: false),
                    Overseas = table.Column<bool>(type: "bit", nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Branch_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    Network_ID = table.Column<long>(type: "bigint", nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Network_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateTable(
                name: "Property_Address",
                columns: table => new
                {
                    House_Name_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Display_Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    POV_Latitude = table.Column<double>(type: "float", nullable: true),
                    POV_Longitude = table.Column<double>(type: "float", nullable: true),
                    POV_Pitch = table.Column<double>(type: "float", nullable: true),
                    POV_Heading = table.Column<double>(type: "float", nullable: true),
                    POV_Zoom = table.Column<double>(type: "float", nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Property_Address_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateTable(
                name: "Property_Details",
                columns: table => new
                {
                    Summary = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: true),
                    Reception_Rooms = table.Column<int>(type: "int", nullable: true),
                    Parking = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Outside_Space = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Year_Built = table.Column<int>(type: "int", nullable: true),
                    Internal_Area = table.Column<int>(type: "int", nullable: true),
                    Internal_Area_Unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Land_Area = table.Column<int>(type: "int", nullable: true),
                    Land_Area_Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Floors = table.Column<int>(type: "int", nullable: true),
                    Entrance_Floor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Accessibility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Heating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Furnished_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pets_Allowed = table.Column<bool>(type: "bit", nullable: true),
                    Smokers_Considered = table.Column<bool>(type: "bit", nullable: true),
                    Deprecated = table.Column<bool>(type: "bit", nullable: true),
                    Sharers_Considered = table.Column<bool>(type: "bit", nullable: true),
                    Burglar_Alarm = table.Column<bool>(type: "bit", nullable: true),
                    Washing_Machine = table.Column<bool>(type: "bit", nullable: true),
                    Dishwasher = table.Column<bool>(type: "bit", nullable: true),
                    All_Bills_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Water_Bill_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Gas_Bill_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Electricity_Bill_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Oil_Bill_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Council_Tax_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Council_Tax_Exempt = table.Column<bool>(type: "bit", nullable: true),
                    TV_Licence_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Sat_Cable_TV_Bill_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Internet_Bill_Inc = table.Column<bool>(type: "bit", nullable: true),
                    Business_For_Sale = table.Column<bool>(type: "bit", nullable: true),
                    Comm_Use_Class = table.Column<bool>(type: "bit", nullable: true),
                    Council_Tax_Band = table.Column<bool>(type: "bit", nullable: true),
                    Domestic_Rates = table.Column<int>(type: "int", nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Property_Details_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateTable(
                name: "Property_Details_Sizing",
                columns: table => new
                {
                    Minimum = table.Column<int>(type: "int", nullable: true),
                    Maximum = table.Column<int>(type: "int", nullable: true),
                    Area_Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Property_Details_Sizing_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateTable(
                name: "Property_Media",
                columns: table => new
                {
                    Media_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Media_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort_Order = table.Column<int>(type: "int", nullable: true),
                    Media_Update_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Property_Media_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateTable(
                name: "Property_Price",
                columns: table => new
                {
                    Price = table.Column<int>(type: "int", nullable: false),
                    Price_Qualifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deposit = table.Column<int>(type: "int", nullable: true),
                    Administration_Fee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rent_Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tenure_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Auction = table.Column<bool>(type: "bit", nullable: true),
                    Tenure_Unexpired_Years = table.Column<int>(type: "int", nullable: true),
                    Price_Per_Unit_Area = table.Column<int>(type: "int", nullable: true),
                    Price_Per_Unit_Per_Annum = table.Column<int>(type: "int", nullable: true),
                    Shared_Ownership = table.Column<bool>(type: "bit", nullable: true),
                    Shared_Ownership_Percentage = table.Column<double>(type: "float", nullable: true),
                    Shared_Ownership_Rent = table.Column<double>(type: "float", nullable: true),
                    Shared_Ownership_Rent_Frequency = table.Column<int>(type: "int", nullable: true),
                    Annual_Ground_Rent = table.Column<int>(type: "int", nullable: true),
                    Ground_Rent_Review_Period_Years = table.Column<int>(type: "int", nullable: true),
                    Ground_Rent_Percentage_Increase = table.Column<double>(type: "float", nullable: true),
                    Annual_Service_Charge = table.Column<int>(type: "int", nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Property_Price_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateTable(
                name: "Property_Room",
                columns: table => new
                {
                    Room_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Room_Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Room_Length = table.Column<double>(type: "float", nullable: true),
                    Room_Width = table.Column<double>(type: "float", nullable: true),
                    Room_Dimension_Unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Room_Dimensions_Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Room_Photo_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent_Ref = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Property_Room_Property",
                        column: x => x.Agent_Ref,
                        principalTable: "Property",
                        principalColumn: "Agent_Ref");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Agent_Ref",
                table: "Branch",
                column: "Agent_Ref");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Agent_Ref",
                table: "Network",
                column: "Agent_Ref");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Address",
                table: "Property_Address",
                column: "House_Name_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_Address_Agent_Ref",
                table: "Property_Address",
                column: "Agent_Ref");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Details_Agent_Ref",
                table: "Property_Details",
                column: "Agent_Ref");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Details_Sizing_Agent_Ref",
                table: "Property_Details_Sizing",
                column: "Agent_Ref");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Media_Agent_Ref",
                table: "Property_Media",
                column: "Agent_Ref");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Price_Agent_Ref",
                table: "Property_Price",
                column: "Agent_Ref");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Room_Agent_Ref",
                table: "Property_Room",
                column: "Agent_Ref");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropTable(
                name: "Property_Address");

            migrationBuilder.DropTable(
                name: "Property_Details");

            migrationBuilder.DropTable(
                name: "Property_Details_Sizing");

            migrationBuilder.DropTable(
                name: "Property_Media");

            migrationBuilder.DropTable(
                name: "Property_Media_Property_Media");

            migrationBuilder.DropTable(
                name: "Property_Price");

            migrationBuilder.DropTable(
                name: "Property_Room");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRegister");

            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
