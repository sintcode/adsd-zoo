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
                    { 1, 2, 4, "Hylobatidae spp.", "Koala", false, 2, 4, 68.222552281930078 },
                    { 2, 0, 2, "Aptenodytes forsteri", "Sloth", false, 0, 3, 33.242434547129974 },
                    { 3, 2, 2, "Mandrillus sphinx", "Golden Lion Tamarin", true, 0, 2, 89.347231329436198 },
                    { 4, 1, 4, "Ara ararauna", "Black Rhinoceros", true, 3, 5, 71.797261108894105 },
                    { 5, 2, 0, "Tremarctos ornatus", "White Rhinoceros", false, 2, 0, 59.895704503207092 },
                    { 6, 1, 1, "Ailuropoda melanoleuca", "Spectacled Bear", true, 0, 1, 26.447948249786776 },
                    { 7, 2, 1, "Ailurus fulgens", "American Alligator", false, 2, 4, 97.582987921970556 },
                    { 8, 1, 1, "Ailuropoda melanoleuca", "African Wildcat", true, 1, 5, 14.608120933596958 },
                    { 9, 1, 3, "Trichechus inunguis", "Goliath Frog", false, 3, 0, 77.166847546186077 },
                    { 10, 2, 1, "Panthera uncia", "Red River Hog", true, 2, 1, 11.091505302446109 },
                    { 11, 1, 1, "Gorilla beringei", "White-Tailed Deer", true, 3, 5, 60.594695090837924 },
                    { 12, 0, 2, "Spheniscus humboldti", "Plains Zebra", false, 0, 2, 61.874809154198225 },
                    { 13, 1, 0, "Cebus spp.", "Black Bear", false, 3, 0, 77.485461372106798 },
                    { 14, 1, 1, "Acinonyx jubatus", "Red River Hog", true, 3, 4, 44.803651369919223 },
                    { 15, 0, 1, "Varanus komodoensis", "Capuchin Monkey", false, 2, 5, 16.193818496215471 },
                    { 16, 1, 0, "Gorilla gorilla gorilla", "Galapagos Tortoise", true, 1, 4, 67.89606033791793 },
                    { 17, 1, 1, "Panthera tigris tigris", "Siamang", false, 3, 4, 22.269711428472593 }
                });

            migrationBuilder.InsertData(
                table: "ZooModel",
                columns: new[] { "Id", "City", "Country", "Description", "Name" },
                values: new object[] { 1, "Dandrechester", "Nicaragua", "Sit expedita iste est dolores.", "Gibson - Kub" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ZooId" },
                values: new object[,]
                {
                    { 1, "Sed accusamus cupiditate qui natus aspernatur debitis qui officia aut.", "similique", 1 },
                    { 2, "Dolor omnis eos consequatur nisi quisquam nihil dolore quisquam blanditiis.", "recusandae", 1 },
                    { 3, "Qui ipsa dolores eum qui laudantium non porro maxime dicta.", "quia", 1 },
                    { 4, "Vero animi ut consectetur fugiat nihil distinctio cum labore cupiditate.", "explicabo", 1 },
                    { 5, "Sint modi mollitia tempora at iure sit temporibus illo id.", "et", 1 },
                    { 6, "Exercitationem et ea dolore non et ad saepe sapiente quaerat.", "perspiciatis", 1 },
                    { 7, "Minima illo illo quo et voluptatibus ea laboriosam provident laboriosam.", "possimus", 1 },
                    { 8, "Nam necessitatibus inventore quae ut natus excepturi vero et vitae.", "excepturi", 1 },
                    { 9, "Rerum cumque ad deleniti eligendi doloribus sed non quidem fugit.", "sed", 1 },
                    { 10, "Corporis rerum ullam quia sunt iusto non exercitationem consequatur sint.", "laboriosam", 1 },
                    { 11, "Impedit sapiente hic ut modi est vero eligendi eveniet voluptatem.", "facere", 1 },
                    { 12, "Nesciunt id nam magni accusamus optio voluptatibus ratione omnis commodi.", "et", 1 },
                    { 13, "Quo omnis dolorum assumenda ipsum magni architecto delectus consequatur ea.", "aut", 1 },
                    { 14, "A qui eius atque voluptas at natus perferendis porro aliquam.", "expedita", 1 },
                    { 15, "Impedit sapiente sed molestiae sit dolores quis sapiente iusto velit.", "illo", 1 },
                    { 16, "Dignissimos laborum dolorem adipisci hic enim minus dignissimos voluptatibus excepturi.", "pariatur", 1 }
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Climate", "Habitat", "Name", "PredatorEnclosure", "PredatorSpeciesId", "SecurityRequired", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 4, 32, "iusto", false, 14, 0, 164.04346789189742, 1 },
                    { 2, 4, 16, "quis", false, 8, 0, 925.48451868484187, 1 },
                    { 3, 0, 8, "reiciendis", true, 2, 0, 724.94404095978632, 1 },
                    { 4, 3, 32, "minima", true, 16, 2, 949.29909397392964, 1 },
                    { 5, 3, 8, "laborum", true, 3, 2, 571.54021628702935, 1 },
                    { 6, 3, 32, "magni", false, 15, 1, 992.60645128947749, 1 },
                    { 7, 4, 16, "dignissimos", false, 1, 1, 619.46179924021214, 1 },
                    { 8, 3, 8, "ut", false, 4, 1, 820.72005837068957, 1 },
                    { 9, 1, 16, "sunt", true, 11, 0, 224.80451108390236, 1 },
                    { 10, 1, 32, "fuga", true, 15, 2, 248.37510521887702, 1 },
                    { 11, 1, 8, "et", true, 11, 1, 185.01608535899356, 1 },
                    { 12, 0, 32, "necessitatibus", false, 6, 1, 471.28694725658102, 1 },
                    { 13, 0, 2, "illum", true, 16, 1, 152.87086977106222, 1 },
                    { 14, 0, 64, "deserunt", true, 17, 0, 262.21969692400029, 1 },
                    { 15, 1, 32, "ut", true, 8, 0, 467.80714565528393, 1 },
                    { 16, 2, 8, "et", true, 1, 1, 227.8022432045978, 1 },
                    { 17, 3, 16, "saepe", true, 11, 3, 384.7940124817149, 1 },
                    { 18, 3, 8, "dolor", true, 5, 2, 130.48307553709083, 1 },
                    { 19, 4, 64, "deserunt", false, 6, 0, 539.55276666639736, 1 },
                    { 20, 1, 32, "dolores", true, 7, 1, 284.97968513297053, 1 },
                    { 21, 4, 2, "praesentium", false, 15, 2, 243.87339475390567, 1 },
                    { 22, 3, 4, "aut", false, 17, 0, 627.42766231742178, 1 },
                    { 23, 1, 4, "tenetur", false, 16, 3, 586.40116632976321, 1 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "EnclosureId", "Gender", "Name", "Personality", "PreferredDiet", "SpeciesId", "Weight", "ZooId" },
                values: new object[,]
                {
                    { 1, 7, 0, "Juwan", "red", "[]", 6, 770.43921588456078, 1 },
                    { 2, 14, 1, "Joel", "cyan", "[]", 8, 324.83921302471271, 1 },
                    { 3, 21, 0, "Terrance", "white", "[]", 3, 172.91626549195399, 1 },
                    { 4, 11, 0, "Devin", "lavender", "[]", 6, 81.69294725307995, 1 },
                    { 5, 12, 1, "Mylene", "ivory", "[]", 7, 923.53142513173555, 1 },
                    { 6, 9, 0, "Reid", "black", "[]", 8, 33.58784554949321, 1 },
                    { 7, 6, 0, "Beulah", "magenta", "[]", 16, 714.26192512849673, 1 },
                    { 8, 6, 1, "Sven", "azure", "[]", 14, 159.19456692233697, 1 },
                    { 9, 5, 0, "Madisyn", "sky blue", "[]", 2, 980.32049214587971, 1 },
                    { 10, 1, 1, "Sabrina", "silver", "[]", 11, 775.72359527862102, 1 },
                    { 11, 23, 1, "Rylan", "sky blue", "[]", 8, 968.6819243291186, 1 },
                    { 12, 1, 1, "Raquel", "sky blue", "[]", 15, 117.47190016503384, 1 },
                    { 13, 6, 1, "Janet", "orchid", "[]", 1, 239.52794279700672, 1 },
                    { 14, 14, 1, "Keara", "orange", "[]", 9, 175.17142335845435, 1 },
                    { 15, 1, 0, "Jerad", "ivory", "[]", 15, 645.2166605889679, 1 },
                    { 16, 2, 0, "Lacy", "violet", "[]", 5, 580.48708777896616, 1 },
                    { 17, 21, 1, "Camilla", "plum", "[]", 4, 965.60004227360935, 1 },
                    { 18, 2, 0, "Unique", "lime", "[]", 1, 49.570340618931411, 1 },
                    { 19, 23, 1, "Destiny", "azure", "[]", 3, 227.64016287885684, 1 },
                    { 20, 6, 1, "Tia", "plum", "[]", 7, 567.48026872222556, 1 },
                    { 21, 16, 1, "Chandler", "indigo", "[]", 3, 355.86415464176417, 1 },
                    { 22, 6, 1, "Judy", "yellow", "[]", 15, 54.774409449140158, 1 },
                    { 23, 16, 0, "Tad", "orange", "[]", 1, 178.57630819452459, 1 },
                    { 24, 17, 1, "Austin", "turquoise", "[]", 13, 914.5610344240614, 1 },
                    { 25, 8, 0, "Dawson", "azure", "[]", 16, 32.598700610561963, 1 },
                    { 26, 23, 1, "Eveline", "turquoise", "[]", 16, 118.4380769244423, 1 },
                    { 27, 16, 1, "Melissa", "salmon", "[]", 4, 689.93358086890839, 1 },
                    { 28, 16, 0, "Carol", "fuchsia", "[]", 4, 872.800996169825, 1 },
                    { 29, 15, 0, "Clifton", "lavender", "[]", 6, 159.32035601740108, 1 },
                    { 30, 6, 0, "Charles", "silver", "[]", 10, 904.40822489346056, 1 },
                    { 31, 16, 1, "Richard", "teal", "[]", 15, 906.44707505750307, 1 },
                    { 32, 19, 1, "Leda", "orange", "[]", 4, 330.34316868532022, 1 },
                    { 33, 23, 1, "Coby", "blue", "[]", 14, 661.54804445511286, 1 },
                    { 34, 18, 0, "Reyna", "pink", "[]", 6, 741.81025880914126, 1 },
                    { 35, 9, 0, "Eda", "plum", "[]", 13, 912.82588666268487, 1 },
                    { 36, 16, 1, "Margarita", "green", "[]", 12, 881.35571939039221, 1 },
                    { 37, 18, 0, "Dessie", "green", "[]", 15, 97.013370914228233, 1 },
                    { 38, 7, 1, "Frida", "azure", "[]", 5, 21.319800763874536, 1 },
                    { 39, 8, 1, "Kellie", "teal", "[]", 11, 397.22791687862474, 1 },
                    { 40, 2, 1, "Bethany", "white", "[]", 4, 209.05904033088777, 1 },
                    { 41, 12, 1, "Marisol", "lavender", "[]", 3, 519.81911011584396, 1 },
                    { 42, 17, 0, "Rafael", "sky blue", "[]", 14, 37.893575953495706, 1 },
                    { 43, 4, 0, "Susan", "lavender", "[]", 5, 973.89274547991272, 1 },
                    { 44, 3, 0, "Chelsie", "mint green", "[]", 9, 203.03350248204271, 1 },
                    { 45, 19, 0, "Jedidiah", "ivory", "[]", 2, 212.33614075108522, 1 },
                    { 46, 14, 0, "Kane", "olive", "[]", 4, 640.33842850091321, 1 },
                    { 47, 10, 1, "Theresa", "grey", "[]", 16, 491.92162001147148, 1 },
                    { 48, 1, 0, "Amira", "yellow", "[]", 15, 573.93254925395831, 1 },
                    { 49, 9, 1, "Johnathan", "plum", "[]", 16, 516.22294430773968, 1 },
                    { 50, 7, 0, "Ken", "plum", "[]", 10, 860.80651536707467, 1 },
                    { 51, 15, 1, "Jacky", "orchid", "[]", 14, 662.4528541227254, 1 },
                    { 52, 21, 1, "Arvid", "turquoise", "[]", 11, 932.06808232144488, 1 },
                    { 53, 4, 1, "Justus", "teal", "[]", 2, 950.84875135421032, 1 },
                    { 54, 4, 1, "Alexandre", "tan", "[]", 3, 922.91747972691394, 1 },
                    { 55, 7, 0, "Maida", "cyan", "[]", 16, 985.97829486397256, 1 },
                    { 56, 9, 1, "Reta", "grey", "[]", 5, 814.01882319890956, 1 },
                    { 57, 17, 0, "Viva", "pink", "[]", 3, 947.42877459712781, 1 },
                    { 58, 22, 1, "Shania", "mint green", "[]", 8, 574.96602688388862, 1 },
                    { 59, 6, 1, "Cortez", "teal", "[]", 4, 105.48258791956631, 1 },
                    { 60, 7, 1, "Cordell", "sky blue", "[]", 11, 413.76282829905307, 1 },
                    { 61, 19, 0, "Keshaun", "salmon", "[]", 16, 157.84982573720299, 1 },
                    { 62, 17, 1, "Kattie", "purple", "[]", 10, 79.66670091422165, 1 },
                    { 63, 21, 1, "Emmitt", "salmon", "[]", 15, 582.97771969103985, 1 },
                    { 64, 4, 0, "Bryce", "silver", "[]", 4, 753.83760336945784, 1 },
                    { 65, 18, 1, "Imelda", "grey", "[]", 9, 498.34078580605285, 1 },
                    { 66, 1, 0, "Winfield", "lavender", "[]", 11, 164.13817728570575, 1 },
                    { 67, 3, 0, "Sid", "lavender", "[]", 9, 205.41193051004441, 1 },
                    { 68, 13, 0, "Maida", "blue", "[]", 14, 929.46023679351163, 1 },
                    { 69, 2, 1, "Tomas", "fuchsia", "[]", 4, 206.58144470464285, 1 },
                    { 70, 18, 1, "Webster", "white", "[]", 3, 825.73382781925329, 1 },
                    { 71, 19, 1, "Merle", "mint green", "[]", 8, 493.20008717245946, 1 },
                    { 72, 4, 0, "Stacey", "indigo", "[]", 9, 148.34480559729727, 1 },
                    { 73, 2, 0, "Hillary", "black", "[]", 13, 398.59457082432857, 1 },
                    { 74, 16, 1, "Toni", "lavender", "[]", 13, 665.34907555359678, 1 },
                    { 75, 5, 1, "Deven", "ivory", "[]", 3, 304.81422544759965, 1 },
                    { 76, 16, 1, "Israel", "lime", "[]", 15, 3.3033548844260845, 1 },
                    { 77, 11, 0, "Yasmine", "turquoise", "[]", 3, 217.09617293904688, 1 },
                    { 78, 6, 0, "Fidel", "lime", "[]", 10, 218.12858717296768, 1 },
                    { 79, 14, 0, "Chasity", "lime", "[]", 14, 735.03878103586726, 1 },
                    { 80, 9, 0, "Jaclyn", "fuchsia", "[]", 3, 937.27304233087762, 1 },
                    { 81, 8, 0, "Litzy", "orange", "[]", 2, 326.93058760531665, 1 },
                    { 82, 12, 1, "Lucio", "black", "[]", 7, 773.95838179394036, 1 },
                    { 83, 22, 0, "Elvis", "olive", "[]", 7, 498.34972006918377, 1 },
                    { 84, 2, 1, "Gia", "indigo", "[]", 10, 136.94229419003386, 1 },
                    { 85, 6, 0, "Libbie", "cyan", "[]", 13, 403.35062788285427, 1 },
                    { 86, 15, 1, "Casimir", "black", "[]", 15, 417.23319766075912, 1 },
                    { 87, 17, 0, "Kali", "gold", "[]", 14, 573.16862454321779, 1 },
                    { 88, 19, 1, "Alysha", "orchid", "[]", 17, 554.40272698872616, 1 },
                    { 89, 17, 0, "Troy", "purple", "[]", 17, 175.73308781684605, 1 },
                    { 90, 6, 1, "Christina", "cyan", "[]", 11, 240.2312437581291, 1 },
                    { 91, 2, 0, "Clinton", "plum", "[]", 10, 288.84572522836345, 1 },
                    { 92, 16, 0, "Karlie", "blue", "[]", 15, 517.2513146449603, 1 },
                    { 93, 2, 0, "Lavern", "maroon", "[]", 11, 927.97806030997731, 1 },
                    { 94, 15, 0, "Tia", "tan", "[]", 15, 602.05155649595395, 1 }
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
