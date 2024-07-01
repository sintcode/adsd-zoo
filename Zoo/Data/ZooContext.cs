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
        private static List<Animal> Animals;
        private static List<Species> SpeciesList;
        private static List<Category> Categories;
        private static List<Enclosure> Enclosures;
        private static List<ZooModel> Zoos;

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            //Building from Parents to Children
            builder.Entity<ZooModel>().HasMany(z => z.Categories).WithOne(c => c.Zoo).HasForeignKey(c => c.ZooId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ZooModel>().HasMany(z => z.Enclosures).WithOne(e => e.Zoo).HasForeignKey(e => e.ZooId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ZooModel>().HasMany(z => z.Animals).WithOne(a => a.Zoo).HasForeignKey(a => a.ZooId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Category>().HasMany(c => c.Species).WithMany(c => c.Categories);
            builder.Entity<Enclosure>().HasMany(e => e.Animals).WithOne(a => a.Enclosure).HasForeignKey(a => a.EnclosureId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Species>().HasMany(s => s.Animals).WithOne(a => a.Species).HasForeignKey(a => a.SpeciesId).OnDelete(DeleteBehavior.Restrict);

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

            //Seeder per model for clarity
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
                .Generate(new Random().Next(1,amount/5));
        }

        static void SpeciesSeeder(int amount) 
        {
            //Unfortunately generates illogical data such as vegan lions that are actually fish
            SpeciesList = new Faker<Species>()
                .RuleFor(s => s.Id, f => f.IndexFaker + 1)
                .RuleFor(s => s.Name, f => f.PickRandom(SeedingData.SpeciesSeedingList).Name)
                .RuleFor(s => s.LatinName, f => f.PickRandom(SeedingData.SpeciesSeedingList).LatinName)
                .RuleFor(s => s.Size, f => f.PickRandom<Species.SizeClass>())
                .RuleFor(s => s.SpaceRequired, f => f.Random.Double(10, 100))
                .RuleFor(s => s.Diet, f => f.PickRandom<Species.DietType>())
                .RuleFor(s => s.Predator, f => f.Random.Bool())
                .RuleFor(s => s.Activity, f => f.PickRandom<Species.ActivityPattern>())
                .RuleFor(s => s.SecurityRequired, f => f.PickRandom<Species.SecurityLevel>())
                .Generate(new Random().Next(amount/3, (int)(amount/1.5)));
        }

        static void CategorySeeder(int amount) 
        {
            Categories = new Faker<Category>()
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Lorem.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Sentence(10))
                .RuleFor(c => c.ZooId, f => f.PickRandom(Zoos).Id)
                .Generate(new Random().Next(amount/4, amount/2));
        }

        static void EnclosureSeeder(int amount) 
        {
            Enclosures = new Faker<Enclosure>()
                .RuleFor(e => e.Id, f => f.IndexFaker + 1)
                .RuleFor(e => e.Name, f => f.Lorem.Word())
                .RuleFor(e => e.Size, f => f.Random.Double(100, 1000))
                .RuleFor(e => e.Climate, f => f.PickRandom<Enclosure.ClimateType>())
                .RuleFor(e => e.Habitat, f => f.PickRandom<Enclosure.HabitatType>())
                .RuleFor(e => e.SecurityRequired, f => f.PickRandom<Enclosure.SecurityLevel>())
                .RuleFor(e => e.PredatorEnclosure, f => f.Random.Bool())
                .RuleFor(e => e.ZooId, f => f.PickRandom(Zoos).Id)
                .RuleFor(e => e.PredatorSpeciesId, f => f.PickRandom(SpeciesList).Id)
                .Generate(new Random().Next(amount/4, amount/2));
        }

        static void AnimalSeeder(int amount) 
        {
            Animals = new Faker<Animal>()
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.Name, f => f.Name.FirstName())
                .RuleFor(a => a.Gender, f => f.PickRandom<Animal.Genders>())
                .RuleFor(a => a.Weight, f => f.Random.Double(1, 1000)) //Yes, you can have a 1kg elephant
                .RuleFor(a => a.Personality, f => f.Commerce.Color())
                .RuleFor(a => a.ZooId, f => f.PickRandom(Zoos).Id)
                .RuleFor(a => a.SpeciesId, f => f.PickRandom(SpeciesList).Id)
                .RuleFor(a => a.EnclosureId, f => f.PickRandom(Enclosures).Id)
                .Generate(new Random().Next(amount, amount*2));
        }
    }
}