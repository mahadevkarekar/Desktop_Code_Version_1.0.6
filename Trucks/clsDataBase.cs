using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Trucks
{
  public struct _dataItemCombo
  {
    public int Id;
    public string Value;
    public string Descrizione;

    public string Tag;

    public override string ToString() { return Value; }
  }

  public class ComboboxItem
  {
    public string Text { get; set; }
    public object Value { get; set; }

    public override string ToString()
    {
      return Text;
    }
  }

  static class clsDataBase
  {
    //Costanti
    private static string DB_NAME = clsSetting.DB_NAME;             //"trucks";
    private static string DB_USERNAME = clsSetting.DB_USERNAME;     // "trucks";
    private static string DB_PASSWORD = clsSetting.DB_PASSWORD;     // "truckspwd";
    private const int MAX_NUM_READER = 5;

    //Variabili Private
    private static string currentDbServer = "";
    private static int lastNumRowModify = 0;

    private static SqlConnection dbConn = new SqlConnection();
    private static SqlCommand[] vetDbCmd = new SqlCommand[MAX_NUM_READER];

    public static SqlDataReader[] vetDbReader = new SqlDataReader[MAX_NUM_READER];

    private static bool ShowMsgBoxError = true;


    //Variabili Pubbliche
    private static string lastError = "";

    public static string LastError
    {
      get { return clsDataBase.lastError; }
    }

    public static string CurrentDbServer
    {
      get { return clsDataBase.currentDbServer; }
    }

    public static int LastNumRowModify
    {
      get { return clsDataBase.lastNumRowModify; }
    }

    public static bool DbDisconnect()
    {
      bool bRet = false;

      CloseAll();

      try
      {
        if (dbConn.State != System.Data.ConnectionState.Closed)
          dbConn.Close();
        bRet = true;
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
      }

      return bRet;
    }

    public static bool DbConnect()
    {
      return DbConnect(clsSetting.DB_Server);
    }

    public static bool DbConnect(string DbServer)
    {
      clsDataBase.currentDbServer = DbServer;
      if (dbConn.State != System.Data.ConnectionState.Closed)
        DbDisconnect();

      return DbReConnect();
    }

    public static bool DbReConnect()
    {
      bool bRet = false;

      switch (dbConn.State)
      {
        case System.Data.ConnectionState.Broken:
          CloseAll();
          dbConn.Close();
          break;
        case System.Data.ConnectionState.Closed:
          CloseAll();
          break;
        default:
          //Connessione già aperta
          return true;
      }

      try
      {

          //if (System.IO.File.Exists(Application.StartupPath + "\\DebugCS.txt"))
          //{
          //    dbConn.ConnectionString = System.IO.File.ReadAllText(Application.StartupPath + "\\DebugCS.txt");
          //}
          //else
          //{
          //    SqlConnectionStringBuilder oSqlConnStr = new SqlConnectionStringBuilder();
          //    oSqlConnStr.Password = DB_PASSWORD;
          //    oSqlConnStr.UserID = DB_USERNAME;
          //    //oSqlConnStr.ApplicationName = DB_NAME;
          //    oSqlConnStr.InitialCatalog = DB_NAME;
          //    oSqlConnStr.DataSource = currentDbServer;
          //    oSqlConnStr.MultipleActiveResultSets = true;
          //    dbConn.ConnectionString = oSqlConnStr.ConnectionString;
          //}
          SqlConnectionStringBuilder oSqlConnStr = new SqlConnectionStringBuilder();
          oSqlConnStr.Password = DB_PASSWORD;
          oSqlConnStr.UserID = DB_USERNAME;
          oSqlConnStr.InitialCatalog = DB_NAME;
          oSqlConnStr.DataSource = currentDbServer;
          oSqlConnStr.MultipleActiveResultSets = true;
          dbConn.ConnectionString = oSqlConnStr.ConnectionString;

        dbConn.Open();
        if (dbConn.State == System.Data.ConnectionState.Open)
          bRet = true;

      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
      }

      return bRet;
    }

    public static bool TestConnection(string DBServer)
    {
      bool bRet = false;
      try
      {
        SqlConnectionStringBuilder oSqlConnStr = new SqlConnectionStringBuilder();
        oSqlConnStr.Password = DB_PASSWORD;
        oSqlConnStr.UserID = DB_USERNAME;
        oSqlConnStr.ApplicationName = DB_NAME;
        oSqlConnStr.DataSource = DBServer.Trim();


        SqlConnection myDbConn = new SqlConnection(oSqlConnStr.ConnectionString);
        myDbConn.Open();
        if (myDbConn.State == System.Data.ConnectionState.Open)
          bRet = true;
        myDbConn.Close();
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
      }

      return bRet;
    }

    public static object ExecuteScalar(string SqlCommand)
    {
      object RetValue = null;

      try
      {
        SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.Connection = dbConn;
        sqlCmd.CommandType = System.Data.CommandType.Text;
        sqlCmd.CommandText = SqlCommand;
        RetValue = sqlCmd.ExecuteScalar();
        sqlCmd.Dispose();
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore nella gestione del DB.\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return RetValue;
    }

    public static bool ExecuteNonQuery(string SqlCommand)
    {
      bool bRet = false;

      try
      {
        SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.Connection = dbConn;
        sqlCmd.CommandType = System.Data.CommandType.Text;
        sqlCmd.CommandText = SqlCommand;
        lastNumRowModify = sqlCmd.ExecuteNonQuery();
        sqlCmd.Dispose();
        bRet = true;
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore nella gestione del DB.\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return bRet;
    }

    public static bool ExecuteQuery(string SqlCommand, int Index = 0)
    {
      bool bRet = false;

      if (vetDbCmd[Index] != null)
      {
        lastError = "Recordset già usato";
        if (ShowMsgBoxError)
          MessageBox.Show("Errore nella gestione del DB.\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);

        return false;
      }

      try
      {
        vetDbCmd[Index] = new System.Data.SqlClient.SqlCommand();
        vetDbCmd[Index].Connection = dbConn;
        vetDbCmd[Index].CommandText = SqlCommand;
        vetDbReader[Index] = vetDbCmd[Index].ExecuteReader();
        bRet = true;
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        CloseDataReader(Index);
        if (ShowMsgBoxError)
          MessageBox.Show("Errore nella gestione del DB.\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return bRet;
    }

    public static void CloseDataReader(int Index = 0)
    {
      if (vetDbReader[Index] != null)
      {
        if (!vetDbReader[Index].IsClosed) vetDbReader[Index].Close();
        vetDbReader[Index].Dispose();
        vetDbReader[Index] = null;
      }

      if (vetDbCmd[Index] != null)
      {
        vetDbCmd[Index].Dispose();
        vetDbCmd[Index] = null;
      }
    }

    public static int GetFreeDbReaderIndex()
    {
      int retValue = -1;
      for (int i = 0; i < MAX_NUM_READER && retValue == -1; i++)
      {
        if (vetDbReader[i] == null && vetDbCmd[i] == null)
          retValue = i;
      }

      return retValue;
    }

    private static void CloseAll()
    {
      for (int i = 0; i < MAX_NUM_READER; i++)
      {
        CloseDataReader(i);
      }
    }

    public static string GetStringValue(string Field, int Index = 0)
    {
      return GetStringValue(vetDbReader[Index].GetOrdinal(Field), Index);
    }

    public static string GetStringValue(int IdCol, int Index = 0)
    {
      string RetValue = "";

      try
      {
        if (!vetDbReader[Index].IsDBNull(IdCol)) RetValue = vetDbReader[Index].GetString(IdCol);
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore DB [GetStringValue].\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return RetValue;
    }

    public static bool GetBoolValue(string Field, int Index = 0)
    {
      return GetBoolValue(vetDbReader[Index].GetOrdinal(Field), Index);
    }

    public static bool GetBoolValue(int IdCol, int Index = 0)
    {
      bool RetValue = false;

      try
      {
        if (!vetDbReader[Index].IsDBNull(IdCol)) RetValue = vetDbReader[Index].GetBoolean(IdCol);
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore DB [GetStringValue].\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return RetValue;
    }

    public static int GetIntValue(string Field, int Index = 0)
    {
      return GetIntValue(vetDbReader[Index].GetOrdinal(Field), Index);
    }

    public static int GetIntValue(int IdCol, int Index = 0)
    {
      int RetValue = 0;

      try
      {
        if (!vetDbReader[Index].IsDBNull(IdCol)) RetValue = vetDbReader[Index].GetInt32(IdCol);
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore DB [GetStringValue].\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return RetValue;
    }

    public static DateTime GetDateValue(string Field, int Index = 0)
    {
      return GetDateValue(vetDbReader[Index].GetOrdinal(Field), Index);
    }

    public static DateTime GetDateValue(int IdCol, int Index = 0)
    {
      DateTime RetValue = DateTime.MinValue;

      try
      {
        if (!vetDbReader[Index].IsDBNull(IdCol)) RetValue = vetDbReader[Index].GetDateTime(IdCol);
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore DB [GetDataValue].\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return RetValue;
    }

    public static decimal GetValutaValue(string Field, int Index = 0)
    {
      return GetValutaValue(vetDbReader[Index].GetOrdinal(Field), Index);
    }

    public static decimal GetValutaValue(int IdCol, int Index = 0)
    {
      decimal RetValue = 0;

      try
      {
        if (!vetDbReader[Index].IsDBNull(IdCol)) RetValue = Math.Round(vetDbReader[Index].GetDecimal(IdCol), 2);
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore DB [GetStringValue].\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return RetValue;
    }

    public static decimal GetDecimalValue(string Field, int Index = 0)
    {
      return GetDecimalValue(vetDbReader[Index].GetOrdinal(Field), Index);
    }

    public static decimal GetDecimalValue(int IdCol, int Index = 0)
    {
      decimal RetValue = 0;

      try
      {
        if (!vetDbReader[Index].IsDBNull(IdCol)) RetValue = vetDbReader[Index].GetDecimal(IdCol);
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore DB [GetStringValue].\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return RetValue;
    }

    private static string GetQueryPopolaItem(clsGlobal.ETypeTable Type)
    {
      string strSql = "";

      switch (Type)
      {
        case clsGlobal.ETypeTable.TT_IVA:
          strSql = "Select ID, cast(IVA as nvarchar) as Valore, IVA_Descrizione as Descr, Iva_cod_esenzione As Tag From Iva Where IVA_Cancellato = 0 order by IVA";
          break;
        case clsGlobal.ETypeTable.TT_UNIT_MISURA:
          strSql = "Select ID, UM as Valore, UM_Descrizione as Descr, '' As Tag From Um Where Um_Cancellato = 0 order by UM";
          break;
        case clsGlobal.ETypeTable.TT_CATEGORIA:
          strSql = "Select ID, Categoria as Valore, Categoria_Descrizione as Descr From Categorie Where Categoria_Cancellato = 0 order by Categoria";
          break;
        case clsGlobal.ETypeTable.TT_ASSICURAZIONI:
          break;
        case clsGlobal.ETypeTable.TT_TIP_PAGAMENTO:
          strSql = "Select ID, Tipi_pagam_descr as Valore, case when tipi_pagam_stampa_cliente=1 then 'Stampa c/c Cliente' when tipi_pagam_stampa_az=1 then 'Stampa c/c Azienda' else 'Nessuna stampa c/c' end as Descr, IsNull(Tipi_pagam_condizioni, ' ') + ';' + IsNull(Tipi_pagam_modalita, ' ') As Tag From Tipi_pagamento Where Tipi_pagam_cancellato = 0 order by Tipi_pagam_descr";
          break;
        case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
          strSql = "Select ID, case Mod_pagamento_cassa when 1 then 'CASSA' else 'BANCA' end + ' - ' + Mod_pagamento_descr as Valore, Mod_pagamento_descr as Descr From Mod_pagamenti Where Mod_pagamento_cancellato = 0 order by case Mod_pagamento_cassa when 1 then 'CASSA' else 'BANCA' end + ' - ' + Mod_pagamento_descr";
          break;
        case clsGlobal.ETypeTable.TT_BANCHE_AZ:
          strSql = "Select ID, banca_descrizione as Valore, banca_iban as Descr, '' As Tag From Banca_azienda Where banca_cancellato = 0 order by banca_iban";
          break;
        case clsGlobal.ETypeTable.TT_DISTANZE:
          //strSql = "Select d.ID, a.Loc_luogo + ' - ' + b.Loc_luogo + '   Km ' + cast(d.Dtt_distanze_km as varchar) as Valore , cast(d.Dtt_distanze_Km as nvarchar) as Descr From Dtt_distanze d left join Localita a on d.ID_localita_A = a.Id left join Localita b on d.ID_localita_B = b.Id Where Dtt_distanze_cancellato = 0";
          strSql = "Select d.ID, a.Loc_luogo + ' - ' + b.Loc_luogo as Valore , cast(d.Dtt_distanze_Km as nvarchar) as Descr, '' As Tag From Dtt_distanze d left join Localita a on d.ID_localita_A = a.Id left join Localita b on d.ID_localita_B = b.Id Where Dtt_distanze_cancellato = 0 order by a.Loc_luogo + ' - ' + b.Loc_luogo";
          break;
        case clsGlobal.ETypeTable.TT_LOCALITA:
          strSql = "Select ID, Loc_luogo as Valore, Loc_descrizione as Descr, '' As Tag From Localita Where Loc_cancellato = 0 order by Loc_luogo";
          break;
        case clsGlobal.ETypeTable.TT_AUTOMEZZI:
          strSql = "Select ID, truck_targa as Valore, truck_descrizione as Descr, '' As Tag From Truck Where truck_cancellato = 0 order by truck_targa";
          break;
        case clsGlobal.ETypeTable.TT_ARTICOLI:
          strSql = "Select ID, art_cod as Valore, art_descrizione as Descr, '' As Tag From Articoli Where art_cancellato = 0 order by art_cod";
          break;
        case clsGlobal.ETypeTable.TT_ARTICOLI_DESC_COD:
          strSql = "Select ID, art_cod + ' - ' + art_descrizione as Valore, art_descrizione as Descr From Articoli Where art_cancellato = 0 order by art_cod";
          break;
        case clsGlobal.ETypeTable.TT_CLIENTI:
          strSql = "Select ID, Case When (IsNull(Cln_rag_soc, '') = '') Then Cln_nome + ' ' + Cln_Cognome Else Cln_rag_soc End as Valore, 'Partita Iva: ' + Cln_iva as Descr, '' As Tag From Clienti Where Cln_cancellato = 0 order by Case When (IsNull(Cln_rag_soc, '') = '') Then Cln_nome + ' ' + Cln_Cognome Else Cln_rag_soc End";
          break;
        case clsGlobal.ETypeTable.TT_IVA_DESCR:
          strSql = "Select ID, IVA_Descrizione as Valore,  cast(IVA as nvarchar) as Descr, IsNull(Iva_cod_esenzione, '') As Tag From Iva Where IVA_Cancellato = 0 order by IVA_Descrizione";
          break;
        case clsGlobal.ETypeTable.TT_ESENZIONI:
          strSql = "Select ID, Esenzioni_descrizione as Valore, Esenzioni_note as Descr From Esenzioni Where Esenzioni_cancellato = 0 order by Esenzioni_descrizione";
          break;
        case clsGlobal.ETypeTable.XML_REGIME:
          strSql = "Select ID, Codice as Valore, Descrizione as Descr From XML_RegimeFiscale order by Descrizione";
          break;
        case clsGlobal.ETypeTable.XML_NAZIONE:
          strSql = "Select ID, Codice as Valore, Descrizione as Descr From XML_Nazione order by Descrizione";
          break;
        case clsGlobal.ETypeTable.XML_DIVISA:
          strSql = "Select ID, Codice as Valore, Descrizione as Descr From XML_Divisa order by Descrizione";
          break;
        case clsGlobal.ETypeTable.XML_NATURA:
          strSql = "Select ID, Codice as Valore, Descrizione as Descr From XML_Natura order by Descrizione";
          break;
        case clsGlobal.ETypeTable.XML_COND_PAGAMENTO:
          strSql = "Select ID, Codice as Valore, Descrizione as Descr From XML_CondizioniPagamento order by Descrizione";
          break;
        case clsGlobal.ETypeTable.XML_MOD_PAGAMENTO:
          strSql = "Select ID, Codice as Valore, Descrizione as Descr From XML_ModalitaPagamento order by Descrizione";
          break;
        case clsGlobal.ETypeTable.TT_DESCR_BREVI:
          strSql = "Select ID, DescrFatture_Breve as Valore,  DescrFatture_Descrizione as Descr From DescrFatture Where DescrFatture_Cancellato = 0 order by DescrFatture_Breve";
          break;
        default:
          break;
      }

      return strSql;
    }

    public static int GetLastId(clsGlobal.ETypeTable Type)
    {
      string strSql = "";

      switch (Type)
      {
        case clsGlobal.ETypeTable.TT_IVA:
          strSql = "Select Max(ID) from IVA ";
          break;
        case clsGlobal.ETypeTable.TT_CLIENTI:
          strSql = "Select Max(ID) from Clienti ";
          break;
        case clsGlobal.ETypeTable.TT_AUTOMEZZI:
          strSql = "Select Max(ID) from Truck ";
          break;
        case clsGlobal.ETypeTable.TT_ARTICOLI:
          strSql = "Select Max(ID) from Articoli ";
          break;
        case clsGlobal.ETypeTable.TT_UNIT_MISURA:
          strSql = "Select Max(ID) from Um ";
          break;
        case clsGlobal.ETypeTable.TT_CATEGORIA:
          strSql = "Select Max(ID) from Categorie ";
          break;
        case clsGlobal.ETypeTable.TT_ASSICURAZIONI:
          break;
        case clsGlobal.ETypeTable.TT_TIP_PAGAMENTO:
          strSql = "Select Max(ID) from Tipi_pagamento ";
          break;
        case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
          strSql = "Select Max(ID) from Mod_pagamenti ";
          break;
        case clsGlobal.ETypeTable.TT_LOCALITA:
          strSql = "Select Max(ID) from Localita ";
          break;
        case clsGlobal.ETypeTable.TT_ESENZIONI:
          strSql = "Select Max(ID) from Esenzioni ";
          break;
        case clsGlobal.ETypeTable.TT_BANCHE_AZ:
          strSql = "Select Max(ID) from Banca_azienda ";
          break;
        case clsGlobal.ETypeTable.TT_DESCR_BREVI:
          strSql = "Select Max(ID) From DescrFatture ";
          break;
        default:
          break;
      }

      return Convert.ToInt32(ExecuteScalar(strSql));
    }


    public static bool SaveItemIva(decimal Valore, string Descr, string CodNatura, int ID = 0)
    {
      string strSql = "";

      if (Valore != 0)
        CodNatura = "";

      if (ID > 0)
      {
        //Update
        strSql = "Update IVA set " +
                    "IVA = " + Valore.ToString().Replace(",", ".") +
                    ", IVA_Descrizione = '" + Descr.Replace("'", "''") + "'" +
                    ", Iva_cod_esenzione = '" + CodNatura.Replace("'", "''") + "'" +
                    " where ID = " + ID.ToString();
      }
      else
      {
        //Insert
        strSql = "Insert Into IVA (IVA, IVA_Descrizione, Iva_cod_esenzione) Values (" +
                    Valore.ToString().Replace(",", ".") +
                    ", '" + Descr.Replace("'", "''") + "'" +
                    ", '" + CodNatura.Replace("'", "''") + "'" +
                    ")";
      }

      return ExecuteNonQuery(strSql);
    }

    /// <summary>
    /// Seleziona l'elemento della combo in base al codice passato per parametro
    /// </summary>
    /// <param name="objCombo">COmboBox</param>
    /// <param name="Codice">Codice parametro</param>
    /// <returns><c>True</c> In caso di identificazione del parametro</returns>
    /// <remarks>Funziona con Combo che utilizzano gli item di tipo <c>ComboboxItem</c></remarks>
    public static bool SelezionaComboItem_2(ComboBox objCombo, string Codice)
    {
      for (int i = 0; i < objCombo.Items.Count; i++)
      {
        if ((string)((ComboboxItem)objCombo.Items[i]).Value == Codice)
        {
          objCombo.SelectedIndex = i;
          return true;
        }
      }

      return false;
    }

    public static bool SaveItem(clsGlobal.ETypeTable Type, string Valore, string Descr, int ID = 0)
    {
      string strSql = "";

      switch (Type)
      {
        case clsGlobal.ETypeTable.TT_IVA:
          if (ID > 0)
          {
            //Update
            strSql = "Update IVA set " +
                        "IVA = " + Valore.Replace(",", ".") +
                        ", IVA_Descrizione = '" + Descr.Replace("'", "''") + "'" +
                        " where ID = " + ID.ToString();
          }
          else
          {
            //Insert
            strSql = "Insert Into IVA (IVA, IVA_Descrizione) Values (" +
                        Valore.Replace(",", ".") +
                        ", '" + Descr.Replace("'", "''") + "'" +
                        ")";
          }
          break;
        case clsGlobal.ETypeTable.TT_UNIT_MISURA:
          if (ID > 0)
          {
            //Update
            strSql = "Update Um set " +
                        "UM= '" + Valore.Replace("'", "''") + "'" +
                        ", UM_Descrizione = '" + Descr.Replace("'", "''") + "'" +
                        " where ID = " + ID.ToString();
          }
          else
          {
            //Insert
            strSql = "Insert Into Um (UM, UM_Descrizione) Values (" +
                        "'" + Valore.Replace("'", "''") + "'" +
                        ", '" + Descr.Replace("'", "''") + "'" +
                        ")";
          }
          break;
        case clsGlobal.ETypeTable.TT_CATEGORIA:
          if (ID > 0)
          {
            //Update
            strSql = "Update Categorie set " +
                        "Categoria= '" + Valore.Replace("'", "''") + "'" +
                        ", Categoria_Descrizione = '" + Descr.Replace("'", "''") + "'" +
                        " where ID = " + ID.ToString();
          }
          else
          {
            //Insert
            strSql = "Insert Into Categorie (Categoria, Categoria_Descrizione) Values (" +
                        "'" + Valore.Replace("'", "''") + "'" +
                        ", '" + Descr.Replace("'", "''") + "'" +
                        ")";
          }
          break;
        case clsGlobal.ETypeTable.TT_ASSICURAZIONI:
          break;
        case clsGlobal.ETypeTable.TT_TIP_PAGAMENTO:
          strSql = "Select ID, IVA, IVA_Descrizione as Descr From Categorie Where IVA_Cancellato = 0";
          break;
        case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
          if (ID > 0)
          {
            //Update
            strSql = "Update Mod_pagamenti set ";
            if (Valore == "1")
              strSql += "Mod_pagamento_cassa = 1, Mod_pagamento_banca = 0";
            else
              strSql += "Mod_pagamento_cassa = 0, Mod_pagamento_banca = 1";

            strSql += ", Mod_pagamento_descr = '" + Descr.Replace("'", "''") + "'" +
                        " where ID = " + ID.ToString();
          }
          else
          {
            //Insert
            strSql = "Insert Into Mod_pagamenti (Mod_pagamento_cassa, Mod_pagamento_banca, Mod_pagamento_descr) Values (";
            if (Valore == "1")
              strSql += "1, 0";
            else
              strSql += "0, 1";

            strSql += ", '" + Descr.Replace("'", "''") + "'" +
                        ")";
          }
          break;
        case clsGlobal.ETypeTable.TT_LOCALITA:
          if (ID > 0)
          {
            //Update
            strSql = "Update Localita set " +
                        "Loc_luogo= '" + Valore.Replace("'", "''") + "'" +
                        ", Loc_descrizione = '" + Descr.Replace("'", "''") + "'" +
                        " where ID = " + ID.ToString();
          }
          else
          {
            //Insert
            strSql = "Insert Into Localita (Loc_luogo, Loc_descrizione) Values (" +
                        "'" + Valore.Replace("'", "''") + "'" +
                        ", '" + Descr.Replace("'", "''") + "'" +
                        ")";
          }
          break;
        case clsGlobal.ETypeTable.TT_ESENZIONI:
          if (ID > 0)
          {
            //Update
            strSql = "Update Esenzioni set " +
                        "Esenzioni_descrizione = '" + Valore.Replace("'", "''") + "'" +
                        ", Esenzioni_note = '" + Descr.Replace("'", "''") + "'" +
                        " where ID = " + ID.ToString();
          }
          else
          {
            //Insert
            strSql = "Insert Into Esenzioni (Esenzioni_descrizione, Esenzioni_note) Values (" +
                        "'" + Valore.Replace("'", "''") + "'" +
                        ", '" + Descr.Replace("'", "''") + "'" +
                        ")";
          }
          break;
        case clsGlobal.ETypeTable.TT_DESCR_BREVI:
          if (ID > 0)
          {
            //Update
            strSql = "Update DescrFatture set " +
                        "DescrFatture_Breve = '" + Valore.Replace(",", ".") + "'" +
                        ", DescrFatture_Descrizione = '" + Descr.Replace("'", "''") + "'" +
                        " where ID = " + ID.ToString();
          }
          else
          {
            //Insert
            strSql = "Insert Into DescrFatture (DescrFatture_Breve, DescrFatture_Descrizione) Values ('" +
                        Valore.Replace(",", ".") +
                        "', '" + Descr.Replace("'", "''") + "'" +
                        ")";
          }
          break;
        default:
          break;
      }

      return ExecuteNonQuery(strSql);
    }

    public static bool DeleteItem(clsGlobal.ETypeTable Type, int ID)
    {
      string strSql = "";

      switch (Type)
      {
        case clsGlobal.ETypeTable.TT_IVA:
          strSql = "Update IVA set " +
                      "IVA_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        case clsGlobal.ETypeTable.TT_BANCHE_AZ:
          strSql = "Update Banca_azienda set " +
                      "banca_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;

        case clsGlobal.ETypeTable.TT_UNIT_MISURA:
          strSql = "Update Um set " +
                      "UM_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        case clsGlobal.ETypeTable.TT_CATEGORIA:
          strSql = "Update Categorie set " +
                      "Categoria_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        case clsGlobal.ETypeTable.TT_ASSICURAZIONI:
          break;
        case clsGlobal.ETypeTable.TT_TIP_PAGAMENTO:
          //strSql = "Select ID, IVA, IVA_Descrizione as Descr From Categorie Where IVA_Cancellato = 0";
          break;
        case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
          strSql = "Update Mod_pagamenti set " +
                      "Mod_pagamento_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        case clsGlobal.ETypeTable.TT_LOCALITA:
          strSql = "Update Localita set " +
                      "Loc_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        case clsGlobal.ETypeTable.TT_DISTANZE:
          strSql = "Update Dtt_distanze set " +
                      "Dtt_distanze_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        case clsGlobal.ETypeTable.TT_ESENZIONI:
          strSql = "Update Esenzioni set " +
                      "Esenzioni_cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        case clsGlobal.ETypeTable.TT_DESCR_BREVI:
          strSql = "Update DescrFatture set " +
                      "DescrFatture_Cancellato = 1" +
                      " where ID = " + ID.ToString();
          break;
        default:
          break;
      }

      return ExecuteNonQuery(strSql);
    }

    public static bool PopolaCombo(ComboBox objCombo, clsGlobal.ETypeTable Type)
    {
      string strSql = GetQueryPopolaItem(Type);

      return PopolaCombo(objCombo, strSql);
    }

    public static bool PopolaCombo(ComboBox objCombo, string SqlQuery)
    {
      bool RetValue = false;
      string strSql = SqlQuery;

      objCombo.Items.Clear();

      //Inserisco elemento vuoto
      _dataItemCombo NewItemVuoto = new _dataItemCombo();
      NewItemVuoto.Id = 0;
      NewItemVuoto.Value = "";
      NewItemVuoto.Descrizione = "";
      objCombo.Items.Add(NewItemVuoto);
      int dbReaderIndex = GetFreeDbReaderIndex();
      if (ExecuteQuery(strSql, dbReaderIndex))
      {
        while (vetDbReader[dbReaderIndex].Read())
        {
          _dataItemCombo NewItem = new _dataItemCombo();

          NewItem.Id = GetIntValue("ID", dbReaderIndex);
          NewItem.Value = GetStringValue("Valore", dbReaderIndex);
          NewItem.Descrizione = GetStringValue("Descr", dbReaderIndex);

          try
          {
            NewItem.Tag = GetStringValue("Tag", dbReaderIndex);
          }
          catch (Exception e)
          {
            // Non fare nulla: campo non obbligatorio
          }

          if (objCombo.Tag != null && NewItem.Id.ToString() == objCombo.Tag.ToString())
            objCombo.SelectedIndex = objCombo.Items.Add(NewItem);
          else
            objCombo.Items.Add(NewItem);
        }

      }
      CloseDataReader(dbReaderIndex);

      if (objCombo.SelectedIndex == -1) objCombo.SelectedIndex = 0;
      return RetValue;
    }

    public static bool PopolaComboPdfFatture(ComboBox objCombo)
    {
      bool RetValue = false;
      string strSql = GetQueryPopolaItem(clsGlobal.ETypeTable.TT_DESCR_BREVI);

      objCombo.Items.Clear();

      //Inserisco elemento vuoto
      _dataItemCombo NewItemVuoto = new _dataItemCombo();
      NewItemVuoto.Id = 0;
      NewItemVuoto.Value = "";
      NewItemVuoto.Descrizione = "";
      NewItemVuoto.Tag = "";
      objCombo.Items.Add(NewItemVuoto);

      NewItemVuoto.Id = 1;
      NewItemVuoto.Value = "Modello 1 - Dettaglio senza codice articolo";
      NewItemVuoto.Descrizione = "Modello 1 - Dettaglio senza codice articolo";
      NewItemVuoto.Tag = "";
      if (objCombo.Tag != null && "1" == objCombo.Tag.ToString())
        objCombo.SelectedIndex = objCombo.Items.Add(NewItemVuoto);
      else
        objCombo.Items.Add(NewItemVuoto);


      NewItemVuoto.Id = 2;
      NewItemVuoto.Value = "Modello 2 - Dettaglio con codice articolo";
      NewItemVuoto.Descrizione = "Modello 2 - Dettaglio con codice articolo";
      NewItemVuoto.Tag = "";
      if (objCombo.Tag != null && "2" == objCombo.Tag.ToString())
        objCombo.SelectedIndex = objCombo.Items.Add(NewItemVuoto);
      else
        objCombo.Items.Add(NewItemVuoto);

      int dbReaderIndex = GetFreeDbReaderIndex();
      if (ExecuteQuery(strSql, dbReaderIndex))
      {
        while (vetDbReader[dbReaderIndex].Read())
        {
          _dataItemCombo NewItem = new _dataItemCombo();

          NewItem.Id = 2 + GetIntValue("ID", dbReaderIndex);
          NewItem.Value = "Modello Breve - " + GetStringValue("Valore", dbReaderIndex);
          NewItem.Descrizione = GetStringValue("Descr", dbReaderIndex);
          NewItem.Tag = GetStringValue("Descr", dbReaderIndex);

          if (objCombo.Tag != null && NewItem.Id.ToString() == objCombo.Tag.ToString())
            objCombo.SelectedIndex = objCombo.Items.Add(NewItem);
          else
            objCombo.Items.Add(NewItem);
        }

      }
      CloseDataReader(dbReaderIndex);

      if (objCombo.SelectedIndex == -1) objCombo.SelectedIndex = 0;
      return RetValue;
    }

    public static bool PopolaComboXmlFatture(ComboBox objCombo)
    {
      bool RetValue = false;
      string strSql = GetQueryPopolaItem(clsGlobal.ETypeTable.TT_DESCR_BREVI);

      objCombo.Items.Clear();

      //Inserisco elemento vuoto
      _dataItemCombo NewItemVuoto = new _dataItemCombo();
      NewItemVuoto.Id = 0;
      NewItemVuoto.Value = "";
      NewItemVuoto.Descrizione = "";
      NewItemVuoto.Tag = "";
      objCombo.Items.Add(NewItemVuoto);

      NewItemVuoto.Id = 1;
      NewItemVuoto.Value = "Modello 1 - Dettaglio senza codici ariticolo";
      NewItemVuoto.Descrizione = "Modello 1 - Dettaglio senza codici ariticolo";
      NewItemVuoto.Tag = "";
      if (objCombo.Tag != null && "1" == objCombo.Tag.ToString())
        objCombo.SelectedIndex = objCombo.Items.Add(NewItemVuoto);
      else
        objCombo.Items.Add(NewItemVuoto);

      int dbReaderIndex = GetFreeDbReaderIndex();
      if (ExecuteQuery(strSql, dbReaderIndex))
      {
        while (vetDbReader[dbReaderIndex].Read())
        {
          _dataItemCombo NewItem = new _dataItemCombo();

          NewItem.Id = 1 + GetIntValue("ID", dbReaderIndex);
          NewItem.Value = "Modello Breve - " + GetStringValue("Valore", dbReaderIndex);
          NewItem.Descrizione = GetStringValue("Descr", dbReaderIndex);
          NewItem.Tag = GetStringValue("Descr", dbReaderIndex);

          if (objCombo.Tag != null && NewItem.Id.ToString() == objCombo.Tag.ToString())
            objCombo.SelectedIndex = objCombo.Items.Add(NewItem);
          else
            objCombo.Items.Add(NewItem);
        }

      }
      CloseDataReader(dbReaderIndex);

      if (objCombo.SelectedIndex == -1) objCombo.SelectedIndex = 0;
      return RetValue;
    }

    public static bool PopolaCombo_2(ComboBox objCombo, clsGlobal.ETypeTable Type)
    {
      string strSql = GetQueryPopolaItem(Type);

      return PopolaCombo_2(objCombo, strSql);
    }

    /// <summary>
    /// Funzione per il popolamento di una Combo Box in base all'accoppiata Valore/Descrizione
    /// </summary>
    /// <param name="objCombo">ComboBox da popolare</param>
    /// <param name="SqlQuery">Stringa con la query per il caricamento dei dati</param>
    /// <returns><c>True</c> in caso di completo caricamento</returns>
    /// <remarks>Gli item creati sono del tipo <c>ComboboxItem</c> e gli elementi della combo visualizzano il campo Descr della query</remarks>
    public static bool PopolaCombo_2(ComboBox objCombo, string SqlQuery)
    {
      bool RetValue = false;
      string strSql = SqlQuery;

      objCombo.Items.Clear();

      //Inserisco elemento vuoto
      ComboboxItem NewItemVuoto = new ComboboxItem();
      NewItemVuoto.Value = "";
      NewItemVuoto.Text = "";
      objCombo.Items.Add(NewItemVuoto);
      int dbReaderIndex = GetFreeDbReaderIndex();
      if (ExecuteQuery(strSql, dbReaderIndex))
      {
        while (vetDbReader[dbReaderIndex].Read())
        {
          ComboboxItem NewItem = new ComboboxItem();

          string strCode = GetStringValue("Valore", dbReaderIndex);

          NewItem.Value = strCode;
          NewItem.Text = GetStringValue("Descr", dbReaderIndex);

          // Identificazione dell'eventuale elemento da selezionare
          if (objCombo.Tag != null && strCode == objCombo.Tag.ToString())
            objCombo.SelectedIndex = objCombo.Items.Add(NewItem);
          else
            objCombo.Items.Add(NewItem);
        }

      }
      CloseDataReader(dbReaderIndex);

      if (objCombo.SelectedIndex == -1) objCombo.SelectedIndex = 0;
      return RetValue;
    }

    public static bool PopolaCombo(DataGridViewComboBoxColumn objCombo, clsGlobal.ETypeTable Type)
    {
      string strSql = GetQueryPopolaItem(Type);

      return PopolaCombo(objCombo, strSql);
    }

    public static bool PopolaCombo(DataGridViewComboBoxColumn objCombo, string SqlQuery)
    {
      bool RetValue = false;
      string strSql = SqlQuery;

      objCombo.Items.Clear();

      //Inserisco elemento vuoto
      _dataItemCombo NewItemVuoto = new _dataItemCombo();
      NewItemVuoto.Id = 0;
      NewItemVuoto.Value = "";
      NewItemVuoto.Descrizione = "";
      objCombo.Items.Add(NewItemVuoto);
      int dbReaderIndex = GetFreeDbReaderIndex();
      if (ExecuteQuery(strSql, dbReaderIndex))
      {
        while (vetDbReader[dbReaderIndex].Read())
        {
          _dataItemCombo NewItem = new _dataItemCombo();

          NewItem.Id = GetIntValue("ID", dbReaderIndex);
          NewItem.Value = GetStringValue("Valore", dbReaderIndex);
          NewItem.Descrizione = GetStringValue("Descr", dbReaderIndex);

          //if (objCombo.Tag != null && NewItem.Id.ToString() == objCombo.Tag.ToString())
          //    objCombo.SelectedIndex = objCombo.Items.Add(NewItem);
          //else
          objCombo.Items.Add(NewItem);
        }

      }
      CloseDataReader(dbReaderIndex);

      //if (objCombo.SelectedIndex == -1) objCombo.SelectedIndex = 0;
      objCombo.ValueMember = "Value";
      objCombo.DisplayMember = "Value";


      return RetValue;
    }

    public static bool PopolaListItem(ListBox objCombo, clsGlobal.ETypeTable Type)
    {
      string strSql = GetQueryPopolaItem(Type);
      return PopolaListItem(objCombo, strSql);
    }

    public static bool PopolaListItem(ListBox objCombo, string SqlQuery)
    {
      bool RetValue = false;
      int dbReaderIndex = GetFreeDbReaderIndex();
      if (ExecuteQuery(SqlQuery, dbReaderIndex))
      {
        objCombo.Items.Clear();
        while (vetDbReader[dbReaderIndex].Read())
        {
          _dataItemCombo NewItem = new _dataItemCombo();

          NewItem.Id = GetIntValue("ID", dbReaderIndex);
          NewItem.Value = GetStringValue("Valore", dbReaderIndex);
          NewItem.Descrizione = GetStringValue("Descr", dbReaderIndex);

          try
          {
            NewItem.Tag = GetStringValue("Tag", dbReaderIndex);
          }
          catch (Exception e)
          {
            // Non fare nulla: campo non obbligatorio
          }

          if (objCombo.Tag != null && NewItem.Id.ToString() == objCombo.Tag.ToString())
            objCombo.SelectedIndex = objCombo.Items.Add(NewItem);
          else
            objCombo.Items.Add(NewItem);
        }
      }
      CloseDataReader(dbReaderIndex);
      if (objCombo.SelectedIndex == -1 && objCombo.Items.Count > 0)
        objCombo.SelectedIndex = 0;
      return RetValue;
    }

    public static DataTable GetDataTable(string sqlCommand)
    {
      DataTable table = new DataTable();

      try
      {
        SqlCommand command = new SqlCommand(sqlCommand, dbConn);
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        adapter.Fill(table);
      }
      catch (SqlException e)
      {
        lastError = e.ErrorCode + ": " + e.Message;
        if (ShowMsgBoxError)
          MessageBox.Show("Errore nella gestione del DB.\n\nError:\n    " + LastError, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return table;
    }


    public static string SQL_ConvertDateTimeToData(DateTimePicker dtpDataObj)
    {
      if (dtpDataObj.Checked)
        return SQL_ConvertDateTimeToData(dtpDataObj.Value);
      else
        return "null";
    }

    public static string SQL_ConvertDateTimeToData(DateTime dtData)
    {
      return SQL_ConvertStrToData(dtData.ToString("dd/MM/yyyy"));
    }

    public static string SQL_ConvertStrToData(string strData)
    {
      string RetValue = "convert(datetime, '" + strData + "', 103)";
      return RetValue;
    }

    public static int GetNextNumFattura()
    {
      return GetNextNumFattura(DateTime.Today);
    }

    public static bool GetIntervalDateNumFattura(int IdFattura, ref DateTime MinDate, ref DateTime MaxDate)
    {
      bool bRetValue = false;
      string strSql = "";
      if (IdFattura > 0)
      {
        strSql = "Select max(docu_data) from documenti Where docu_cancellato=0 and id<" + IdFattura.ToString();
        MinDate = (DateTime)clsDataBase.ExecuteScalar(strSql);

        strSql = "Select min(docu_data) from documenti Where docu_cancellato=0 and id>" + IdFattura.ToString();
        MaxDate = (DateTime)clsDataBase.ExecuteScalar(strSql);
      }
      else
      {
        strSql = "Select last_date_fattura from Parametri";
        MinDate = (DateTime)clsDataBase.ExecuteScalar(strSql);
        MaxDate = DateTime.MaxValue;
      }
      return bRetValue;
    }

    public static bool GetIntervalDateNumFattura(int IdFattura, DateTimePicker objDate)
    {
      bool bRetValue = false;
      object objValue = null;
      string strSql = "";
      if (IdFattura > 0)
      {
        strSql = "Select max(docu_data) from documenti Where docu_cancellato=0 and id<" + IdFattura.ToString();
        objValue = clsDataBase.ExecuteScalar(strSql);
        if (objValue != null && objValue.ToString() != "")
          objDate.MinDate = (DateTime)objValue;
        else
          objDate.MinDate = DateTime.MinValue;


        strSql = "Select min(docu_data) from documenti Where docu_cancellato=0 and id>" + IdFattura.ToString();
        objValue = null;
        objValue = clsDataBase.ExecuteScalar(strSql);
        if (objValue != null && objValue.ToString() != "")
          objDate.MaxDate = (DateTime)objValue;
        else
          objDate.MaxDate = DateTime.MaxValue;
      }
      else
      {
        strSql = "Select last_date_fattura from Parametri";
        object objLastDate = clsDataBase.ExecuteScalar(strSql);
        if (objLastDate.ToString() != "")
          objDate.MinDate = (DateTime)objLastDate;

        objDate.MaxDate = DateTime.MaxValue;
      }
      return bRetValue;
    }

    public static int GetNextNumFattura(DateTime DataFat)
    {
      int RetValue = -1;
      //return (int)ExecuteScalar("select isnull(Max(docu_numero),0) +1 from Documenti");
      string strSql = "Select last_num_fattura, last_date_fattura from Parametri";

      if (clsDataBase.ExecuteQuery(strSql))
      {
        if (clsDataBase.vetDbReader[0].Read())
        {
          if (clsDataBase.GetDateValue("last_date_fattura") <= DataFat)
          {
            if (clsDataBase.GetDateValue("last_date_fattura").Year == DataFat.Year)
              RetValue = clsDataBase.GetIntValue("last_num_fattura") + 1;
            else
              RetValue = 1;
          }
        }
      }
      clsDataBase.CloseDataReader();
      return RetValue;
    }

    public static string GetNextNumFatturaXml(int IdDocumento)
    {
      string RetValue = "";

      string strSql = "Select IsNull(Max(Id), 0) As Id From XML_Documenti Where IdDocumento = " + IdDocumento.ToString() + "\n"
                    + "Union All \n"
                    + "Select IsNull(Max(Id) + 1, 1) As Id From XML_Documenti";

      if (clsDataBase.ExecuteQuery(strSql))
      {
        while (clsDataBase.vetDbReader[0].Read())
        {
          if (GetIntValue("Id") > 0)
          {
            RetValue = ("0000" + (GetIntValue("Id")).ToString("X")).PadLeft(5);
            break;
          }
        }
      }

      clsDataBase.CloseDataReader();

      return RetValue;
    }

    public static string GetIvaAzienda()
    {
      string RetValue = "";
      string strSql = "Select (Az_paese + Az_iva) As PIVA  From Azienda";

      if (clsDataBase.ExecuteQuery(strSql))
      {
        if (clsDataBase.vetDbReader[0].Read())
        {
          RetValue = GetStringValue("PIVA");
        }
      }

      clsDataBase.CloseDataReader();

      return RetValue;
    }

    /// <summary>
    /// Restituisce la data fattura in formato <c>string</c> YYYY-MM-DD usata per il nome file Xml
    /// </summary>
    /// <param name="IdFattura"></param>
    public static string GetDataFattura(int IdFattura)
    {
      string RetValue = "";
      string strSql = "Select docu_data As Data From Documenti Where ID = " + IdFattura.ToString();

      if (clsDataBase.ExecuteQuery(strSql))
      {
        if (clsDataBase.vetDbReader[0].Read())
        {
          RetValue = GetDateValue("Data").ToString("yyyyMMdd");
        }
      }

      clsDataBase.CloseDataReader();

      return RetValue;
    }

    public static int SetNumFattura(int IdFattura, DateTime DataFattura)
    {
      int RetValue = GetNextNumFattura(DataFattura);

      if (RetValue > 0)
      {
        string strSql = "Update Documenti set docu_numero =" + RetValue.ToString() + " where ID=" + IdFattura;
        if (clsDataBase.ExecuteNonQuery(strSql))
        {
          strSql = "Update Parametri set last_num_fattura =" + RetValue.ToString() + ", last_date_fattura = " + SQL_ConvertDateTimeToData(DataFattura);
          if (!clsDataBase.ExecuteNonQuery(strSql))
            RetValue = -1;
        }
        else
          RetValue = -1;
      }
      return RetValue;
    }

    public static bool SetLastDateFattura(DateTime DataFattura)
    {
      bool RetValue = true;

      string strSql = "Update Parametri set last_date_fattura = " + SQL_ConvertDateTimeToData(DataFattura);
      if (!clsDataBase.ExecuteNonQuery(strSql))
        RetValue = false;

      return RetValue;
    }
  }
}
