using System;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class VMemberInfoEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int SocietyId { get; set; }

        public DateTime? EntryTime { get; set; }

        public string Status { get; set; }

        public string SocietyName { get; set; }

        public string SocietyDescription { get; set; }
    }
}