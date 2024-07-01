using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    SpaceRequired = table.Column<double>(type: "float", nullable: false),
                    Diet = table.Column<int>(type: "int", nullable: false),
                    Predator = table.Column<bool>(type: "bit", nullable: false),
                    Activity = table.Column<int>(type: "int", nullable: false),
                    SecurityRequired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZooModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZooId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_ZooModel_ZooId",
                        column: x => x.ZooId,
                        principalTable: "ZooModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Climate = table.Column<int>(type: "int", nullable: false),
                    Habitat = table.Column<int>(type: "int", nullable: false),
                    SecurityRequired = table.Column<int>(type: "int", nullable: false),
                    PredatorEnclosure = table.Column<bool>(type: "bit", nullable: false),
                    PredatorSpeciesId = table.Column<int>(type: "int", nullable: false),
                    ZooId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enclosures_Species_PredatorSpeciesId",
                        column: x => x.PredatorSpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enclosures_ZooModel_ZooId",
                        column: x => x.ZooId,
                        principalTable: "ZooModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategorySpecies",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySpecies", x => new { x.CategoriesId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_CategorySpecies_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Personality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredDiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    ZooId = table.Column<int>(type: "int", nullable: false),
                    EnclosureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_ZooModel_ZooId",
                        column: x => x.ZooId,
                        principalTable: "ZooModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Activity", "Diet", "LatinName", "Name", "Predator", "SecurityRequired", "Size", "SpaceRequired" },
                values: new object[,]
                {
                    { 1, 1, 0, "Giraffa camelopardalis", "Tiger", false, 2, 0, 88.460708380369269 },
                    { 2, 2, 4, "Panthera tigris sumatrae", "African Penguin", false, 0, 1, 87.633967744062232 },
                    { 3, 2, 3, "Trichechus spp.", "African Grey Parrot", false, 3, 2, 65.884924687879305 },
                    { 4, 1, 4, "Bradypus spp.", "Red Kangaroo", false, 0, 0, 27.096385922713264 },
                    { 5, 2, 4, "Ceratotherium simum", "Siamang", false, 2, 3, 60.138309500837643 },
                    { 6, 0, 0, "Elephas maximus", "Puma", true, 0, 0, 77.30513071854611 },
                    { 7, 1, 2, "Conraua goliath", "Golden Eagle", false, 0, 2, 57.187642922638886 },
                    { 8, 2, 0, "Haliaeetus leucocephalus", "Gibbon", false, 2, 0, 75.093834657924361 },
                    { 9, 1, 2, "Suricata suricatta", "Sumatran Tiger", true, 3, 5, 72.995315086334159 },
                    { 10, 0, 2, "Ara ararauna", "Chimpanzee", true, 3, 4, 99.270789916753372 },
                    { 11, 0, 0, "Panthera tigris", "Aldabra Giant Tortoise", true, 0, 1, 89.053093533691836 },
                    { 12, 2, 1, "Nasua spp.", "Tiger", true, 2, 5, 89.121976906538578 },
                    { 13, 2, 1, "Pongo pygmaeus", "Komodo Dragon", false, 2, 0, 86.597154501647083 },
                    { 14, 0, 0, "Odocoileus virginianus", "Common Ostrich", true, 3, 5, 49.004174810506285 },
                    { 15, 1, 1, "Giraffa camelopardalis", "White-Tailed Deer", true, 0, 0, 98.109969737456282 },
                    { 16, 0, 0, "Phascolarctos cinereus", "Red Panda", false, 0, 3, 85.129108459007341 },
                    { 17, 1, 2, "Ursus americanus", "Golden Eagle", true, 0, 2, 90.206075040907137 },
                    { 18, 2, 0, "Alligator mississippiensis", "American Alligator", false, 0, 4, 31.340144746159641 },
                    { 19, 1, 2, "Pteronura brasiliensis", "American Alligator", false, 0, 2, 10.553757273863893 },
                    { 20, 2, 0, "Spheniscus humboldti", "Spectacled Bear", false, 0, 1, 81.441223424869179 },
                    { 21, 1, 1, "Spheniscus demersus", "Plains Zebra", true, 1, 3, 18.303023966727061 },
                    { 22, 1, 3, "Ursus americanus", "Bengal Tiger", false, 2, 2, 50.366014695894521 },
                    { 23, 2, 3, "Giraffa camelopardalis", "Emperor Penguin", false, 2, 5, 45.851097544766752 },
                    { 24, 1, 4, "Panthera tigris", "Siberian Tiger", true, 2, 3, 19.714078602875276 },
                    { 25, 1, 4, "Pongo spp.", "Lion", true, 3, 1, 11.241002845247055 },
                    { 26, 1, 3, "Vulpes zerda", "Red Panda", false, 0, 3, 81.068368168582438 },
                    { 27, 0, 3, "Giraffa camelopardalis", "African Wild Dog", false, 2, 3, 10.583627483738752 },
                    { 28, 1, 2, "Pteronura brasiliensis", "Bengal Tiger", true, 0, 0, 98.851422389896513 },
                    { 29, 1, 0, "Panthera onca", "Mandrill", false, 3, 0, 96.212415005781082 },
                    { 30, 0, 0, "Giraffa camelopardalis", "Gharial", false, 1, 4, 88.208860940973352 }
                });

            migrationBuilder.InsertData(
                table: "ZooModel",
                columns: new[] { "Id", "City", "Country", "Description", "Name" },
                values: new object[] { 1, "D'angeloport", "Congo", "one of my hobbies is scuba diving. and when i'm scuba diving this works great.", "Cartwright - Hammes" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ZooId" },
                values: new object[,]
                {
                    { 1, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Car", 1 },
                    { 2, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Shirt", 1 },
                    { 3, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Towels", 1 },
                    { 4, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Mouse", 1 },
                    { 5, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Chicken", 1 },
                    { 6, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Towels", 1 },
                    { 7, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Table", 1 },
                    { 8, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Table", 1 },
                    { 9, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Mouse", 1 },
                    { 10, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Cheese", 1 },
                    { 11, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Chicken", 1 },
                    { 12, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Salad", 1 },
                    { 13, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Tuna", 1 },
                    { 14, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Fish", 1 },
                    { 15, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Chips", 1 },
                    { 16, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Chicken", 1 },
                    { 17, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Chicken", 1 },
                    { 18, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Bacon", 1 },
                    { 19, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Salad", 1 },
                    { 20, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Ball", 1 },
                    { 21, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Towels", 1 },
                    { 22, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Pizza", 1 }
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Climate", "Habitat", "Name", "PredatorEnclosure", "PredatorSpeciesId", "SecurityRequired", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Hong Kong", false, 8, 0, 880.84451418594188, 1 },
                    { 2, 3, 1, "Rwanda", false, 14, 0, 851.95175872785546, 1 },
                    { 3, 2, 8, "Namibia", true, 19, 0, 551.77531366630365, 1 },
                    { 4, 0, 32, "Cocos (Keeling) Islands", false, 6, 1, 601.52449542055956, 1 },
                    { 5, 0, 1, "Belarus", true, 10, 0, 440.7104040192587, 1 },
                    { 6, 2, 32, "Greece", true, 24, 3, 911.75524335095861, 1 },
                    { 7, 4, 16, "Mexico", true, 8, 3, 338.88923959313342, 1 },
                    { 8, 3, 32, "Andorra", true, 29, 2, 277.38865291864528, 1 },
                    { 9, 2, 16, "Austria", false, 27, 1, 682.27273426556872, 1 },
                    { 10, 3, 8, "Norway", true, 10, 0, 385.19431073536879, 1 },
                    { 11, 4, 2, "Mauritius", true, 6, 3, 424.33784803973771, 1 },
                    { 12, 2, 4, "Palau", false, 12, 2, 225.16425291076726, 1 },
                    { 13, 0, 1, "Samoa", false, 19, 1, 637.08161665872785, 1 },
                    { 14, 4, 8, "Congo", true, 14, 0, 165.87353400557805, 1 },
                    { 15, 2, 1, "Republic of Korea", true, 26, 1, 222.11061809017065, 1 },
                    { 16, 1, 2, "Nepal", false, 14, 0, 911.40787776956802, 1 },
                    { 17, 4, 32, "Niue", true, 4, 3, 963.94093806019669, 1 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "EnclosureId", "Gender", "Name", "Personality", "PreferredDiet", "SpeciesId", "Weight", "ZooId" },
                values: new object[,]
                {
                    { 1, 13, 1, "Mervin", "plum", "[]", 13, 955.54505064485227, 1 },
                    { 2, 15, 1, "Cora", "white", "[]", 27, 480.00988215321206, 1 },
                    { 3, 12, 0, "Monte", "ivory", "[]", 8, 91.113705747955208, 1 },
                    { 4, 3, 1, "Pat", "blue", "[]", 22, 578.52254452952502, 1 },
                    { 5, 2, 1, "Merle", "fuchsia", "[]", 14, 631.44611895164439, 1 },
                    { 6, 12, 1, "Larry", "green", "[]", 18, 64.719676901463089, 1 },
                    { 7, 9, 0, "Maybelle", "salmon", "[]", 17, 525.02640826957304, 1 },
                    { 8, 1, 0, "Burley", "cyan", "[]", 7, 158.43397249381636, 1 },
                    { 9, 8, 1, "Carmella", "mint green", "[]", 22, 89.027411784877671, 1 },
                    { 10, 1, 1, "Dulce", "green", "[]", 25, 703.11554906556967, 1 },
                    { 11, 2, 0, "Sandrine", "red", "[]", 20, 857.53398872551293, 1 },
                    { 12, 11, 0, "Lisandro", "indigo", "[]", 16, 908.57393160709364, 1 },
                    { 13, 9, 1, "Olaf", "pink", "[]", 13, 879.72204781784683, 1 },
                    { 14, 3, 0, "Elyse", "fuchsia", "[]", 29, 384.27217982337902, 1 },
                    { 15, 14, 1, "Bridgette", "gold", "[]", 22, 420.61897553075391, 1 },
                    { 16, 7, 1, "Ruthie", "white", "[]", 23, 749.95351886242088, 1 },
                    { 17, 12, 1, "Josue", "plum", "[]", 26, 949.40907333048824, 1 },
                    { 18, 11, 0, "Lottie", "lime", "[]", 28, 917.12067436684993, 1 },
                    { 19, 1, 1, "Toney", "yellow", "[]", 21, 830.58016108535628, 1 },
                    { 20, 12, 1, "Josiane", "purple", "[]", 8, 854.14785751548334, 1 },
                    { 21, 17, 0, "Mac", "grey", "[]", 25, 410.68952251770423, 1 },
                    { 22, 17, 0, "Rocio", "gold", "[]", 4, 426.36068235352451, 1 },
                    { 23, 6, 1, "Mia", "blue", "[]", 30, 996.20374893821918, 1 },
                    { 24, 16, 0, "Jeffery", "salmon", "[]", 15, 843.6994533211855, 1 },
                    { 25, 4, 1, "Adriel", "indigo", "[]", 29, 898.30908373158638, 1 },
                    { 26, 7, 0, "Dena", "black", "[]", 13, 622.68374838021646, 1 },
                    { 27, 16, 1, "Quincy", "yellow", "[]", 26, 976.41819942979191, 1 },
                    { 28, 17, 0, "Shemar", "yellow", "[]", 30, 488.75278707357546, 1 },
                    { 29, 5, 0, "Wilmer", "grey", "[]", 22, 503.64438559214625, 1 },
                    { 30, 16, 0, "Garfield", "orchid", "[]", 28, 231.76651583082935, 1 },
                    { 31, 10, 1, "Stanley", "red", "[]", 24, 986.60228940433808, 1 },
                    { 32, 15, 0, "Henderson", "orchid", "[]", 9, 651.17959579716421, 1 },
                    { 33, 1, 1, "Skylar", "violet", "[]", 7, 657.06034269710517, 1 },
                    { 34, 15, 1, "Dorcas", "olive", "[]", 5, 21.742941701340797, 1 },
                    { 35, 13, 0, "Johanna", "sky blue", "[]", 2, 29.236927379378976, 1 },
                    { 36, 6, 0, "Kobe", "sky blue", "[]", 8, 498.85704938185125, 1 },
                    { 37, 14, 1, "Aletha", "tan", "[]", 7, 970.29339243484503, 1 },
                    { 38, 4, 0, "Alan", "silver", "[]", 2, 380.48611130316249, 1 },
                    { 39, 17, 1, "Enos", "fuchsia", "[]", 15, 260.35880567879281, 1 },
                    { 40, 5, 0, "Lane", "maroon", "[]", 14, 728.43166919067926, 1 },
                    { 41, 11, 1, "Amelie", "grey", "[]", 13, 266.63263485726975, 1 },
                    { 42, 5, 1, "Ward", "lavender", "[]", 27, 695.03678419539222, 1 },
                    { 43, 8, 1, "Maryam", "red", "[]", 21, 575.75497514103506, 1 },
                    { 44, 4, 0, "Herbert", "green", "[]", 20, 382.07793669890214, 1 },
                    { 45, 9, 1, "Ben", "plum", "[]", 18, 442.20946378554049, 1 },
                    { 46, 17, 1, "Jamal", "indigo", "[]", 5, 454.24424561504708, 1 },
                    { 47, 17, 0, "Elinore", "orchid", "[]", 22, 478.28693888688514, 1 },
                    { 48, 2, 0, "Kristopher", "grey", "[]", 14, 609.26578755106289, 1 },
                    { 49, 6, 1, "Quinten", "red", "[]", 30, 249.23161881433805, 1 },
                    { 50, 15, 1, "Charlie", "green", "[]", 24, 754.72475669120058, 1 },
                    { 51, 1, 1, "Twila", "yellow", "[]", 7, 267.31887191937267, 1 },
                    { 52, 15, 0, "Alexandria", "black", "[]", 18, 431.0097565913415, 1 },
                    { 53, 15, 1, "Armando", "orchid", "[]", 21, 971.1452951322874, 1 },
                    { 54, 6, 1, "Ezequiel", "ivory", "[]", 10, 925.72622650703931, 1 },
                    { 55, 3, 0, "Hollie", "teal", "[]", 27, 566.03428483003108, 1 },
                    { 56, 2, 1, "Ivory", "cyan", "[]", 27, 752.85831790149268, 1 },
                    { 57, 9, 0, "Evelyn", "salmon", "[]", 22, 135.10563433896377, 1 },
                    { 58, 9, 0, "Devan", "tan", "[]", 27, 981.26312391598037, 1 },
                    { 59, 7, 0, "Omari", "grey", "[]", 23, 10.76240532938086, 1 },
                    { 60, 8, 1, "Helene", "azure", "[]", 24, 164.23825719010026, 1 },
                    { 61, 5, 0, "Jimmy", "violet", "[]", 26, 970.92271271762195, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EnclosureId",
                table: "Animal",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SpeciesId",
                table: "Animal",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ZooId",
                table: "Animal",
                column: "ZooId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ZooId",
                table: "Category",
                column: "ZooId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySpecies_SpeciesId",
                table: "CategorySpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Enclosures_PredatorSpeciesId",
                table: "Enclosures",
                column: "PredatorSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Enclosures_ZooId",
                table: "Enclosures",
                column: "ZooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "CategorySpecies");

            migrationBuilder.DropTable(
                name: "Enclosures");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "ZooModel");
        }
    }
}
