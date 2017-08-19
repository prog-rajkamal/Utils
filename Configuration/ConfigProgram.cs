using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuring
{
    class ConfigProgram
    {
        static void Main(string[] args)
        {
         //   var setts=  ConfigurationManager.GetSection("mysec");

           // var set1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            Console.WriteLine("App starts");

            //Configuration userConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            var pathOfThisExe = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Configuration userConfig2 = ConfigurationManager.OpenExeConfiguration(pathOfThisExe); // "Configuration.exe"
         
            ConfigurationFileMap abc = new ConfigurationFileMap("Configuration.exe.config");
            Configuration userConfig = ConfigurationManager.OpenMappedMachineConfiguration(abc); // "Configuration.exe"

            var userInfoSection = userConfig.GetSection("databasecreds") as DbCredInfoSection;

            var dbCredElement = new DbCredElement();

            dbCredElement.DbName = "Nmax";
            dbCredElement.DbUser= "rk105258"+DateTime.Now.Ticks;
            dbCredElement.DbPass = "pass"+DateTime.Now.ToShortTimeString();
            userConfig.Save();

            Console.WriteLine("There are {0} users in config", userInfoSection.Users.Count);
            Console.WriteLine("App ends.");

        }
    }
       

    // Code copy pasted and updated from http://stackoverflow.com/a/756763
   
    public class DbCredElement : ConfigurationElement
    {
        [ConfigurationProperty("dbname", IsRequired = true)]
        public string DbName
        {
            get { return (string)base["dbname"]; }
            set { base["dbname"] = value; }
        }

        [ConfigurationProperty("dbuser", IsRequired = true)]
        public string DbUser
        {
            get { return (string)base["dbuser"]; }
            set { base["dbuser"] = value; }
        }

        [ConfigurationProperty("dbpass", IsRequired = true)]
        public string DbPass
        {
            get { return (string)base["dbpass"]; }
            set { base["dbpass"] = value; }
        }

        internal string Key
        {
            get { return string.Format("{0}|{1}", DbName, DbUser); }
        }
    }

    [ConfigurationCollection(typeof(DbCredElement), AddItemName = "dbcred", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class DbCredElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DbCredElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DbCredElement)element).Key;
        }

        public void Add(DbCredElement element)
        {
            BaseAdd(element);
        }

        public void Clear()
        {
            BaseClear();
        }

        public int IndexOf(DbCredElement element)
        {
            return BaseIndexOf(element);
        }

        public void Remove(DbCredElement element)
        {
            if (BaseIndexOf(element) >= 0) {
                BaseRemove(element.Key);
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public DbCredElement this[int index]
        {
            get { return (DbCredElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null) {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

      
    }

    public class DbCredInfoSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty _propUserInfo = new ConfigurationProperty(
                null,
                typeof(DbCredElementCollection),
                null,
                ConfigurationPropertyOptions.IsDefaultCollection
        );

        private static ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();

        static DbCredInfoSection()
        {
            _properties.Add(_propUserInfo);
        }

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public DbCredElementCollection Users
        {
            get { return (DbCredElementCollection)base[_propUserInfo]; }
        }

        [ConfigurationProperty("quotesTemplate")]
        public ValueElement QuotesTemplate { get { return (ValueElement)base["quotesTemplate"]; } }

        [ConfigurationProperty("dealerQuotesTemplate")]
        public ValueElement DealerQuotesTemplate { get { return (ValueElement)base["dealerQuotesTemplate"]; } }

    }
    public class ValueElement : ConfigurationElement
{
    [ConfigurationProperty( "value" )]
    public string Value
    {
        get { return (string)base[ "value" ]; }
        set { base[ "value" ] = value; }
    }
}
}
