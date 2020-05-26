namespace EventAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAttendeestoConcert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "Attendance_ConcertId", c => c.Int());
            AddColumn("dbo.Concerts", "Attendance_AttendeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" });
            AddForeignKey("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" }, "dbo.Attendances", new[] { "ConcertId", "AttendeeId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" }, "dbo.Attendances");
            DropIndex("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" });
            DropColumn("dbo.Concerts", "Attendance_AttendeeId");
            DropColumn("dbo.Concerts", "Attendance_ConcertId");
        }
    }
}
