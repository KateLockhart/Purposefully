namespace Purposefully.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "GoalId", "dbo.Goals");
            DropIndex("dbo.Entries", new[] { "GoalId" });
            AlterColumn("dbo.Entries", "GoalId", c => c.Int());
            CreateIndex("dbo.Entries", "GoalId");
            AddForeignKey("dbo.Entries", "GoalId", "dbo.Goals", "GoalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "GoalId", "dbo.Goals");
            DropIndex("dbo.Entries", new[] { "GoalId" });
            AlterColumn("dbo.Entries", "GoalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entries", "GoalId");
            AddForeignKey("dbo.Entries", "GoalId", "dbo.Goals", "GoalId", cascadeDelete: true);
        }
    }
}
