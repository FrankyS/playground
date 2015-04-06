namespace Franky.Playground.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class ItemInitial : DbMigration
	{
		public override void Up()
		{
			this.CreateTable(
				"dbo.Items", 
				c => new
					{
						Id = c.Long(nullable: false, identity: true), 
						Name = c.String(), 
						Type = c.Int(nullable: false), 
						Rights = c.Int(nullable: false), 
						DateTime = c.DateTime(nullable: false), 
					})
				.PrimaryKey(t => t.Id);
		}
		
		public override void Down()
		{
			this.DropTable("dbo.Items");
		}
	}
}
