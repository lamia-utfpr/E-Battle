using UnityEngine;
using Npgsql;
using UnityEngine.UI;
using System.Collections;


public class BancoDeDados : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
{
    
       // IDbConnection dbcon; ## CHANGE THIS TO
       
       
        NpgsqlConnection dbcon = conexaoBanco();

        dbcon.Open();
       //IDbCommand dbcmd = dbcon.CreateCommand();## CHANGE THIS TO
        NpgsqlCommand dbcmd = dbcon.CreateCommand();
       // requires a table to be created named employee
       // with columns firstname and lastname
       // such as,
       //        CREATE TABLE employee (
       //           firstname varchar(32),
       //           lastname varchar(32));
       string sql =
           "SELECT id_tema, nome " +
           "FROM temas";
       dbcmd.CommandText = sql;
       //IDataReader reader = dbcmd.ExecuteReader(); ## CHANGE THIS TO

      NpgsqlDataReader reader = dbcmd.ExecuteReader();
      while(reader.Read()) {
            string id_tema = reader["id_tema"].ToString();
            string nome = reader["nome"].ToString();
            Debug.Log("Código: " + id_tema + " Tema: " + nome);
       }
       // clean up
       reader.Close();
       reader = null;
       dbcmd.Dispose();
       dbcmd = null;
       dbcon.Close();
       dbcon = null;
    
    }


    private NpgsqlConnection conexaoBanco(){
        string connectionString =
          "Server=127.0.0.1;" +
          "Database=e-battle;" +
          "User ID=postgres;" +
          "Password=senha;";

        NpgsqlConnection dbcon = new NpgsqlConnection(connectionString);
        return dbcon;
        
    }


    public void inserirTema(InputField inputfield_tema){
        
        NpgsqlConnection dbcon = conexaoBanco();
        dbcon.Open();
        
        NpgsqlCommand dbcmd = dbcon.CreateCommand();
        string tema = inputfield_tema.text;

        string sql = "INSERT INTO Temas (nome) VALUES " + "(" + tema + ")";

        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();

        Debug.Log("AA");

        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
