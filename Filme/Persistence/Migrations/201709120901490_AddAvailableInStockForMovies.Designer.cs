// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace Filme.Persistence.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AddAvailableInStockForMovies : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddAvailableInStockForMovies));
        
        string IMigrationMetadata.Id
        {
            get { return "201709120901490_AddAvailableInStockForMovies"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}