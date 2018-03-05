using SQLite.Net.Interop;

namespace ComparePro
{
    public interface IConfig
    {
        string DirectoryDB { get; }     //Cual directorio de la BBDD para cada plataforma
        ISQLitePlatform Platform{ get; }   //Cuales son las librerias para conectar la BBDD en cada plataforma

    }
}
