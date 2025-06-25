using FluentMigrator;

namespace Sinqia.Calculator.Infrastructure.Migrations.Versions;

[Migration(202406240001, "Create table to save the user's information")]
public class Version0000001 : VersionBase
{
    public override void Up()
    {
        Create.Table("cotacao")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("data").AsDate().NotNullable()
            .WithColumn("indexador").AsString(30).NotNullable()
            .WithColumn("valor").AsDecimal(10, 2).NotNullable();
    }
}