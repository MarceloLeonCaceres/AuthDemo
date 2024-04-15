using Microsoft.AspNetCore.Identity;

namespace Models.Entities.AuthAppUser
{
    public class Role: IdentityRole
    {
        public Role(string name)
        {
            this.Name = name;
            this.NormalizedName = name.ToUpper();
        }
        public Role(string name, string normalizedName) 
        {
            this.Name = name;
            this.NormalizedName = normalizedName;
        }
        public Role(string Id, string name, string normalizedName)
        {
            this.Id = Id;
            this.Name = name;
            this.NormalizedName = normalizedName;
        }
        public virtual ICollection<AppUserRole>? AppUserRoles { get; set; }
    }
}
