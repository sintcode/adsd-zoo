namespace Zoo.Data 
{
    public class DBInitializer 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = serviceProvider.GetRequiredService<ZooContext>())
            {
                context.Database.EnsureCreated(); //Make sure database actually exists

                if(context.Animal.Any() && context.Enclosure.Any() && context.Category.Any()){ //If at least one of every exists
                    return;
                }

                var animalFaker = Fakers.GetAnimalFaker();
                var enclosureFaker = Fakers.GetEnclosureFaker();
                var categoryFaker = Fakers.GetCategoryFaker();

                var fakeAnimals = animalFaker.Generate(50);
                var fakeEnclosures = enclosureFaker.Generate(50);
                var fakeCategories = categoryFaker.Generate(50);

                context.Animal.AddRange(fakeAnimals);
                context.Enclosure.AddRange(fakeEnclosures);
                context.Category.AddRange(fakeCategories);

                context.SaveChanges();
            }
        }
    }
}
