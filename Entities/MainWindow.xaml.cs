using System.Windows;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Web
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        protected static HbmMapping GetMappings()
        {
            //There is a dynamic way to do this, but for simplicity I chose to hard code
            var mapper = new ModelMapper();

            mapper.AddMapping<UsersMap>();
            var mapping = mapper.CompileMappingFor(new[] { typeof(Users) });
            return mapping;
        }

        private void Load()
        {
            myConfiguration = new Configuration();
            myConfiguration.Configure();
            var mapping = GetMappings();
            myConfiguration.AddDeserializedMapping(mapping, "UsersMap");

            mySessionFactory = myConfiguration.BuildSessionFactory();


            mySession = mySessionFactory.OpenSession();

            using (mySession.BeginTransaction())
            {
                var user = new Users { Name = "Andrew", Password = "Andrew" };
                mySession.Save(user);

                mySession.Transaction.Commit();
            }
        }
    }
}
