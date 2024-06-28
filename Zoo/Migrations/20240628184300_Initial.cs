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
                    { 1, 0, 0, "Aquila chrysaetos", "Crocodile", false, 3, 1, 32.01379880006678 },
                    { 2, 1, 0, "Ramphastos toco", "Meerkat", false, 2, 2, 75.126026509475835 },
                    { 3, 2, 0, "Ursus maritimus", "Dolphin", false, 0, 0, 44.712891972259158 },
                    { 4, 1, 3, "Panthera leo", "Octopus", true, 0, 4, 25.07543072138046 },
                    { 5, 1, 0, "Manis javanica", "Bear", true, 3, 5, 92.946270527946297 },
                    { 6, 0, 3, "Panthera onca", "Koala", false, 3, 1, 90.171262429381557 },
                    { 7, 0, 0, "Hippopotamus amphibius", "Pangolin", true, 2, 0, 11.058055322389976 },
                    { 8, 0, 4, "Diceros bicornis", "Cheetah", true, 2, 2, 69.602043105203734 },
                    { 9, 1, 3, "Panthera leo", "Puma", true, 3, 3, 50.729378722585103 },
                    { 10, 1, 3, "Strix aluco", "Gorilla", true, 1, 1, 55.533285033392076 },
                    { 11, 0, 1, "Crocodylus niloticus", "Jaguar", true, 2, 2, 28.066075392286631 },
                    { 12, 0, 3, "Suricata suricatta", "Kangaroo", true, 2, 3, 24.891701966967656 },
                    { 13, 0, 0, "Puma concolor", "Koala", true, 1, 5, 86.18516549729182 },
                    { 14, 0, 2, "Aquila chrysaetos", "Tiger", false, 1, 2, 59.966173743980853 },
                    { 15, 0, 3, "Aquila chrysaetos", "Penguin", true, 1, 5, 78.273665188828033 },
                    { 16, 0, 2, "Hippopotamus amphibius", "Penguin", true, 1, 5, 61.959120927809764 },
                    { 17, 2, 1, "Aquila chrysaetos", "Dolphin", true, 1, 0, 31.378917859086741 },
                    { 18, 2, 1, "Tursiops truncatus", "Squirrel", false, 2, 2, 73.372082847472058 },
                    { 19, 0, 3, "Canis lupus", "Tiger", false, 1, 1, 11.049173388316213 },
                    { 20, 1, 1, "Panthera tigris", "Owl", false, 3, 5, 10.002188366514011 },
                    { 21, 1, 0, "Loxodonta africana", "Octopus", false, 3, 4, 84.254124300851643 },
                    { 22, 1, 2, "Diceros bicornis", "Squirrel", true, 3, 3, 22.567867948564974 },
                    { 23, 2, 3, "Macropus giganteus", "Octopus", true, 1, 5, 30.545153512919448 },
                    { 24, 0, 2, "Gorilla beringei", "Puma", true, 0, 1, 44.315077930130165 },
                    { 25, 0, 0, "Canis lupus", "Rhino", true, 0, 4, 99.159189397346665 }
                });

            migrationBuilder.InsertData(
                table: "ZooModel",
                columns: new[] { "Id", "City", "Country", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "East Alexanne", "Comoros", "Est neque est id officia.", "Wolf Group" },
                    { 2, "North Madelynshire", "Saint Vincent and the Grenadines", "Et distinctio dignissimos aut sed.", "Macejkovic - Prohaska" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ZooId" },
                values: new object[,]
                {
                    { 1, "Accusamus consequatur eos atque doloremque iusto non nobis omnis culpa.", "suscipit", 2 },
                    { 2, "Repellendus eos vero qui saepe sequi facere quam ad deserunt.", "aut", 1 },
                    { 3, "Et laboriosam rem sequi harum voluptatem dolores aliquam alias illum.", "quos", 1 },
                    { 4, "Ad reiciendis possimus rerum nemo sequi dolorem voluptates animi magnam.", "sed", 2 },
                    { 5, "Enim inventore qui aut dolore ea aut eum est perferendis.", "et", 2 },
                    { 6, "Repellendus itaque velit repellendus et quam qui placeat molestiae dolores.", "et", 2 },
                    { 7, "Quis sit fuga aut maiores mollitia dolore nam sed numquam.", "labore", 1 },
                    { 8, "Id rerum aspernatur eum magni necessitatibus nisi enim eum facilis.", "at", 2 },
                    { 9, "Ut sit possimus possimus et sint tempora quis temporibus voluptas.", "beatae", 1 },
                    { 10, "Blanditiis nisi autem sed consequuntur dolores illum similique perferendis molestiae.", "nostrum", 2 },
                    { 11, "Consequatur voluptatem placeat tempora sed vero omnis architecto earum fugit.", "delectus", 2 },
                    { 12, "Similique sunt dolorem facilis adipisci ut necessitatibus labore cumque nemo.", "temporibus", 2 },
                    { 13, "Est inventore reprehenderit voluptatem ullam et voluptatibus aliquam et optio.", "iusto", 2 },
                    { 14, "Ipsa sint doloribus beatae sed hic aut nisi molestiae omnis.", "et", 2 },
                    { 15, "Excepturi adipisci a neque qui aliquid explicabo eveniet aut impedit.", "in", 1 },
                    { 16, "Et excepturi non voluptas id aspernatur sunt eum rerum harum.", "veniam", 2 },
                    { 17, "Non porro tempore ducimus voluptas ut recusandae rerum molestiae ea.", "id", 2 },
                    { 18, "Veritatis aut nobis necessitatibus sed ab illo sit perferendis expedita.", "voluptas", 1 },
                    { 19, "Alias dicta doloribus ut et omnis iusto dignissimos cum nam.", "in", 2 },
                    { 20, "Quis quas explicabo alias itaque voluptatem beatae quo et optio.", "quia", 2 },
                    { 21, "Quia veniam dicta eos magni eos iusto temporibus delectus dolorem.", "at", 2 },
                    { 22, "Cumque adipisci blanditiis necessitatibus cumque voluptatem dolor similique enim sint.", "laborum", 1 },
                    { 23, "Quis doloremque sunt voluptatibus ut velit vitae voluptas quibusdam modi.", "aut", 1 },
                    { 24, "Mollitia sequi dignissimos quia maiores qui officia dolorum beatae ut.", "et", 1 },
                    { 25, "Assumenda tenetur est consectetur voluptate ut recusandae commodi ad molestiae.", "quisquam", 2 }
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Climate", "Habitat", "Name", "PredatorEnclosure", "PredatorSpeciesId", "SecurityRequired", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 3, 16, "dicta", false, 6, 1, 234.96390556297578, 2 },
                    { 2, 4, 8, "et", false, 23, 3, 306.61589197491548, 1 },
                    { 3, 3, 4, "molestias", false, 24, 0, 837.16331606115625, 2 },
                    { 4, 1, 32, "commodi", true, 19, 3, 723.75837856281146, 1 },
                    { 5, 4, 8, "sit", false, 18, 0, 560.59287182775302, 2 },
                    { 6, 0, 2, "sequi", true, 17, 0, 523.04309804885759, 1 },
                    { 7, 4, 16, "sit", false, 22, 0, 159.39853810295423, 1 },
                    { 8, 1, 32, "esse", true, 4, 1, 572.88527323274502, 1 },
                    { 9, 1, 64, "quo", true, 25, 0, 436.30925995390322, 2 },
                    { 10, 4, 32, "molestias", false, 3, 2, 539.5054466814928, 2 },
                    { 11, 1, 64, "harum", false, 25, 1, 813.60681358928423, 2 },
                    { 12, 2, 4, "eos", false, 20, 1, 672.52764294425333, 2 },
                    { 13, 2, 8, "rerum", false, 8, 2, 454.07986279900774, 2 },
                    { 14, 3, 1, "velit", false, 2, 0, 844.5389142214442, 2 },
                    { 15, 2, 16, "repellendus", true, 20, 2, 443.26104338002375, 2 },
                    { 16, 4, 1, "eos", false, 6, 2, 347.46907029182097, 2 },
                    { 17, 4, 64, "quos", true, 13, 0, 758.20058098276672, 2 },
                    { 18, 3, 8, "molestias", true, 13, 1, 292.21674437655776, 1 },
                    { 19, 0, 32, "occaecati", true, 19, 3, 139.35034070584862, 2 },
                    { 20, 1, 16, "ratione", true, 15, 1, 883.01348247509179, 1 },
                    { 21, 4, 32, "aliquam", true, 20, 1, 687.76994852837504, 2 },
                    { 22, 0, 16, "error", false, 4, 0, 330.31628980751003, 1 },
                    { 23, 1, 32, "libero", true, 17, 2, 397.54850085858686, 2 },
                    { 24, 0, 64, "repudiandae", false, 2, 2, 156.50678515321641, 1 },
                    { 25, 1, 1, "voluptas", true, 22, 1, 165.07002232282213, 1 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "EnclosureId", "Gender", "Name", "Personality", "PreferredDiet", "SpeciesId", "Weight", "ZooId" },
                values: new object[,]
                {
                    { 1, 21, 1, "Reinhold", "Maxwell", "[]", 12, 583.99384218992839, 1 },
                    { 2, 21, 1, "Clementine", "Nicolette", "[]", 9, 922.09735241551175, 1 },
                    { 3, 4, 1, "Justyn", "Orland", "[]", 19, 73.678940402020686, 1 },
                    { 4, 11, 1, "Oleta", "Florencio", "[]", 4, 292.70083879459168, 1 },
                    { 5, 9, 1, "Dulce", "Gregorio", "[]", 15, 28.621354260867204, 1 },
                    { 6, 23, 0, "Adrienne", "Marlee", "[]", 20, 310.26664344476649, 2 },
                    { 7, 4, 1, "Arianna", "Rogelio", "[]", 10, 363.34351295072241, 1 },
                    { 8, 3, 0, "Carter", "Maymie", "[]", 18, 339.79810353751037, 1 },
                    { 9, 14, 0, "Jo", "Lilliana", "[]", 14, 883.57638563642149, 2 },
                    { 10, 9, 1, "Erik", "Donald", "[]", 4, 780.69339139383749, 2 },
                    { 11, 3, 0, "Milan", "Javier", "[]", 14, 912.71971748270596, 1 },
                    { 12, 12, 1, "Charlie", "Cassandra", "[]", 2, 429.5497026290779, 1 },
                    { 13, 16, 0, "Rowena", "Romaine", "[]", 24, 937.53173299641446, 1 },
                    { 14, 5, 1, "Isidro", "Brycen", "[]", 22, 20.410098982445295, 2 },
                    { 15, 21, 0, "Shannon", "Jeff", "[]", 2, 751.03006885634807, 1 },
                    { 16, 8, 0, "Mireille", "Noe", "[]", 19, 409.34013035629908, 1 },
                    { 17, 5, 1, "Ettie", "Esta", "[]", 13, 174.47088892910202, 2 },
                    { 18, 8, 1, "Meggie", "Jorge", "[]", 1, 701.14730300142276, 1 },
                    { 19, 15, 1, "Guy", "Marjorie", "[]", 6, 105.38729777348733, 1 },
                    { 20, 18, 0, "Leanna", "Francis", "[]", 5, 942.52034980879591, 2 },
                    { 21, 14, 1, "Dandre", "Raina", "[]", 19, 75.47178610774121, 1 },
                    { 22, 2, 1, "Demarcus", "Lon", "[]", 19, 546.71001551133418, 1 },
                    { 23, 24, 1, "Ronny", "Dino", "[]", 18, 768.11496412915847, 1 },
                    { 24, 18, 1, "Caroline", "Pierce", "[]", 23, 4.4597895388517461, 2 },
                    { 25, 16, 1, "Rosella", "Emmanuelle", "[]", 15, 112.62275484553986, 1 },
                    { 26, 22, 1, "Maudie", "Finn", "[]", 3, 241.75767024040732, 1 },
                    { 27, 7, 0, "Felix", "Tressie", "[]", 24, 77.115780611041686, 2 },
                    { 28, 6, 0, "Sasha", "Trudie", "[]", 11, 306.50247653557494, 1 },
                    { 29, 11, 1, "Katelyn", "Liliana", "[]", 2, 469.9367846910157, 2 },
                    { 30, 2, 0, "Sienna", "Howard", "[]", 20, 158.56233311099234, 2 },
                    { 31, 20, 0, "Dashawn", "Tess", "[]", 9, 240.05281003650663, 2 },
                    { 32, 12, 1, "Louie", "Stephon", "[]", 18, 987.69278408091486, 1 },
                    { 33, 19, 1, "Serenity", "Nannie", "[]", 25, 603.97625224516582, 1 },
                    { 34, 14, 1, "Reginald", "Newton", "[]", 15, 279.2802088715427, 1 },
                    { 35, 15, 0, "Earnest", "Hallie", "[]", 3, 511.20347569858347, 2 },
                    { 36, 2, 1, "Lora", "Matilda", "[]", 14, 832.75294879800333, 1 },
                    { 37, 3, 1, "Madge", "Blanca", "[]", 9, 837.72692348051692, 1 },
                    { 38, 20, 1, "Alexanne", "Hailey", "[]", 15, 972.95455010553621, 1 },
                    { 39, 21, 1, "Shanel", "Kaela", "[]", 11, 926.76055502564009, 1 },
                    { 40, 3, 0, "Reyna", "Chadrick", "[]", 22, 467.24196335672912, 2 },
                    { 41, 9, 0, "Eino", "Eleanora", "[]", 2, 465.87783943131524, 2 },
                    { 42, 8, 1, "Werner", "Albina", "[]", 20, 524.16402258821302, 1 },
                    { 43, 24, 0, "Richard", "Stefan", "[]", 5, 520.86270872041496, 2 },
                    { 44, 7, 1, "Alfreda", "Fermin", "[]", 5, 329.80239024538031, 2 },
                    { 45, 10, 0, "Ada", "Aric", "[]", 15, 948.25042902466828, 2 },
                    { 46, 11, 0, "Gilberto", "Deon", "[]", 17, 292.43020764660406, 2 },
                    { 47, 1, 1, "Sienna", "Raquel", "[]", 18, 55.391065840388841, 1 },
                    { 48, 22, 1, "Deontae", "Eino", "[]", 23, 660.50993937936778, 2 },
                    { 49, 7, 0, "Celine", "Lilian", "[]", 9, 608.11200530091321, 1 },
                    { 50, 3, 1, "Mortimer", "Ella", "[]", 20, 924.36632312009817, 2 },
                    { 51, 25, 1, "Clifton", "Art", "[]", 17, 514.31180701421749, 2 },
                    { 52, 25, 0, "Mustafa", "Erin", "[]", 23, 65.811877011700844, 2 },
                    { 53, 2, 0, "Wyman", "Christiana", "[]", 23, 192.44330662876422, 1 },
                    { 54, 5, 1, "Kellen", "Efren", "[]", 3, 553.69651476068952, 1 },
                    { 55, 24, 1, "Jakob", "Nicola", "[]", 19, 227.43019061863316, 1 },
                    { 56, 14, 0, "Maud", "Laurence", "[]", 9, 489.68204851778478, 1 },
                    { 57, 6, 0, "Pattie", "Shane", "[]", 25, 744.21227502684644, 2 },
                    { 58, 23, 1, "Wilford", "Kayla", "[]", 23, 210.12001566779617, 2 },
                    { 59, 21, 0, "Stan", "Boyd", "[]", 25, 326.71578594588323, 2 },
                    { 60, 9, 1, "Catharine", "Judge", "[]", 14, 564.81709783411941, 1 },
                    { 61, 8, 0, "Maxime", "Terry", "[]", 22, 473.66420935817916, 2 },
                    { 62, 20, 1, "Shanna", "Lillie", "[]", 22, 258.75880571188929, 1 },
                    { 63, 13, 1, "Maye", "Sidney", "[]", 9, 233.65061681283504, 1 },
                    { 64, 19, 1, "Rebecca", "Jack", "[]", 21, 465.81381939727464, 2 },
                    { 65, 18, 1, "Dahlia", "Mitchell", "[]", 25, 315.99335931315642, 1 },
                    { 66, 22, 1, "Marlon", "Devin", "[]", 7, 212.32486820544179, 2 },
                    { 67, 21, 1, "Jettie", "Wilbert", "[]", 12, 243.6958231207114, 1 },
                    { 68, 20, 1, "Agustin", "Kiel", "[]", 11, 652.40047605135453, 2 },
                    { 69, 13, 0, "Jefferey", "Sincere", "[]", 6, 425.99206340312986, 2 },
                    { 70, 24, 1, "Jules", "Kenyatta", "[]", 16, 867.14126551641198, 2 },
                    { 71, 3, 0, "Carli", "Bud", "[]", 4, 587.71482324443105, 2 },
                    { 72, 2, 1, "Isabell", "Kaela", "[]", 6, 60.882503368474246, 1 },
                    { 73, 20, 1, "Florencio", "Valentin", "[]", 1, 218.25267924283597, 2 },
                    { 74, 23, 0, "Gabe", "Kyla", "[]", 1, 981.05557988929456, 1 },
                    { 75, 4, 0, "Magali", "Dorian", "[]", 23, 432.01772928758277, 2 },
                    { 76, 24, 1, "Georgette", "Quentin", "[]", 7, 469.38552882139214, 2 },
                    { 77, 13, 1, "Evelyn", "Mylene", "[]", 22, 650.08852301729075, 2 },
                    { 78, 25, 1, "Nayeli", "Gavin", "[]", 4, 644.24274255594094, 2 },
                    { 79, 11, 0, "Nathan", "Gayle", "[]", 24, 190.80559048992919, 2 },
                    { 80, 24, 0, "Montana", "Waino", "[]", 6, 838.6730568098111, 1 },
                    { 81, 6, 1, "Delphia", "Justus", "[]", 6, 509.18328678003121, 1 },
                    { 82, 25, 0, "Rowland", "Darby", "[]", 6, 182.24020553189803, 2 },
                    { 83, 25, 1, "Selena", "Precious", "[]", 4, 941.15820448840725, 1 },
                    { 84, 4, 0, "Duncan", "Violet", "[]", 6, 174.16567476235744, 2 },
                    { 85, 17, 0, "Karli", "Olga", "[]", 23, 803.50501438896663, 2 },
                    { 86, 5, 0, "Christophe", "Edwardo", "[]", 8, 396.24212019809181, 2 },
                    { 87, 25, 0, "Effie", "Cydney", "[]", 7, 966.11530222307499, 2 },
                    { 88, 3, 0, "Rafaela", "Wyatt", "[]", 17, 869.09809562821226, 1 },
                    { 89, 4, 1, "Shany", "Wilson", "[]", 11, 643.11447832990302, 2 },
                    { 90, 5, 0, "Briana", "Camron", "[]", 21, 140.09924657684903, 2 },
                    { 91, 19, 1, "Juanita", "Brando", "[]", 22, 896.84622258741945, 2 },
                    { 92, 19, 0, "Heidi", "Angelo", "[]", 12, 930.41293923685907, 2 },
                    { 93, 3, 1, "Hazle", "Aida", "[]", 20, 334.05487861645145, 2 },
                    { 94, 18, 1, "Miles", "Trycia", "[]", 23, 785.46470224348172, 2 },
                    { 95, 25, 1, "Nelda", "Braeden", "[]", 2, 488.86943761631613, 2 },
                    { 96, 1, 1, "Lorenzo", "Graciela", "[]", 12, 624.15951958122264, 2 },
                    { 97, 7, 1, "Samanta", "Deja", "[]", 18, 504.83892052973101, 1 },
                    { 98, 18, 0, "Lavina", "Tony", "[]", 5, 923.722905573866, 1 },
                    { 99, 6, 1, "Jada", "Alfonzo", "[]", 19, 652.63645862860426, 2 },
                    { 100, 22, 0, "Aurore", "Hulda", "[]", 25, 716.53104385927156, 1 }
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
