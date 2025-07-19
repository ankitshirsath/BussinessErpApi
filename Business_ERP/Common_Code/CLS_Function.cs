using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business_ERP.Common_Code
{
    public class CLS_Function
    {
        #region
        SqlConnection sqlCon = null;
        SqlCommand SqlCmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        #endregion
        public SqlConnection Connect()
        {
            string join;
            // Load appsettings.json manually
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // or Directory.GetCurrentDirectory()
                .AddJsonFile("appsettings.json")
                .Build();
            sqlCon = new SqlConnection(configuration.GetConnectionString("constr"));

            string Datasource = sqlCon.DataSource.ToString();
            string[] strValue = configuration.GetConnectionString("constr").Split(';');
            string Encpasswor = strValue[3];
            string Encpassword = strValue[3].Substring(9, 24);
            EncryptDecryptQueryString ObjPassword = new EncryptDecryptQueryString();
            string descPassword = ObjPassword.Decrypt(Encpassword);
            join = "";
            join += string.Concat("Data Source=", Datasource, ";", strValue[1], ";", strValue[2], ";", "Password=", descPassword, ";", strValue[4]);
            sqlCon.Close();
            sqlCon = new SqlConnection(join);

            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
            sqlCon.Open();

            return sqlCon;
        }
        public async Task<DataTable> FetchData(string Qry)
        {
            SqlCmd = new SqlCommand(Qry, Connect());
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataTable();
            await Task.Run(() => { da.Fill(dt); });
            return dt;
        }
    }
}
