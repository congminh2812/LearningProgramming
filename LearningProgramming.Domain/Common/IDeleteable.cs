using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain.Common
{
    public interface IDeleteable
    {
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
