using UnityEngine;
using Npgsql;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class BancoDeDados : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        NpgsqlConnection dbcon = conexaoBanco();


        dbcon.Open();

        NpgsqlCommand dbcmd = dbcon.CreateCommand();

        string sql = "SELECT id_tema, nome FROM temas";
        dbcmd.CommandText = sql;

        NpgsqlDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string id_tema = reader["id_tema"].ToString();
            string nome = reader["nome"].ToString();
        }


        // clean up
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

    }


    private static NpgsqlConnection conexaoBanco()
    {
        string connectionString =
          "Server=127.0.0.1;" +
          "Database=e-battle;" +
          "User ID=postgres;" +
          "Password=senha;";

        NpgsqlConnection dbcon = new NpgsqlConnection(connectionString);
        return dbcon;

    }


    public static void inserirTema(InputField inputfield_tema)
    {

        try
        {
            NpgsqlConnection dbcon = conexaoBanco();
            dbcon.Open();

            NpgsqlCommand dbcmd = dbcon.CreateCommand();
            string tema = inputfield_tema.text;

            string sql = "SELECT * FROM Temas WHERE nome LIKE @p1";

            dbcmd.CommandText = sql;
            dbcmd.Parameters.AddWithValue("p1", tema);

            NpgsqlDataReader reader = dbcmd.ExecuteReader();

            bool achou = reader.Read();

            if (!achou)
            {
                reader.Close();
                reader = null;

                sql = "INSERT INTO Temas (nome) VALUES (@p1)";

                NpgsqlCommand dbcmd2 = dbcon.CreateCommand();

                dbcmd2.CommandText = sql;
                dbcmd2.Parameters.AddWithValue("p1", tema);
                dbcmd2.ExecuteNonQuery();

                popUp_temaInserido.mostrarPopUp();
                dbcmd2.Dispose();
                dbcmd2 = null;

            }
            else
            {
                popUp_temaJaExiste.mostrarPopUp();
            }



            dbcmd.Dispose();
            dbcmd = null;

            dbcon.Close();
            dbcon = null;

        }
        catch (Exception ex)
        {
            Debug.Log("Erro na inserção do tema!");
            Debug.Log(ex);
        }


    }


    public Dictionary<int, string> mostrarTemas()
    {
        NpgsqlConnection dbcon = conexaoBanco();
        dbcon.Open();


        Dictionary<int, string> temas = new Dictionary<int, string>();
        NpgsqlCommand dbcmd = dbcon.CreateCommand();


        string sql = "SELECT * FROM temas";
        dbcmd.CommandText = sql;


        NpgsqlDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            temas.Add(
                (int)reader["id_tema"], reader["nome"].ToString()
            );
        }


        foreach (KeyValuePair<int, string> item in temas)
        {
            Debug.Log("chave: " + item.Key + " valor: " + item.Value);
        }

        return temas;
    }


    public static Dictionary<int, string> pesquisarTemas(string busca)
    {
        Dictionary<int, string> temas = new Dictionary<int, string>();
        try
        {
            NpgsqlConnection dbcon = conexaoBanco();
            dbcon.Open();

            NpgsqlCommand dbcmd = dbcon.CreateCommand();

            string sql = "SELECT * FROM Temas WHERE nome LIKE @p1";

            dbcmd.CommandText = sql;
            dbcmd.Parameters.AddWithValue("p1", "%" + busca + "%");

            NpgsqlDataReader reader = dbcmd.ExecuteReader();


            while (reader.Read())
            {
                temas.Add((int)reader["id_tema"], reader["nome"].ToString());
            }

            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
        }
        catch
        {
            Debug.Log("Erro na pesquisa do tema!");
        }

        return temas;
    }


    public static void retornarPerguntasDeUmTema(int cod)
    {
        /*List<int> id_pergunta = new List<int>();
         List<int> id_tema = new List<int>();
         List<string> texto_pergunta = new List<string>();
         List<string> alternativas = new List<string>();*/

        List<int> id_pergunta_teste = new List<int>();
        List<int> id_tema_teste = new List<int>();
        List<string> texto_pergunta_teste = new List<string>();
        List<string> alternativas_teste = new List<string>();

        /*
                try{
                    NpgsqlConnection dbcon = conexaoBanco();
                    dbcon.Open();

                    NpgsqlCommand dbcmd = dbcon.CreateCommand();

                    string sql = "SELECT * FROM perguntas WHERE id_tema = @p1";

                    dbcmd.CommandText = sql;
                    dbcmd.Parameters.AddWithValue("p1", cod);

                    NpgsqlDataReader reader = dbcmd.ExecuteReader();


                    while(reader.Read()){
                        id_pergunta.Add((int) reader["id_pergunta"]);
                        id_tema.Add( (int) reader["id_tema"]);
                        texto_pergunta.Add( reader["texto_pergunta"].ToString());
                        alternativas.Add(reader["alternativas"].ToString()); 
                    }

                    apresentarPergunta.set_id_pergunta(id_pergunta);
                    apresentarPergunta.set_id_tema2(id_tema);
                    apresentarPergunta.set_texto_pergunta(texto_pergunta);
                    apresentarPergunta.set_alternativas(alternativas);


                    dbcmd.Dispose();
                    dbcmd = null;
                    dbcon.Close();
                    dbcon = null;

                }
                catch{
                    Debug.Log("Erro na pesquisa do tema!");
                }*/

        id_pergunta_teste.Add(0);
        id_pergunta_teste.Add(1);
        id_pergunta_teste.Add(2);
        id_pergunta_teste.Add(3);
        id_pergunta_teste.Add(4);
        id_pergunta_teste.Add(5);
        id_pergunta_teste.Add(6);
        id_pergunta_teste.Add(7);
        id_pergunta_teste.Add(8);
        id_pergunta_teste.Add(9);

        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);
        id_tema_teste.Add(0);

        texto_pergunta_teste.Add("O que é Hardware?");
        texto_pergunta_teste.Add("O que é Software?");
        texto_pergunta_teste.Add("São exemplos de Hardware:");
        texto_pergunta_teste.Add("São três exemplos de Software:");
        texto_pergunta_teste.Add("Os Software são divididos em:");
        texto_pergunta_teste.Add("São exemplos de Sistema Operacional:");
        texto_pergunta_teste.Add("Podemos definir INFORMÁTICA, como:");
        texto_pergunta_teste.Add("O que são os periféricos de Entrada?");
        texto_pergunta_teste.Add("O que são os periféricos de saída?");
        texto_pergunta_teste.Add("O que são os periféricos de Entrada e Saída?");


        alternativas_teste.Add("A parte lógica do computador/--/A parte física do computador¢/--/A parte burocrática do computador/--/As pessoas que usam o computador");
        alternativas_teste.Add("A parte lógica do computador¢/--/A parte física do computador/--/A parte burocrática do computador/--/As pessoas que usam o computador");
        alternativas_teste.Add("Power Point, Gabinete e Monitor/--/Windows, Linux e Word/--/Placa-mãe, Memória e Bateria¢/--/Bateria, Excel e Placa-mãe");
        alternativas_teste.Add("Calculadora, Ábaco e Monitor/--/Windows, Ábaco e Calculadora/--/Monitor, Memória e Power Point/--/Windows, Excel e Word¢");
        alternativas_teste.Add("Básicos, Aplicativos e Utilitários¢/--/Básicos, Aplicativos e Tabuladores/--/Físicos, Aplicativos e Utilitários/--/Tabuladores, Aplicativos e Físicos");
        alternativas_teste.Add("Word e Windows/--/Processador e Hardware/--/Ubuntu e Windows¢/--/Software e Hardware");
        alternativas_teste.Add("");
        alternativas_teste.Add("São os dispositivos que permitem que a informação saia do computador/--/São os dispositivos que permitem que a informação entre e/ou saia do computador/--/São os dispositivos que permitem que a informação entre do computador¢/--/São simples dispositivos");
        alternativas_teste.Add("São os dispositivos que permitem que a informação saia do computador¢/--/São os dispositivos que permitem que a informação entre e/ou saia do computador/--/São os dispositivos que permitem que a informação entre do computador/--/São simples dispositivos");
        alternativas_teste.Add("");

        apresentarPergunta.set_id_pergunta(id_pergunta_teste);
        apresentarPergunta.set_id_tema2(id_tema_teste);
        apresentarPergunta.set_texto_pergunta(texto_pergunta_teste);
        apresentarPergunta.set_alternativas(alternativas_teste);


    }

    public static void retornarPerguntasDeUmTemaTelaTemas(int cod)
    {
        List<int> id_pergunta = new List<int>();
        List<int> id_tema = new List<int>();
        List<string> texto_pergunta = new List<string>();
        List<string> alternativas = new List<string>();


        try
        {
            NpgsqlConnection dbcon = conexaoBanco();
            dbcon.Open();

            NpgsqlCommand dbcmd = dbcon.CreateCommand();

            string sql = "SELECT * FROM perguntas WHERE id_tema = @p1";

            dbcmd.CommandText = sql;
            dbcmd.Parameters.AddWithValue("p1", cod);

            NpgsqlDataReader reader = dbcmd.ExecuteReader();


            while (reader.Read())
            {
                id_pergunta.Add((int)reader["id_pergunta"]);
                id_tema.Add((int)reader["id_tema"]);
                texto_pergunta.Add(reader["texto_pergunta"].ToString());
                alternativas.Add(reader["alternativas"].ToString());
            }

            tabelaDosTemas.setPerguntasTema(texto_pergunta);

            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;

        }
        catch
        {
            Debug.Log("Erro na pesquisa do tema!");
        }
    }

    public static int contarTemas()
    {
        NpgsqlConnection dbcon = conexaoBanco();
        dbcon.Open();

        Dictionary<int, string> temas = new Dictionary<int, string>();
        NpgsqlCommand dbcmd = dbcon.CreateCommand();

        string sql = "SELECT * FROM temas";
        dbcmd.CommandText = sql;

        NpgsqlDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            temas.Add((int)reader["id_tema"], reader["nome"].ToString());
        }

        return temas.Count;
    }

    public static void inserirPergunta(InputField inputfield_pergunta, InputField alt1, InputField alt2, InputField alt3, InputField alt4, int[] certas, int cod_tema)
    {

        try
        {
            NpgsqlConnection dbcon = conexaoBanco();
            dbcon.Open();
            NpgsqlCommand dbcmd = dbcon.CreateCommand();

            string pergunta = inputfield_pergunta.text;
            string alt_concatenadas;


            // VERIFICA QUANTAS ALTERNATIVAS SERÃO INSERIDAS NO BANCO DE DADOS //

            if (alt4.interactable)
            {
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
            }
            else if (alt3.interactable)
            {
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
            }
            else if (alt2.interactable)
            {
                string alternativa1 = alt1.text;
                string alternativa2 = alt2.text;

                if (certas[0] == 1)
                    alternativa1 += "¢";
                if (certas[1] == 1)
                    alternativa2 += "¢";

                alt_concatenadas = string.Join("/--/", alternativa1, alternativa2);

            }
            else if (alt1.interactable)
            {
                string alternativa1 = alt1.text;

                if (certas[0] == 1)
                    alternativa1 += "¢";

                alt_concatenadas = alternativa1;
            }
            else
            {
                alt_concatenadas = "";
            }

            //Debug.Log (alt_concatenadas);

            string sql = "INSERT INTO perguntas (id_tema, texto_pergunta, alternativas) VALUES (@tema, @p1, @p2)";

            dbcmd.CommandText = sql;
            dbcmd.Parameters.AddWithValue("p1", pergunta);
            dbcmd.Parameters.AddWithValue("p2", alt_concatenadas);
            dbcmd.Parameters.AddWithValue("tema", cod_tema);


            dbcmd.ExecuteNonQuery();
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
        }
        catch
        {
            Debug.Log("Erro na inserção da pergunta!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
