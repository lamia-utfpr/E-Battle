using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class BancoDeDados : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/Banco";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();


        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        
        dbcmd.CommandText = "DROP TABLE IF EXISTS TEMA";
        dbcmd.ExecuteNonQuery();
        string q_createTable = "CREATE TABLE IF NOT EXISTS Tema (id INTEGER PRIMARY KEY AUTOINCREMENT, nome VARCHAR(255) )";
        
        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();


        //inserir na tabela
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO Tema (id, nome) VALUES (0, 'Tema 1')";
        cmnd.ExecuteNonQuery();


        IDbCommand cmnd_read = dbcon.CreateCommand();

        string query ="SELECT * FROM Tema";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read()){
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("nome: " + reader[1].ToString());
        }

        

        dbcon.Close();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
