using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqliteDemo5061893
{
    public  class LocalDbService
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;
        
        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            //Le indica al sistema que crea la tabla de nuestro contexto
            _connection.CreateTableAsync<Clientes>();
        }
        public async Task<List<Clientes>> GetClientes()
        {
            return await _connection.Table<Clientes>().ToListAsync();
        }
        //metodo para alistar los registro por id
        public async Task<Clientes> GetById(int id)
        {
            return await _connection.Table<Clientes>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //metodo para crear registro
        public async Task Create(Clientes clientes)
        {
            await _connection.InsertAsync(clientes);
        }

        //Metodo para actualizar
        public async Task Update(Clientes clientes)
        {
            await _connection.UpdateAsync(clientes);
        }

        //Metodo para eliminar
        public async Task Delete(Clientes clientes)
        {
            await _connection.DeleteAsync(clientes);
        }
    }
}
