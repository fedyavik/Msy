using FluentMigrator;

namespace MSY.Infrastructure.Migrations;

[Migration(1)]
public class CreateModulesDataTable:  Migration
{
    public override void Up()
    {
        Create.Table("ModulesData")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
            .WithColumn("ObjectId").AsInt64().NotNullable()
            .WithColumn("ObjectName").AsString().NotNullable()
            .WithColumn("Payload").AsString().NotNullable()
            .WithColumn("CreatedAt").AsCustom("TIMESTAMP WITH TIME ZONE").NotNullable();
    }
        
    public override void Down()
    {
        Delete.Table("ModulesData");
    }
}