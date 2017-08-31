namespace BookLibrary.aspnetcore.Domain
{
    public class BaseEntity : IBaseEntity
    {
        public int ID { get; set; }

        public int GetID()
        {
            return ID;
        }

    }
}
