using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IFractolDbContext
    {
        //DbSet<App> App { get; set; }
        //DbSet<AvwSubTask> AvwSubTask { get; set; }
        //DbSet<AvwTask> AvwTask { get; set; }
        //DbSet<AvwTimeLog> AvwTimeLog { get; set; }
        //DbSet<AvwUserNoticePreference> AvwUserNoticePreference { get; set; }
        //DbSet<AvwUsers> AvwUsers { get; set; }
        //DbSet<BusinessUnit> BusinessUnit { get; set; }
        //DbSet<Color> Color { get; set; }
        //DbSet<Country> Country { get; set; }
        //DbSet<ErrorMessage> ErrorMessage { get; set; }
        //DbSet<Projects> Projects { get; set; }
        //DbSet<Region> Region { get; set; }
        //DbSet<Role> Role { get; set; }
        //DbSet<SubTask> SubTask { get; set; }
        //DbSet<Domain.Entities.Task> Task { get; set; }
        //DbSet<Team> Team { get; set; }
        //DbSet<Domain.Entities.TimeLog> TimeLog { get; set; }
        //DbSet<TimeLogBudget> TimeLogBudget { get; set; }
        //DbSet<TimeLogTimeTags> TimeLogTimeTags { get; set; }
        //DbSet<TimeTags> TimeTags { get; set; }
        //DbSet<Tower> Tower { get; set; }
        //DbSet<UserColorPalette> UserColorPalette { get; set; }
        //DbSet<UserNoticePreference> UserNoticePreference { get; set; }
        //DbSet<UserTemplate> UserTemplate { get; set; }
        //DbSet<Users> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
