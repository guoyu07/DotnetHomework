using System;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class VTakePartInfoEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ActivityId { get; set; }

        public Nullable<DateTime> ApplicationPeriod { get; set; }

        public string Username { get; set; }

        public int SocietyId { get; set; }

        public string ActivityName { get; set; }

        public string ActivityDescription { get; set; }

        public Nullable<DateTime> ActivityTime { get; set; }

        public string ActivityStatus { get; set; }

        public string SocietyName { get; set; }
    }
}