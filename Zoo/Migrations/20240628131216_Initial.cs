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
                        onDelete: ReferentialAction.Cascade);
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
                    PredatorSpeciesId = table.Column<int>(type: "int", nullable: true),
                    ZooId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enclosures_Species_PredatorSpeciesId",
                        column: x => x.PredatorSpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enclosures_ZooModel_ZooId",
                        column: x => x.ZooId,
                        principalTable: "ZooModel",
                        principalColumn: "Id");
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
                    EnclosureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animal_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_ZooModel_ZooId",
                        column: x => x.ZooId,
                        principalTable: "ZooModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Activity", "Diet", "LatinName", "Name", "Predator", "SecurityRequired", "Size", "SpaceRequired" },
                values: new object[,]
                {
                    { 1, 2, 0, "Crocodylus niloticus", "Toucan", true, 1, 2, 26.265220187351421 },
                    { 2, 0, 3, "Phascolarctos cinereus", "Fox", false, 2, 0, 31.860472652956048 },
                    { 3, 2, 0, "Panthera leo", "Chameleon", true, 1, 0, 62.489454896109741 },
                    { 4, 0, 4, "Chamaeleo chamaeleon", "Lion", false, 2, 3, 18.005875061787584 },
                    { 5, 2, 4, "Loxodonta africana", "Jaguar", true, 1, 1, 18.96651192974354 },
                    { 6, 2, 4, "Bradypus variegatus", "Chameleon", false, 3, 0, 95.789928874054667 },
                    { 7, 2, 4, "Ursus arctos", "Gorilla", true, 0, 5, 99.663988367476762 },
                    { 8, 2, 2, "Equus quagga", "Penguin", false, 0, 5, 30.689674688602633 },
                    { 9, 2, 0, "Loxodonta africana", "Kangaroo", true, 1, 5, 88.493456828554429 },
                    { 10, 0, 3, "Diceros bicornis", "Koala", true, 0, 2, 80.535567838518332 },
                    { 11, 1, 2, "Suricata suricatta", "Meerkat", true, 0, 2, 41.590371195477822 },
                    { 12, 1, 1, "Panthera tigris", "Kangaroo", true, 1, 0, 53.598798018464464 },
                    { 13, 2, 1, "Gorilla beringei", "Fox", false, 3, 4, 46.661610839769594 },
                    { 14, 1, 1, "Vulpes vulpes", "Crocodile", false, 2, 4, 29.947167983984883 },
                    { 15, 2, 1, "Diceros bicornis", "Pangolin", true, 0, 3, 97.151060150544552 },
                    { 16, 0, 4, "Hippopotamus amphibius", "Fox", true, 0, 4, 42.337182267485687 },
                    { 17, 0, 4, "Hippopotamus amphibius", "Chameleon", false, 2, 3, 58.483152235198887 },
                    { 18, 2, 0, "Puma concolor", "Lion", false, 2, 4, 94.566381516379963 },
                    { 19, 0, 4, "Puma concolor", "Elephant", true, 0, 4, 12.991760782913598 },
                    { 20, 1, 1, "Puma concolor", "Chameleon", false, 0, 3, 86.568349547555897 },
                    { 21, 1, 3, "Ursus arctos", "Tiger", true, 0, 2, 80.338496868389853 },
                    { 22, 0, 0, "Ramphastos toco", "Lion", true, 1, 4, 69.281953786552819 },
                    { 23, 2, 1, "Ramphastos toco", "Fox", true, 0, 1, 78.886521232476852 },
                    { 24, 0, 4, "Hippopotamus amphibius", "Panda", true, 1, 4, 99.935645162497735 },
                    { 25, 2, 4, "Canis lupus", "Zebra", false, 0, 4, 64.205178167988606 }
                });

            migrationBuilder.InsertData(
                table: "ZooModel",
                columns: new[] { "Id", "City", "Country", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Hesterberg", "United States of America", "Quibusdam suscipit dolores laboriosam in.", "Erdman and Sons" },
                    { 2, "North Fabianland", "Uganda", "Facilis perferendis quos ad commodi.", "Cummings, Kuhlman and Willms" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ZooId" },
                values: new object[,]
                {
                    { 1, "Quia sapiente labore maiores consequatur praesentium quos eos sed recusandae.", "impedit", 1 },
                    { 2, "Deserunt magni aut sunt culpa quia iure blanditiis debitis consequatur.", "ex", 1 },
                    { 3, "Vitae deleniti aut illo perspiciatis laborum doloremque enim aut voluptatem.", "corrupti", 1 },
                    { 4, "Ut et vel voluptas qui voluptates quia ut ipsam fuga.", "similique", 1 },
                    { 5, "Enim velit aperiam cum omnis est error molestias libero quis.", "quo", 1 },
                    { 6, "Voluptas accusantium eius fugiat qui sit officia ut ipsum quo.", "earum", 2 },
                    { 7, "Dolores molestias nihil natus qui ipsa id exercitationem qui et.", "voluptates", 1 },
                    { 8, "Dolores sed sit commodi id quod sunt qui enim omnis.", "asperiores", 1 },
                    { 9, "Libero illum error sit maxime architecto laboriosam sunt doloribus fugit.", "dolorem", 1 },
                    { 10, "Cum provident quibusdam repudiandae aut consequatur cupiditate natus architecto voluptates.", "sed", 1 },
                    { 11, "Odio et explicabo in magni repudiandae dolorem doloribus modi sed.", "quidem", 1 },
                    { 12, "Unde ut earum aut praesentium non fugiat excepturi ut libero.", "placeat", 2 },
                    { 13, "Enim rem perferendis hic ea fugit distinctio sunt ipsa quisquam.", "nisi", 2 },
                    { 14, "Voluptas quibusdam similique qui in facere nihil hic nobis unde.", "officiis", 2 },
                    { 15, "Ut vero architecto deserunt quo nobis voluptatem qui rem odio.", "rem", 2 },
                    { 16, "Qui quas cupiditate non nisi fugiat sapiente autem officiis id.", "aut", 1 },
                    { 17, "Aspernatur dolorem velit accusantium non libero voluptatibus distinctio occaecati qui.", "sapiente", 1 },
                    { 18, "Eum rerum dolorem et pariatur illum voluptas et vitae et.", "aut", 1 },
                    { 19, "Ullam labore impedit velit quod nam animi aut mollitia explicabo.", "officiis", 1 },
                    { 20, "Optio sunt perspiciatis voluptatem nobis reprehenderit soluta laboriosam alias qui.", "facere", 2 },
                    { 21, "Dolorem incidunt sunt et dolores nulla illum velit nihil et.", "rem", 2 },
                    { 22, "Sint facilis et eaque occaecati sint quam porro officia harum.", "tempore", 1 },
                    { 23, "Saepe nostrum officia repudiandae saepe amet officia iure expedita incidunt.", "non", 1 },
                    { 24, "Praesentium ex aut tenetur sint dignissimos illo velit sed quis.", "vel", 2 },
                    { 25, "Quidem aut qui nam maiores autem iusto voluptatem quo voluptatem.", "modi", 1 }
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Climate", "Habitat", "Name", "PredatorEnclosure", "PredatorSpeciesId", "SecurityRequired", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 2, 32, "maxime", true, 10, 0, 739.14117660645536, 2 },
                    { 2, 4, 64, "ratione", true, 15, 0, 290.66013764848117, 1 },
                    { 3, 2, 16, "et", false, 18, 2, 816.99306410165514, 2 },
                    { 4, 0, 16, "dignissimos", false, 11, 1, 298.20218968918215, 2 },
                    { 5, 1, 4, "est", true, 13, 0, 892.7911638665521, 1 },
                    { 6, 1, 4, "rem", false, 7, 1, 565.06147664013815, 2 },
                    { 7, 4, 32, "et", false, 12, 2, 261.77816976129571, 2 },
                    { 8, 4, 8, "vero", true, 12, 2, 943.42953697461292, 1 },
                    { 9, 4, 8, "officiis", false, 18, 0, 974.29656399582507, 1 },
                    { 10, 4, 4, "sed", true, 1, 2, 549.18105871867294, 2 },
                    { 11, 3, 32, "dicta", false, 20, 1, 531.51722324512752, 2 },
                    { 12, 0, 4, "ex", false, 4, 1, 535.91156757817271, 1 },
                    { 13, 3, 32, "labore", false, 17, 2, 758.72320953566179, 1 },
                    { 14, 0, 4, "et", true, 25, 1, 994.90559536546948, 1 },
                    { 15, 4, 8, "aut", false, 14, 0, 999.44367061607329, 1 },
                    { 16, 3, 32, "esse", true, 13, 1, 798.58878076463384, 1 },
                    { 17, 4, 1, "occaecati", false, 1, 0, 398.70315091848965, 2 },
                    { 18, 4, 16, "perspiciatis", false, 8, 0, 553.22519368490714, 1 },
                    { 19, 0, 32, "adipisci", true, 11, 2, 131.19063911747622, 1 },
                    { 20, 0, 1, "voluptas", true, 9, 1, 101.01454371040934, 2 },
                    { 21, 0, 1, "praesentium", true, 20, 0, 345.19538992076968, 1 },
                    { 22, 4, 2, "id", false, 9, 2, 933.33741540363246, 2 },
                    { 23, 0, 4, "aut", false, 7, 2, 357.87812210291122, 1 },
                    { 24, 3, 32, "non", false, 15, 2, 347.69429511964432, 2 },
                    { 25, 0, 1, "fugit", true, 10, 0, 863.70056503028093, 1 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "EnclosureId", "Gender", "Name", "Personality", "PreferredDiet", "SpeciesId", "Weight", "ZooId" },
                values: new object[,]
                {
                    { 1, 9, 1, "Tre", "Winona", "ab", 19, 417.57281798920246, 1 },
                    { 2, 23, 0, "Ezekiel", "Eulalia", "a", 25, 815.98435927800051, 2 },
                    { 3, 10, 1, "Jessyca", "Salma", "sapiente", 12, 721.83488853471715, 1 },
                    { 4, 11, 0, "Alexandrine", "Julia", "saepe", 15, 210.87323460397315, 1 },
                    { 5, 22, 1, "Destany", "Kendrick", "voluptatem", 6, 641.91768883000304, 2 },
                    { 6, 10, 0, "Tyson", "Desiree", "vel", 14, 665.70962448646605, 1 },
                    { 7, 1, 0, "Margarita", "Tony", "molestiae", 23, 417.37804352687544, 1 },
                    { 8, 22, 0, "Melyna", "Bryon", "aspernatur", 22, 501.76167923731902, 1 },
                    { 9, 17, 1, "Daryl", "Camren", "assumenda", 18, 241.74392120140982, 1 },
                    { 10, 25, 1, "Stone", "Alverta", "impedit", 15, 515.05365393158752, 1 },
                    { 11, 18, 1, "Doyle", "Tito", "eos", 5, 428.92397565770773, 2 },
                    { 12, 13, 1, "Harrison", "Gianni", "nulla", 11, 480.75350180712292, 2 },
                    { 13, 22, 0, "Daisha", "Ida", "vero", 13, 957.17396537914135, 2 },
                    { 14, 12, 0, "Cayla", "Reva", "sint", 10, 961.21940422540627, 1 },
                    { 15, 21, 0, "Emery", "Kyla", "est", 13, 506.30727382070899, 2 },
                    { 16, 17, 0, "Ivy", "Keeley", "aut", 3, 954.48089392191764, 1 },
                    { 17, 16, 1, "Estelle", "Emerald", "omnis", 15, 239.90378845742123, 2 },
                    { 18, 10, 0, "Pearline", "Vesta", "nam", 3, 122.97417102846829, 2 },
                    { 19, 12, 1, "Melba", "Maddison", "itaque", 6, 568.73404773975756, 2 },
                    { 20, 18, 1, "Novella", "Jasper", "quis", 23, 744.92792915732173, 1 },
                    { 21, 19, 1, "Paris", "Gail", "nam", 1, 568.64896161335582, 1 },
                    { 22, 12, 0, "Alvena", "Cecile", "voluptate", 8, 152.78184149692169, 2 },
                    { 23, 25, 1, "Darrion", "Velva", "animi", 21, 881.24014090216917, 2 },
                    { 24, 2, 0, "Adolfo", "Caleb", "fugiat", 23, 135.47559532029311, 2 },
                    { 25, 7, 1, "Collin", "Jaylin", "et", 7, 169.1017460855748, 2 },
                    { 26, 10, 0, "Antwan", "Lilian", "voluptatum", 13, 374.07152090890003, 2 },
                    { 27, 21, 1, "Cayla", "Julian", "porro", 5, 352.7969952371638, 1 },
                    { 28, 4, 0, "Adrien", "Bailey", "ullam", 22, 187.53713855231032, 1 },
                    { 29, 7, 1, "Devyn", "Cynthia", "earum", 4, 563.45683794562717, 2 },
                    { 30, 15, 1, "Aaron", "Vicky", "molestias", 12, 742.00323463910001, 2 },
                    { 31, 5, 0, "Davion", "Kenna", "veritatis", 21, 824.99335848312444, 2 },
                    { 32, 22, 0, "Brannon", "Karianne", "qui", 20, 597.95568319700567, 2 },
                    { 33, 4, 0, "Myah", "Carissa", "praesentium", 24, 979.10842881058568, 1 },
                    { 34, 1, 1, "Duane", "Robyn", "iure", 1, 895.92522508477168, 2 },
                    { 35, 19, 1, "Hilda", "Ed", "rerum", 25, 26.961195020253317, 2 },
                    { 36, 16, 1, "Jamel", "Violette", "aut", 22, 508.03508299116976, 2 },
                    { 37, 18, 0, "Haley", "Olga", "iste", 18, 567.49883771065777, 1 },
                    { 38, 24, 0, "Kaitlyn", "Jewel", "dolorem", 9, 138.06514507065151, 1 },
                    { 39, 11, 1, "Esteban", "Ulices", "cum", 14, 711.25888368915003, 2 },
                    { 40, 12, 1, "Dedric", "Lelia", "dolorem", 24, 267.43802218087825, 1 },
                    { 41, 25, 1, "Fredy", "Wilson", "voluptatibus", 7, 593.86866893888225, 2 },
                    { 42, 3, 0, "Jerome", "Einar", "et", 3, 993.98901477182733, 2 },
                    { 43, 11, 0, "Lorena", "Javon", "officia", 18, 519.32607825869184, 1 },
                    { 44, 2, 0, "Una", "Waylon", "est", 11, 279.13041176630418, 1 },
                    { 45, 12, 1, "Marianna", "Amiya", "praesentium", 23, 421.70991409334806, 2 },
                    { 46, 24, 1, "Maudie", "Howell", "maiores", 25, 234.32013599149712, 2 },
                    { 47, 2, 1, "Florine", "Deon", "corrupti", 13, 334.4332111043301, 2 },
                    { 48, 1, 1, "Prudence", "Jacques", "et", 14, 636.41280965164231, 2 },
                    { 49, 1, 1, "Yasmin", "Kailyn", "quia", 14, 25.340012376290993, 1 },
                    { 50, 1, 0, "Mabelle", "Madelyn", "quas", 13, 635.79369425270977, 2 },
                    { 51, 11, 0, "Anthony", "Rocky", "cupiditate", 15, 872.968602151391, 2 },
                    { 52, 17, 1, "Tillman", "Xzavier", "eum", 14, 940.79482447515045, 1 },
                    { 53, 1, 1, "William", "Janick", "aut", 13, 114.13077909170514, 2 },
                    { 54, 22, 0, "Bessie", "Carissa", "quo", 19, 969.65887307250932, 2 },
                    { 55, 1, 0, "Laverne", "Ismael", "rerum", 8, 838.72223726086952, 2 },
                    { 56, 12, 0, "Keyon", "Augustus", "quis", 3, 327.81627743895217, 1 },
                    { 57, 17, 0, "Donna", "Patricia", "excepturi", 13, 242.63359572966863, 1 },
                    { 58, 13, 0, "Schuyler", "Adam", "voluptates", 5, 140.57536597982349, 2 },
                    { 59, 5, 1, "Murray", "Marietta", "voluptatem", 9, 45.159556334491789, 2 },
                    { 60, 20, 1, "Kyra", "Gabrielle", "voluptatibus", 1, 499.26101626569209, 2 },
                    { 61, 14, 1, "Erik", "Burnice", "ipsam", 23, 261.47679231662147, 1 },
                    { 62, 10, 1, "D'angelo", "Autumn", "omnis", 17, 530.80326657876401, 1 },
                    { 63, 3, 1, "Bulah", "Lawrence", "aut", 16, 526.90167515966959, 1 },
                    { 64, 9, 0, "Isaac", "Jamaal", "dignissimos", 23, 663.92035962518844, 1 },
                    { 65, 1, 1, "Wilburn", "Schuyler", "facilis", 12, 642.07117492801819, 1 },
                    { 66, 25, 0, "Josianne", "Clare", "sunt", 1, 34.005131141671484, 2 },
                    { 67, 19, 1, "Esther", "Buford", "eum", 15, 546.4197261663694, 2 },
                    { 68, 5, 1, "Avis", "Cora", "rem", 15, 275.67698448262655, 1 },
                    { 69, 1, 0, "Rahul", "Mack", "ab", 10, 547.34195193200651, 1 },
                    { 70, 5, 0, "Mariela", "Faye", "quasi", 23, 796.98526232513211, 1 },
                    { 71, 9, 0, "Beau", "Mervin", "sit", 4, 358.45742108987594, 2 },
                    { 72, 10, 1, "Francesco", "Thelma", "quis", 23, 895.60520303931878, 2 },
                    { 73, 5, 1, "Dylan", "Brock", "ea", 9, 155.57270878800966, 1 },
                    { 74, 9, 1, "Chelsea", "Sheridan", "in", 1, 917.00670023474481, 1 },
                    { 75, 3, 1, "Naomi", "Anika", "quam", 15, 937.437552724856, 2 },
                    { 76, 25, 0, "Margot", "Angeline", "tenetur", 19, 286.35590842331453, 1 },
                    { 77, 1, 1, "Travon", "Alanis", "incidunt", 6, 508.02877502412838, 1 },
                    { 78, 14, 0, "Jeromy", "Chaim", "voluptas", 21, 672.76438323437435, 2 },
                    { 79, 4, 0, "Ariel", "Eloy", "temporibus", 7, 822.37751072449805, 2 },
                    { 80, 13, 1, "Maurice", "Dixie", "nulla", 22, 395.70780683391104, 2 },
                    { 81, 22, 1, "Elmo", "Lysanne", "recusandae", 6, 954.00789222292951, 1 },
                    { 82, 12, 0, "Jacky", "Alfonso", "aut", 15, 928.29145441694823, 1 },
                    { 83, 10, 1, "Fletcher", "Gillian", "voluptate", 24, 474.12028968247154, 2 },
                    { 84, 19, 0, "Alejandrin", "Kelton", "nulla", 3, 629.08061988150894, 2 },
                    { 85, 9, 0, "Lorenz", "Lavinia", "quia", 23, 260.75152364578889, 1 },
                    { 86, 12, 1, "Annalise", "Katlynn", "eos", 11, 667.35110831724444, 2 },
                    { 87, 4, 0, "Jayme", "Marvin", "iure", 5, 23.018832861395399, 1 },
                    { 88, 7, 0, "Miracle", "Reginald", "quia", 18, 776.90767706020165, 2 },
                    { 89, 21, 0, "Neal", "Niko", "modi", 14, 244.7696809641364, 1 },
                    { 90, 13, 0, "Carolina", "Rex", "perferendis", 10, 595.61260876609265, 2 },
                    { 91, 10, 0, "Oceane", "Percy", "sit", 15, 754.41434744348089, 2 },
                    { 92, 24, 1, "Zachariah", "Eileen", "est", 4, 104.32656018210876, 1 },
                    { 93, 12, 0, "Janessa", "Ewald", "sint", 25, 906.84249251277765, 2 },
                    { 94, 11, 0, "Lizzie", "Dexter", "quia", 2, 506.23335387509843, 1 },
                    { 95, 20, 0, "Marcella", "Orland", "aut", 22, 17.288391151834666, 1 },
                    { 96, 9, 1, "Emmalee", "Brooke", "fugit", 21, 717.31817468939948, 1 },
                    { 97, 2, 0, "Albin", "Pasquale", "voluptas", 14, 40.8357868659781, 1 },
                    { 98, 15, 0, "Cordelia", "Yesenia", "magnam", 6, 981.70194264585416, 1 },
                    { 99, 15, 1, "Alycia", "Danika", "eligendi", 4, 952.86616423740338, 1 },
                    { 100, 13, 1, "Lindsay", "Keara", "et", 2, 607.90420992059444, 2 }
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
