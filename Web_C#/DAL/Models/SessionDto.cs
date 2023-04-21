using System.ComponentModel.DataAnnotations;

namespace Web_C_.DAL.Model
{
    public class SessionDto
    {

        public Guid DbSessionId { get; set; }

        public string? SessionContent { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastAccessed { get; set; }

        public int? UserId { get; set; }

    }
}
