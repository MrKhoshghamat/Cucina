namespace Cucina.Domain.Entities.Base
{
    public class BaseEntity<TPrimaryKey>
    {
        #region Properties

        public TPrimaryKey Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}
