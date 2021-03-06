﻿using System;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class MemberEntity
    {
        public int Id { get; set; }

        public string User { get; set; }

        public int Society { get; set; }

        public string EntryPost { get; set; }

        public DateTime? EntryTime { get; set; }

        public string Status { get; set; }
    }
}