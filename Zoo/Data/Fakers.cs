//using Zoo.Models;
//using Bogus;

//namespace Zoo.Data 
//{
//    public class Fakers 
//    {
//        public static Faker<Animal> GetAnimalFaker()
//        {
//            //Animal: Id,Name,Species,Size,Diet,Activity,Predator,SpaceRequired,SecurityRequired,CategoryId,EnclosureId
//            var species = new[]{"Lion", "Elephant", "Dolphin", "Eagle", "Kangaroo", "Penguin", "Tiger", "Giraffe", "Hippopotamus", "Wolf", "Shark", "Bear", "Zebra", "Crocodile", "Panda", "Owl", "Chimpanzee", "Rhinoceros", "Seal", "Flamingo"};

//            return new Faker<Animal>()
//                .RuleFor(a => a.Name, f => f.Name.FirstName())
//                .RuleFor(a => a.Species, f => f.PickRandom(species))
//                .RuleFor(a => a.Size, f => f.PickRandom<Animal.SizeClass>())
//                .RuleFor(a => a.Diet, f => f.PickRandom<Animal.DietType>())
//                .RuleFor(a => a.Activity, f => f.PickRandom<Animal.ActivityPattern>())
//                .RuleFor(a => a.Predator, f => f.Random.Bool())
//                .RuleFor(a => a.SpaceRequired, f => f.Random.Double(10,100))
//                .RuleFor(a => a.SecurityRequired, f => f.PickRandom<Animal.SecurityLevel>())
//                .RuleFor(a => a.CategoryId, f => f.Random.Int(1,32))
//                .RuleFor(a => a.EnclosureId, f => f.Random.Int(1,32));
//        }

//        public static Faker<Enclosure> GetEnclosureFaker()
//        {
//            //Enclosure: Id,Name,Climate,Habitat,SecurityRequired,Size
//            var enclosureNames = new[]{"Tropical Rainforest", "Desert", "Savanna", "Arctic Tundra", "Grasslands", "Coral Reef", "Wetlands", "Temperate Forest", "Mountainous Region", "African Plains", "Australian Outback", "Amazon River Basin", "Mangrove Swamp", "Polar Region", "Alpine Meadow", "Coastal Shoreline", "Cactus Garden", "Marshland", "Urban Jungle", "Petting Zoo"};

//            return new Faker<Enclosure>()
//                .RuleFor(e => e.Name, f => f.PickRandom(enclosureNames))
//                .RuleFor(e => e.Climate, f => f.PickRandom<Enclosure.ClimateType>())
//                .RuleFor(e => e.Habitat, f => f.PickRandom<Enclosure.HabitatType>()) //Doesn't seem like Flags can be faked easily
//                .RuleFor(e => e.SecurityRequired, f => f.PickRandom<Enclosure.SecurityLevel>())
//                .RuleFor(e => e.Size, f => f.Random.Double(100,1000));
//        }

//        public static Faker<Category> GetCategoryFaker() 
//        {
//            //Enclosure: Id,Name
//            var categories = new[] { "Mammals", "Birds", "Reptiles", "Amphibians", "Fish", "Insects", "Arachnids", "Crustaceans" };

//            return new Faker<Category>()
//                .RuleFor(c => c.Name, f => f.PickRandom(categories));
//        }
//    }
//}
