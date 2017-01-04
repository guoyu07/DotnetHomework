namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class VSocietyInfoEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int MemberCount { get; set; }

        public string CreatorId { get; set; }

        public string CreatorName { get; set; }

        public string Status { get; set; }

        public string Reason { get; set; }
    }
}