﻿using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Sinqia.Calculator.Infrastructure.Migrations;

public abstract class VersionBase : ForwardOnlyMigration
{
    protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string table)
    {
        return Create.Table(table)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CreatedOn").AsDateTime().NotNullable()
            .WithColumn("Active").AsBoolean().NotNullable();
    }
}