using UnityEngine;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class SQLConnector : MonoBehaviour {

	[SerializeField] string server = "localhost/~atwood";
	[SerializeField] string database = "test";
	// string user ="";
	// string pass = "";
	[SerializeField] string defaultUser = "root";
	[SerializeField] string defaultPass = "7144234alqn";
	// Use this for initialization

	MySqlConnection connection;
	void Start () {
	}

	public void ConnectSQL( string user = "" , string pass = "")
	{
		if (user == "" )
			user = defaultUser;
		if (pass == "" )
			pass = defaultPass;
		try
		{
			string connectionString = string.Format("Server = {0};port={4};Database = {1}; User ID = {2}; Password = {3};",server,database,user,pass,"3306");
			connection = new MySqlConnection(connectionString);
			connection.Open(); 
		}catch (Exception e)
		{
	        throw new Exception("Fail to connect the server. Please check if the MySql is opened..." + e.Message.ToString());  
 
		}

		//We pull up a command
	    MySqlCommand dbcmd  = new MySqlCommand("SELECT * FROM `InfoTable`", connection);
		//And we execute it
	    MySqlDataReader reader = dbcmd.ExecuteReader();

	    while(reader.Read())
	    {
	    	Debug.Log("Read " + reader.GetString(0) + "|" + reader.GetString(1) + "|" + reader.GetString(2) + "|" + reader.GetString(3) + "|" + reader.GetString(4));
	    }

	}

	void OnGUI()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
