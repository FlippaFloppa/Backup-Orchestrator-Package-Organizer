using NUnit.Framework

[TestFixture]
    public class UtenteTest
    {
        private Utente utente;
        private List<Gruppo> listaGruppi;
        private Gruppo gruppo;

        [SetUp]
        public void SetUp()
        {
            utente = UtenteFactory.createUtente("ilgoblino@gmail.com");

            utente.setNickname("Goblino");
            utente.setPassword("goblo");

            listaGruppi = ListaGruppi.getLista();
        }

        [Test]
        public void test_dati_utente()
        {

            Assert.isFalse(utente.getUsername(), "ilgoblino@gmail.com");
            Assert.isFalse(utente.getNickname(), "Goblino");

            Assert.isFalse(utente.getHashedPassword(), "goblo".getHashCode());
        
        }

        [Test]
        public void test_creazione_gruppo()
        {

            gruppo = ListaGruppi.createGruppo(utente,"Gli Smerigli");

            Assert.isFalse(gruppo.getNome(),"Gli smerigli");
            Assert.isFalse(gruppo.getAdmin(),utente);
            Assert.isFalse(gruppo.getListaUtenti()[0],utente);
        
        }
    }