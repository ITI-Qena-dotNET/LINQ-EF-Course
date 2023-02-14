namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ItiDbContext context = new();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            /*
             * Use Command `Add-Migration <YourMigrationName>` to add new migrations
             * in Package Manager Console
             * 
             * When you run the program, the above lines will handle the migration process for you
             * as if you have run `Update-Database`
             * 
             */

            // Write code here
        }
    }
}
