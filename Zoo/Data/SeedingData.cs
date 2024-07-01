﻿using Zoo.Models;

namespace Zoo.Data 
{
    public static class SeedingData 
    {
        //Contains Data for Seeding for seeding with no dependencies on APIs and no conflicting logic from Fakers
        //This however unfortunately seems to be impossible, as my app yells at me that I can't add these.
        //Most likely overlooking a simple solution.
        //So now it just takes random stuff from this list
        //Yes, ChatGPT was used as manually writing down this data would be insanity
        //My personal favourite is 'Gorilla gorilla gorilla' 🦍
        public readonly static List<Species> SpeciesSeedingList = new()
        {
            new() { Name = "African Elephant", LatinName = "Loxodonta africana", Size = Species.SizeClass.Huge, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Lion", LatinName = "Panthera leo", Size = Species.SizeClass.Large, SpaceRequired = 1500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Tiger", LatinName = "Panthera tigris", Size = Species.SizeClass.Large, SpaceRequired = 2000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Giraffe", LatinName = "Giraffa camelopardalis", Size = Species.SizeClass.Huge, SpaceRequired = 1000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Plains Zebra", LatinName = "Equus quagga", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Chimpanzee", LatinName = "Pan troglodytes", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Bornean Orangutan", LatinName = "Pongo pygmaeus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Polar Bear", LatinName = "Ursus maritimus", Size = Species.SizeClass.Large, SpaceRequired = 2000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Emperor Penguin", LatinName = "Aptenodytes forsteri", Size = Species.SizeClass.Medium, SpaceRequired = 50, Diet = Species.DietType.Carnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Red Kangaroo", LatinName = "Macropus rufus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Western Lowland Gorilla", LatinName = "Gorilla gorilla gorilla", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Red Panda", LatinName = "Ailurus fulgens", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Asian Elephant", LatinName = "Elephas maximus", Size = Species.SizeClass.Huge, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "White Rhinoceros", LatinName = "Ceratotherium simum", Size = Species.SizeClass.Large, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Hippopotamus", LatinName = "Hippopotamus amphibius", Size = Species.SizeClass.Huge, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Koala", LatinName = "Phascolarctos cinereus", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Common Ostrich", LatinName = "Struthio camelus", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Galapagos Tortoise", LatinName = "Chelonoidis nigra", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Gray Wolf", LatinName = "Canis lupus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Snow Leopard", LatinName = "Panthera uncia", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Giant Panda", LatinName = "Ailuropoda melanoleuca", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Puma", LatinName = "Puma concolor", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Giant Tortoise", LatinName = "Geochelone gigantea", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Aldabra Giant Tortoise", LatinName = "Aldabrachelys gigantea", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Gibbon", LatinName = "Hylobatidae spp.", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Ring-Tailed Lemur", LatinName = "Lemur catta", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Golden Lion Tamarin", LatinName = "Leontopithecus rosalia", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Gharial", LatinName = "Gavialis gangeticus", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Komodo Dragon", LatinName = "Varanus komodoensis", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "African Penguin", LatinName = "Spheniscus demersus", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Carnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Black Rhinoceros", LatinName = "Diceros bicornis", Size = Species.SizeClass.Large, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Orangutan", LatinName = "Pongo spp.", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Siamang", LatinName = "Symphalangus syndactylus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Meerkat", LatinName = "Suricata suricatta", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Sloth Bear", LatinName = "Melursus ursinus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Jaguar", LatinName = "Panthera onca", Size = Species.SizeClass.Large, SpaceRequired = 1500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Manatee", LatinName = "Trichechus spp.", Size = Species.SizeClass.Huge, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Koala", LatinName = "Phascolarctos cinereus", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Penguin", LatinName = "Spheniscus spp.", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Carnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Giant Otter", LatinName = "Pteronura brasiliensis", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Reticulated Giraffe", LatinName = "Giraffa camelopardalis reticulata", Size = Species.SizeClass.Huge, SpaceRequired = 1000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "American Bison", LatinName = "Bison bison", Size = Species.SizeClass.Large, SpaceRequired = 1500, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Red Panda", LatinName = "Ailurus fulgens", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Gorilla", LatinName = "Gorilla beringei", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Sumatran Tiger", LatinName = "Panthera tigris sumatrae", Size = Species.SizeClass.Large, SpaceRequired = 2000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Cheetah", LatinName = "Acinonyx jubatus", Size = Species.SizeClass.Large, SpaceRequired = 1500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Giant Anteater", LatinName = "Myrmecophaga tridactyla", Size = Species.SizeClass.Large, SpaceRequired = 1500, Diet = Species.DietType.Insectivore, Predator = false, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Bengal Tiger", LatinName = "Panthera tigris tigris", Size = Species.SizeClass.Large, SpaceRequired = 2000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Leopard", LatinName = "Panthera pardus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "African Wild Dog", LatinName = "Lycaon pictus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Humboldt Penguin", LatinName = "Spheniscus humboldti", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Carnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Hippopotamus", LatinName = "Hippopotamus amphibius", Size = Species.SizeClass.Huge, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Golden Eagle", LatinName = "Aquila chrysaetos", Size = Species.SizeClass.Medium, SpaceRequired = 200, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Snow Leopard", LatinName = "Panthera uncia", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Jaguar", LatinName = "Panthera onca", Size = Species.SizeClass.Large, SpaceRequired = 1500, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Sloth", LatinName = "Bradypus spp.", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "American Alligator", LatinName = "Alligator mississippiensis", Size = Species.SizeClass.Large, SpaceRequired = 1000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Fennec Fox", LatinName = "Vulpes zerda", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Black Bear", LatinName = "Ursus americanus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Capuchin Monkey", LatinName = "Cebus spp.", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Ocelot", LatinName = "Leopardus pardalis", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Siberian Tiger", LatinName = "Panthera tigris altaica", Size = Species.SizeClass.Large, SpaceRequired = 2000, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "Bald Eagle", LatinName = "Haliaeetus leucocephalus", Size = Species.SizeClass.Medium, SpaceRequired = 200, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "African Grey Parrot", LatinName = "Psittacus erithacus", Size = Species.SizeClass.Small, SpaceRequired = 50, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Amazonian Manatee", LatinName = "Trichechus inunguis", Size = Species.SizeClass.Huge, SpaceRequired = 2000, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.High },
            new() { Name = "White-Tailed Deer", LatinName = "Odocoileus virginianus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "African Wildcat", LatinName = "Felis lybica", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Asian Small-Clawed Otter", LatinName = "Aonyx cinereus", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Carnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Giant Panda", LatinName = "Ailuropoda melanoleuca", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Mandrill", LatinName = "Mandrillus sphinx", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Blue and Yellow Macaw", LatinName = "Ara ararauna", Size = Species.SizeClass.Small, SpaceRequired = 50, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Chilean Flamingo", LatinName = "Phoenicopterus chilensis", Size = Species.SizeClass.Medium, SpaceRequired = 200, Diet = Species.DietType.Herbivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Spectacled Bear", LatinName = "Tremarctos ornatus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = true, Activity = Species.ActivityPattern.Cathemeral, SecurityRequired = Species.SecurityLevel.Medium },
            new() { Name = "Coati", LatinName = "Nasua spp.", Size = Species.SizeClass.Small, SpaceRequired = 100, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Red River Hog", LatinName = "Potamochoerus porcus", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Omnivore, Predator = false, Activity = Species.ActivityPattern.Diurnal, SecurityRequired = Species.SecurityLevel.Low },
            new() { Name = "Goliath Frog", LatinName = "Conraua goliath", Size = Species.SizeClass.Medium, SpaceRequired = 500, Diet = Species.DietType.Insectivore, Predator = false, Activity = Species.ActivityPattern.Nocturnal, SecurityRequired = Species.SecurityLevel.Low }
        };
    }
}