using UnityEngine;
using Npgsql;
using UnityEngine.UI;
using System.Collections.Generic;


public class BancoDeDados
{

    // Start is called before the first frame update
    void Start(){
    
        NpgsqlConnection dbcon = conexaoBanco();
        

        dbcon.Open();
    
        NpgsqlCommand dbcmd = dbcon.CreateCommand();
    
       string sql = "SELECT id_tema, nome FROM temas";
       dbcmd.CommandText = sql;
       
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


    public Dictionary<int, string> mostrarTemas(){
        NpgsqlConnection dbcon = conexaoBanco();
        dbcon.Open();


        Dictionary<int, string> temas = new Dictionary<int, string>();
        NpgsqlCommand dbcmd = dbcon.CreateCommand();
        

        string sql ="SELECT * FROM temas";
        dbcmd.CommandText = sql;
    

        NpgsqlDataReader reader = dbcmd.ExecuteReader();
    
        while(reader.Read()) {
                temas.Add(
                    (int) reader["id_tema"], reader["nome"].ToString()
                );
        }

        
        foreach (KeyValuePair<int, string> item in temas){
            Debug.Log("chave: " + item.Key + " valor: " + item.Value);
        }

        return temas;
    }


    public Dictionary<int, string> pesquisarTemas(string busca){
        Dictionary<int, string> temas = new Dictionary<int, string>();
        try{
            NpgsqlConnection dbcon = conexaoBanco();
            dbcon.Open();

            NpgsqlCommand dbcmd = dbcon.CreateCommand();

            string sql = "SELECT * FROM Temas WHERE nome LIKE @p1";

            dbcmd.CommandText = sql;
            dbcmd.Parameters.AddWithValue("p1", "%" + busca + "%");

            NpgsqlDataReader reader = dbcmd.ExecuteReader();


            while(reader.Read()) {
                    temas.Add(
                        (int) reader["id_tema"], reader["nome"].ToString()
                    );
            }
            
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
        }
        catch{
            Debug.Log("Erro na pesqusia do tema!");
        }

       return temas;
    }

    public void inserirPergunta(InputField inputfield_pergunta, InputField alt1, InputField alt2, InputField alt3, InputField alt4, int[] certas){

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
                
                if (certas[0] == 1)
                    alternativa1 += "¢";
                if (certas[1] == 1)
                    alternativa2 += "¢";
                if (certas[2] == 1)
                    alternativa3 += "¢";
                if (certas[3] == 1)
                    alternativa4 += "¢";

                alt_concatenadas = string.Join("/--/", alternativa1, alternativa2, alternativa3, alternativa4);
            }else if (alt3.interactable){
                string alternativa1 = alt1.text;
                string alternativa2 = alt2.text;
                string alternativa3 = alt3.text;
                
                if (certas[0] == 1)
                    alternativa1 += "¢";
                if (certas[1] == 1)
                    alternativa2 += "¢";
                if (certas[2] == 1)
                    alternativa3 += "¢";


                alt_concatenadas = string.Join("/--/", alternativa1, alternativa2, alternativa3);
            }else if (alt2.interactable){
                string alternativa1 = alt1.text;
                string alternativa2 = alt2.text;
                
                if (certas[0] == 1)
                    alternativa1 += "¢";
                if (certas[1] == 1)
                    alternativa2 += "¢";

                alt_concatenadas = string.Join("/--/", alternativa1, alternativa2);
                
            }else if (alt1.interactable){
                string alternativa1 = alt1.text;

                if (certas[0] == 1)
                    alternativa1 += "¢";

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
