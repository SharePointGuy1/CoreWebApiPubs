using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pubs.Data.Entities;
using Xunit;
using Xunit.Abstractions;

namespace Pubs.Data.Test.xUnit {
    public class StoresTest {
        public IConfigurationRoot Configuration { get; }

        #region protected fields
        protected PubsDbContext _context;
        protected DbSet<PubsStores> _pubsStores;
        protected string _methodDisplay = "sample";
        protected string _newStoreName = "New Store";
        #endregion protected fields

        public StoresTest (ITestOutputHelper output) {
            var builder = new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json")
                .AddEnvironmentVariables ();
            builder.Build ();
            Configuration = builder.Build ();

            string connection = Configuration.GetSection ("ConnectionStrings").GetValue<string> ("Sample");
            // Console.WriteLine("\nConnection is: {0}\n", connection);
            DbContextOptions contextOptions = new DbContextOptionsBuilder ().UseSqlServer (connection).Options;
            _context = new PubsDbContext (contextOptions);

            _pubsStores = _context.PubsStores;
        }

        [Fact]
        public void CountStores () {
            // Console.WriteLine("Begin CountStores");
            // Console.WriteLine("\nGetting Stores\n");
            Assert.NotEqual (0, _pubsStores.Count ());
            // Console.WriteLine("\nThere are {0} stores", _pubsStores.Count());
            _pubsStores.Load<PubsStores> ();
            // make sure to omit ay added stores
            // Console.WriteLine("\nThere are {0} stores not named {1}",
            // _pubsStores.Count (s => s.StorName != _newStoreName), _newStoreName);
            Assert.Equal (6, _pubsStores.Count<PubsStores> (s => s.StorName != _newStoreName));
            // Console.WriteLine("End CountStores");
        }

        [Fact]
        public void AddStore () {
            // Console.WriteLine("Begin AddStore");
            // get a count of the stores
            int storeCount = _pubsStores.Count ();
            var newStore = new PubsStores ();
            newStore.StorName = _newStoreName;
            newStore.StorAddress = "123 Main";
            newStore.City = "Boston";
            newStore.State = "MA";
            newStore.Zip = "12345";

            // make sure new id does not already exist
            bool idExists = true;
            string storeId = default (string);
            while (idExists) {
                storeId = GetNewId ();
                idExists = _pubsStores.Count<PubsStores> (s => s.StorId == storeId) > 0;
            }
            newStore.StorId = storeId;

            _pubsStores.Add (newStore);
            // Console.WriteLine(string.Format("New Store id is '{0}'", newStore.StorId));

            _context.Add<PubsStores> (newStore);
            _context.SaveChanges ();
            var _pubsStores2 = _context.PubsStores;
            // Console.WriteLine("There are now {0} stores", _pubsStores.Count());

            Assert.Equal (storeCount + 1, _pubsStores2.Count ());
            // Console.WriteLine("End AddStore");
        }

        [Fact]
        public void RemoveStores () {
            // Console.WriteLine("Begin RemoveStores");

            int oldStoresCount = _pubsStores.Count<PubsStores> (s => s.StorName != _newStoreName);
            int newStoresCount = _pubsStores.Count<PubsStores> (s => s.StorName == _newStoreName);
            // Console.Write("\nThere are {0} old stores and {1} new stores\n",
            // oldStoresCount, newStoresCount);

            var newStores = _pubsStores.Where<PubsStores> (s => s.StorName == _newStoreName);
            _pubsStores.RemoveRange (newStores);
            _context.SaveChanges ();

            var pubsStores2 = _context.PubsStores;
            Assert.Equal (oldStoresCount, pubsStores2.Count<PubsStores> ());

            // Console.WriteLine("End RemoveStores");
        }

        #region helper methods
        private static string GetNewId () {
            Random random = new Random ();
            // Console.WriteLine("Current Random is {0}", random.ToString());
            random.Next (2222, 9999);
            var storeId = random.Next ().ToString ().Substring (0, 4);
            return storeId;
        }
        #endregion helper methods
    }
}