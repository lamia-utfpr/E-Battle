using UnityEngine;
using Npgsql;
using UnityEngine.UI;
using System.Collections.Generic;


public class BancoDeDados
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


    private static NpgsqlConnection conexaoBanco(){
        string connectionString =
          "Server=127.0.0.1;" +
          "Database=e-battle;" +
          "User ID=postgres;" +
          "Password=senha;";

        NpgsqlConnection dbcon = new NpgsqlConnection(connectionString);
        return dbcon;
        
    }


    public void inserirTema(InputField inputfield_tema){
        
        try{
            NpgsqlConnection dbcon = conexaoBanco();
            dbcon.Open();
        
            NpgsqlCommand dbcmd = dbcon.CreateCommand();
            string tema = inputfield_tema.text;

            string sql = "INSERT INTO Temas (nome) VALUES (@p1)";

            dbcmd.CommandText = sql;
            dbcmd.Parameters.AddWithValue("p1", tema);

            dbcmd.ExecuteNonQuery();
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;

        }
        catch{
            Debug.Log("Erro na inserção do tema!");
        }
        
    }


    public List<string> mostrarTemas(){
        NpgsqlConnection dbcon = conexaoBanco();
        dbcon.Open();


        List<string> lista = new List<string>();
        NpgsqlCommand dbcmd = dbcon.CreateCommand();
        

        string sql ="SELECT nome FROM temas";
        dbcmd.CommandText = sql;
        

        NpgsqlDataReader reader = dbcmd.ExecuteReader();
        while(reader.Read()) {
                string nome = reader["nome"].ToString();
                lista.Add(nome);
        }

        return lista;
    }

    public void inserirPergunta(InputField inputfield_pergunta, InputField alt1, InputField alt2, InputField alt3, InputField alt4){

        try{
            NpgsqlConnection dbcon = conexaoBanco();
            dbcon.Open();
            NpgsqlCommand dbcmd = dbcon.CreateCommand();
            
            string pergunta = inputfield_pergunta.text;
            string alt_concatenadas;


            // VERIFICA QUANTAS ALTERNATIVAS SERÃO INSERIDAS NO BANCO DE DADOS //

            if (alt4.interactable){
                string alternativa1 = alt1.text;
                string alternativa2 = alt2.text;
                string alternativa3 = alt3.text;
                string alternativa4 = alt4.text;
                
                alt_concatenadas = string.Join("/--/", alternativa1, alternativa2, alternativa3, alternativa4);
            }else if (alt3.interactable){
                string alternativa1 = alt1.text;
                string alternativa2 = alt2.text;
                string alternativa3 = alt3.text;
                
                alt_concatenadas = string.Join("/--/", alternativa1, alternativa2, alternativa3);
            }else if (alt2.interactable){
                string alternativa1 = alt1.text;
                string alternativa2 = alt2.text;
                
                alt_concatenadas = string.Join("/--/", alternativa1, alternativa2);
                
            }else if (alt1.interactable){
                string alternativa1 = alt1.text;
                alt_concatenadas = alternativa1;
            }else{
                alt_concatenadas = "";
            }
            
            Debug.Log (alt_concatenadas);

            string sql = "INSERT INTO perguntas (id_tema, texto_pergunta, alternativas) VALUES (11, @p1, @p2)";

            dbcmd.CommandText = sql;
            dbcmd.Parameters.AddWithValue("p1", pergunta);
            dbcmd.Parameters.AddWithValue("p2", alt_concatenadas);

            dbcmd.ExecuteNonQuery();
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
        }
        catch{
            Debug.Log("Erro na inserção da pergunta!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
