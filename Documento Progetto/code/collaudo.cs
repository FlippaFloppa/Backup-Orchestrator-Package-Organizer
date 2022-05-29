using NUnit.Framework

[TestFixture]
public class FilesTest
{
    private string strFileName;
    private string strFilePath;
    private string strFolder;

    [SetUp]
    public void SetUp() {  }

    [Test]
    public void test_caricamento_file()
    {
        /*--------------------------------
        Il Test simula il caricamento di un file attraverso l'interfaccia del sito.
        Per semplicità viene simulato il caricamento da parte dell'utente "Goblino"
        ----------------------------------*/

        strFolder = Server.MapPath("./Users/Goblino/Storage/");
        strFileName = oFile.PostedFile.FileName;
        strFileName = Path.GetFileName(strFileName);

        // Procedura di Upload
        if (oFile.Value != "")
        {
            if (!Directory.Exists(strFolder))
            {
                Directory.CreateDirectory(strFolder);
            }
            strFilePath = strFolder + strFileName;
            if (File.Exists(strFilePath))
            {
                lblUploadResult.Text = strFileName + " file già presente!";
            }
            else
            {
                oFile.PostedFile.SaveAs(strFilePath);
                lblUploadResult.Text = strFileName + " caricato correttamente!";
            }
        }
        else
        {
            lblUploadResult.Text = "Seleziona il file da caricare.";
        }
        //Test
        Assert.isFalse(File.Exists(strFilePath),true);
    }
}

public class AdminTest
{
    DatabaseMock database;
    List<RichiestaUtente> richiesteUtente;

    [SetUp]
    public void SetUp()
    {
        database.openConnection();
        richiesteUtente = database.getListaRichiesteUtente();
    }

    [Test]
    public void test_approvazione_richiesta_utente()
    {
        /*--------------------------------
        Il Test simula l'approvazione della richiesta di registrazione di un utente.
        ----------------------------------*/

        // Approvazione utente "Michele"
        richiesteUtente.gestisciRichiesta("Michele",true);

        // Check Utente aggiunto alla lista
        Assert.isTrue(database.getListaUtenti().get("Michele"),null);          
        // Check richiesta Utente rimossa dalla lista 
        Assert.isFalse(database.getListaRichiesteUtente().get("Michele"),null); 
    }

    [Test]
    public void test_eliminazione_utente()
    {
        /*--------------------------------
        Il Test simula l'eliminazione di un utente da parte dell'amministratore.
        ----------------------------------*/
        database.eliminaUtente("Michele");
        //Test
        Assert.isFalse(database.getListaUtenti().get("Michele"),null);
    }
}