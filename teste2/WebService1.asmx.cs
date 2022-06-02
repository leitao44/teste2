 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using Ubiety.Dns.Core;

namespace teste2
{
	/// <summary>
	/// Descrição resumida de WebService1
	/// </summary>
	[WebService(Namespace = "https://teste222.azurewebsites.net/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
	// [System.Web.Script.Services.ScriptService]
	public class WebService1 : System.Web.Services.WebService
	{

		[WebMethod]
		public string HelloWorld()
		{
			return "Olá, Mundo";
		}
		[WebMethod]
		public string Nomes(string name)
		{
			return "Olá " + name;
		}
		[WebMethod]

		public string Calculdadora(int a, int b)
		{
			int soma = a + b;
			int multiplicacao = a * b;


			return "Os resultados são so seguintes:" + "\n" + soma + "\n" + multiplicacao;
		}

		[WebMethod]
		public int Veracidade(string input)
		{
			int resposta;
			input = Console.ReadLine();
			if (input == "true")
			{
				resposta = 1;
			}
			else if (input == "false")
			{
				resposta = 2;
			}
			else
			{
				resposta = 0;
			}
			return resposta;
		}

		[WebMethod]
		public void Adivinha(int valorA, int valorB)
		{
		
			valorA = Console.Read();
			valorB = Console.Read();
			try
			{

				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Data Source = ugtf.database.windows.net, 1433; Initial Catalog = databaseAPI; User ID = leitao4; Password = 1Francisco2"].ConnectionString);
				conn.Open();
				string insertQuery = "insert into [dbo].[testeDS](valorA,valorB) values(@valorA,@valorB)";
				SqlCommand cmd = new SqlCommand(insertQuery, conn);
				cmd.Parameters.AddWithValue("@valorA", valorA);
				cmd.Parameters.AddWithValue("@valorB", valorB);

				cmd.ExecuteNonQuery();

                Console.WriteLine("Adicionado com sucesso.");

				conn.Close();

			}
			catch (Exception ex)
			{
				Console.WriteLine("error" + ex.ToString());
			}
			
		}
	}
}
