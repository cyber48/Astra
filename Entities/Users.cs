using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Web
{
    public class Users
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
    }

    public class UsersMap : ClassMapping<Users>
    {
        public UsersMap()
        {
            Id(x => x.Id);
            Property(x => x.Name);
            Property(x=> x.Password);
        }
    }
}
