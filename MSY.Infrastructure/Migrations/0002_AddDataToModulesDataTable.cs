using FluentMigrator;
using Microsoft.EntityFrameworkCore;
using MSY.Database;
using MSY.Database.Models;

namespace MSY.Infrastructure.Migrations;

[Migration(2)]
public class AddDataToModulesDataTable:  Migration
{
    private DbMSYContext Context { get; set; }
    public AddDataToModulesDataTable(DbMSYContext context)
    {
        Context = context;
    }
    public override void Up()
    {
        Context.Database.OpenConnection();
        Context.Database.BeginTransaction();
        var data1 = new ModuleData()
        {
            CreatedAt = DateTime.UtcNow - TimeSpan.FromHours(1),
            ObjectId = 1,
            Payload = "data",
            ObjectName = "object1"
        };
        var data2 = new ModuleData()
        {
            CreatedAt = DateTime.UtcNow,
            ObjectId = 1,
            Payload = "data",
            ObjectName = "object1"
        };
        var data3 = new ModuleData()
        {
            CreatedAt = DateTime.UtcNow - TimeSpan.FromHours(5),
            ObjectId = 2,
            Payload = "data",
            ObjectName = "object2"
        };
        Context.Add(data1);
        Context.Add(data2);
        Context.Add(data3);
        Context.SaveChanges();
        Context.Database.CommitTransaction();
        Context.Database.CloseConnection();
    }
        
    public override void Down()
    {
    }
}