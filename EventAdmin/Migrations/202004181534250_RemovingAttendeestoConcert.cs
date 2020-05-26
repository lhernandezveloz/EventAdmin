namespace EventAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingAttendeestoConcert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" }, "dbo.Attendances");
            DropIndex("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" });
            DropColumn("dbo.Concerts", "Attendance_ConcertId");
            DropColumn("dbo.Concerts", "Attendance_AttendeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Concerts", "Attendance_AttendeeId", c => c.String(maxLength: 128));
            AddColumn("dbo.Concerts", "Attendance_ConcertId", c => c.Int());
            CreateIndex("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" });
            AddForeignKey("dbo.Concerts", new[] { "Attendance_ConcertId", "Attendance_AttendeeId" }, "dbo.Attendances", new[] { "ConcertId", "AttendeeId" });
        }
    }
}
