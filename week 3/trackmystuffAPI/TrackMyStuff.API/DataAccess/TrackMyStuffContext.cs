using Microsoft.EntityFrameworkCore;
using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

//this class is going to be our database context class for our app
//we only need one class that inherits from the EF Core context class(assuming only 1 DB)
// this class is what will handle our ef core DB communication for us

public class TrackMyStuffContext : DbContext
{
    //make our context class aware of model classes
    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Pet> Pets { get; set; }

    //Constructor
    public TrackMyStuffContext() { }

    //in order to tweek EFCORE behavoir/assumptions of what we want in out database
    //we need to explicitly override a method that comes from that DBContext base c;ass called OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //here we override EFCore's default assumptions on how we want our modeles
        //modeled in out database, by forceing to us Table Per concrete type mapping TPC
        //a seperate table with all columns for objects that are part of an inheritance heirarchy
        //only on Parent class not inherited classes
        modelBuilder.Entity<Item>().UseTpcMappingStrategy()
            .ToTable("Items");
        modelBuilder.Entity<Pet>()
            .ToTable("Pets");
        modelBuilder.Entity<Document>()
            .ToTable("Documents");

            //this line not really need except to explicitly name table
        modelBuilder.Entity<User>()
            .ToTable("Users");


    }


}