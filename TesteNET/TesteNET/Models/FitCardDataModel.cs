namespace TesteNET.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FitCardDataModel : DbContext
    {
        // Your context has been configured to use a 'FitCardDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TesteNET.Models.FitCardDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FitCardDataModel' 
        // connection string in the application configuration file.
        public FitCardDataModel()
            : base("name=FitCardDataModel")
        {
        }

        public System.Data.Entity.DbSet<TesteNET.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<TesteNET.Models.Estabelecimento> Estabelecimentos { get; set; }

        public System.Data.Entity.DbSet<TesteNET.Models.Estado> Estados { get; set; }

        public System.Data.Entity.DbSet<TesteNET.Models.Cidade> Cidades { get; set; }



        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}