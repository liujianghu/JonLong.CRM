
namespace JonLong.CRM.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }

        public string PermissionName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
