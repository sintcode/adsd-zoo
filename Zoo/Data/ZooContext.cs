using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Models;
using Bogus;

namespace Zoo.Data 
{
    public class ZooContext : DbContext 
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }

        public DbSet<Animal> Animal { get; set; } = default!;
        public DbSet<Enclosure> Enclosure { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Species> Species { get; set; } = default!;
        public DbSet<ZooModel> ZooModel { get; set; } = default!;

        //Unfortunately no way to define generic model list without problems later on
        public static List<Animal> Animals;
        public static List<Species> SpeciesList;
        public static List<Category> Categories;
        public static List<Enclosure> Enclosures;
        public static List<ZooModel> Zoos;

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            //Building from Parents to Children
            builder.Entity<ZooModel>().HasMany(z => z.Categories).WithOne(c => c.Zoo).HasForeignKey(c => c.ZooId);
            builder.Entity<ZooModel>().HasMany(z => z.Enclosures).WithOne(e => e.Zoo).HasForeignKey(e => e.ZooId);
            builder.Entity<ZooModel>().HasMany(z => z.Animals).WithOne(a => a.Zoo).HasForeignKey(a => a.ZooId);
            builder.Entity<Category>().HasMany(c => c.Species).WithMany(c => c.Categories);
            builder.Entity<Enclosure>().HasMany(e => e.Animals).WithOne(a => a.Enclosure).HasForeignKey(a => a.EnclosureId);
            builder.Entity<Species>().HasMany(s => s.Animals).WithOne(a => a.Species).HasForeignKey(a => a.SpeciesId);

            //Call Seed function
            Seed();

            //Add seeding data 
            builder.Entity<Animal>().HasData(Animals);
            builder.Entity<Species>().HasData(SpeciesList);
            builder.Entity<Category>().HasData(Categories);
            builder.Entity<Enclosure>().HasData(Enclosures);
            builder.Entity<ZooModel>().HasData(Zoos);
        }

        protected void Seed() 
        {
            //Define base seeding rate
            const int volume = 50;

            ZooSeeder(volume);
            SpeciesSeeder(volume);
            CategorySeeder(volume);
            EnclosureSeeder(volume);
            AnimalSeeder(volume);

            return;
        }

        static void ZooSeeder(int amount) 
        {
            Zoos = new Faker<ZooModel>()
                .RuleFor(z => z.Id, f => f.IndexFaker + 1)
                .RuleFor(z => z.Name, f => f.Company.CompanyName())
                .RuleFor(z => z.Description, f => f.Lorem.Sentence(5))
                .RuleFor(z => z.Country, f => f.Address.Country())
                .RuleFor(z => z.City, f => f.Address.City())
                .Generate(amount / (amount / 2));
        }

        static void SpeciesSeeder(int amount) 
        {
            //Yes, I asked ChatGPT, though ideally they would be pulled from an API
            List<(string common, string latin)> speciesNames = [
                ("Lion", "Panthera leo"),
                ("Elephant", "Loxodonta africana"),
                ("Tiger", "Panthera tigris"),
                ("Giraffe", "Giraffa camelopardalis"),
                ("Zebra", "Equus quagga"),
                ("Penguin", "Spheniscus demersus"),
                ("Koala", "Phascolarctos cinereus"),
                ("Dolphin", "Tursiops truncatus"),
                ("Sloth", "Bradypus variegatus"),
                ("Jaguar", "Panthera onca"),
                ("Eagle", "Aquila chrysaetos"),
                ("Octopus", "Octopus vulgaris"),
                ("Polar Bear", "Ursus maritimus"),
                ("Kangaroo", "Macropus giganteus"),
                ("Cheetah", "Acinonyx jubatus"),
                ("Wolf", "Canis lupus"),
                ("Bear", "Ursus arctos"),
                ("Rhino", "Diceros bicornis"),
                ("Hippo", "Hippopotamus amphibius"),
                ("Gorilla", "Gorilla beringei"),
                ("Panda", "Ailuropoda melanoleuca"),
                ("Squirrel", "Sciurus carolinensis"),
                ("Fox", "Vulpes vulpes"),
                ("Owl", "Strix aluco"),
                ("Crocodile", "Crocodylus niloticus"),
                ("Pangolin", "Manis javanica"),
                ("Puma", "Puma concolor"),
                ("Toucan", "Ramphastos toco"),
                ("Chameleon", "Chamaeleo chamaeleon"),
                ("Meerkat", "Suricata suricatta")
            ];

            SpeciesList = new Faker<Species>()
                .RuleFor(s => s.Id, f => f.IndexFaker + 1)
                .RuleFor(s => s.Name, f => f.PickRandom(speciesNames).common)
                .RuleFor(s => s.LatinName, f => f.PickRandom(speciesNames).latin)
                .RuleFor(s => s.Size, f => f.PickRandom<Species.SizeClass>())
                .RuleFor(s => s.SpaceRequired, f => f.Random.Double(10, 100))
                .RuleFor(s => s.Diet, f => f.PickRandom<Species.DietType>())
                .RuleFor(s => s.Predator, f => f.Random.Bool())
                .RuleFor(s => s.Activity, f => f.PickRandom<Species.ActivityPattern>())
                .RuleFor(s => s.SecurityRequired, f => f.PickRandom<Species.SecurityLevel>())
                .Generate(amount / 2);
        }

        static void CategorySeeder(int amount) 
        {
            Categories = new Faker<Category>()
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Lorem.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Sentence(10))
                .RuleFor(c => c.ZooId, f => f.PickRandom(Zoos).Id)
                .Generate(amount / 2);
        }

        static void EnclosureSeeder(int amount) 
        {
            Enclosures = new Faker<Enclosure>()
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Lorem.Word())
                .RuleFor(c => c.Size, f => f.Random.Double(100, 1000))
                .RuleFor(c => c.Climate, f => f.PickRandom<Enclosure.ClimateType>())
                .RuleFor(c => c.Habitat, f => f.PickRandom<Enclosure.HabitatType>())
                .RuleFor(c => c.SecurityRequired, f => f.PickRandom<Enclosure.SecurityLevel>())
                .RuleFor(c => c.PredatorEnclosure, f => f.Random.Bool())
                .RuleFor(c => c.ZooId, f => f.PickRandom(Zoos).Id)
                .RuleFor(c => c.PredatorSpeciesId, f => f.PickRandom(SpeciesList).Id)
                .Generate(amount / 2);
        }

        static void AnimalSeeder(int amount) 
        {
            Animals = new Faker<Animal>()
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.Name, f => f.Name.FirstName())
                .RuleFor(a => a.Gender, f => f.PickRandom<Animal.Genders>())
                .RuleFor(a => a.Weight, f => f.Random.Double(1, 1000)) //Yes, you can have a 1kg elephant
                .RuleFor(a => a.Personality, f => f.Name.FirstName())
                .RuleFor(a => a.PreferredDiet, f => f.Lorem.Word())
                .RuleFor(a => a.ZooId, f => f.PickRandom(Zoos).Id)
                .RuleFor(a => a.SpeciesId, f => f.PickRandom(SpeciesList).Id)
                .RuleFor(a => a.EnclosureId, f => f.PickRandom(Enclosures).Id)
                .Generate(amount * 2);
        }
    }
}