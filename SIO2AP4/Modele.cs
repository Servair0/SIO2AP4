using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace SIO2AP4
{
    //Ajouter ou surprimer un soin
    //Ajouter un commentaire 


    public static class Modele
    {
        private static string reponseServeur;
        private static int action;
        private static int L;
        private static connectAP4 maConnexion;
        private static personne_login Personne;
        
        // Utilisateur et ces types

        private static personne Utilisateur;
        private static infirmiere Infirmiere;
        private static patient Patient;
        
        //

        private static personne_login utilisateurConnecte; // Administratif
        private static personne personneConnecte; // Sert au l'aplication 
        private static visite visiteChoisi;
        private static visite Visite;

        private static soins Soins;
        private static soins_visite choisiSoins;
        private static soins_visite VisiteS;

        public static int Lock { get => L; set => L = value; }
        public static int Action { get => action; set => action = value; }
        public static personne_login UtilisateurConnecte { get => utilisateurConnecte; set => utilisateurConnecte = value; }
        public static personne PersonneConnecte { get => personneConnecte; set => personneConnecte = value; }
        public static visite Visitechoisi { get => visiteChoisi; set => visiteChoisi = value; }
        
        public static soins_visite ChoisiSoins { get => choisiSoins; set => choisiSoins = value; }


        public static void init()
        {
            /* Instantiation d’un objet de la classe typée chaine de connexion SqlConnection */
            maConnexion = new connectAP4();
        }

        //Retourne les utilisateurs sous forme de liste
        public static List<personne> listeUtilisateur()
        {
            return maConnexion.personne.ToList();
   
        }
        public static List<visite> listeVisite()
        {
            return maConnexion.visite.ToList();
        }

        public static object listeVUP()
        {
            return maConnexion.visite.Select(x => new { x.id, x.soins_visite, x.date_prevue, x.date_reelle, x.duree, x.patient1.personne.nom, x.patient1.personne.prenom, x.compte_rendu_infirmiere, x.compte_rendu_patient }).ToList().OrderBy(x => x.date_prevue);
        }
         public static object listesoinsV()
        {
            
            return Modele.visiteChoisi.soins_visite.Select(x => new {x.id_soins,x.soins.libel, x.soins.description, x.realise, x.prevu }).ToList();
        }

        //
        public static visite GetVisitebyid(int id)
        {
            return maConnexion.visite.Where(x => x.id == id).ToList()[0];
        }
        public static soins_visite Getsoins_visitebyid(int id)
        {
            return maConnexion.soins_visite.Where(x => x.id_soins == id).ToList()[0];
        }
        public static soins Getsoinsbyid(int id)
        {
            return maConnexion.soins.Where(x => x.id == id).ToList()[0];
        }



        //Script de Connexion

        public static bool VerifLocal(string id, string mdp) 
        {
            bool vretour = false;
            vretour = VerifU(id);
            
            if (vretour == true)
            {
                vretour = mdpVerif(mdp);
            }

            return vretour;
        }
        //Vérifie si l'utilisateur et connection a celui-ci existe a la base de données
        public static bool VerifU(string id)
        {
            bool vretour = false;

            if (maConnexion.personne_login.Where(x => x.login == id).ToList().Count == 1)
            {
                vretour = true;
                utilisateurConnecte = maConnexion.personne_login.Where(x => x.login == id).ToList()[0];
            }

            return vretour;
        }
        //Verification du mot de passe 
        public static bool mdpVerif(string mdp)
        {
            bool vretour = false;

            if (utilisateurConnecte.mp.Equals(getMdpMD5(mdp)))
            {
                
                vretour = true;
                PersonneConnecte = maConnexion.personne.Where(x => x.id == utilisateurConnecte.id).ToList()[0];
            }
            else
            {
                utilisateurConnecte.nb_tentative_erreur = utilisateurConnecte.nb_tentative_erreur + 1;
                maConnexion.SaveChanges();
            }

            return vretour;
        }

        //--------------

        //Cryptage du mot de passe
        private static string getMdpMD5(string pwdSaisi)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pwdSaisi);
            byte[] hash = (MD5.Create()).ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        //--------------
        public static bool VerifWeb(string nom, string mdp)
        {

            bool vretour = true;

            try {
                string url = "https://btssio-carcouet.fr/ppe4/public/connect2/" + nom + "/" + mdp + "/infirmiere";
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                reponseServeur = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                vretour = verifReponseServeur(nom, mdp);
            }

            catch { vretour = false; }
                

            return vretour;

        }
        public static bool verifReponseServeur(string L, string M){
            //Récupération de la donnée JSON 
            //Utilisation de la variable String pour la transformer en JSON
            bool vretour = false;
            DateTime date_naiss = new DateTime();
            DateTime date_deces = new DateTime();

            JsonDocument doc = JsonDocument.Parse(reponseServeur);
            JsonElement root = doc.RootElement;

            try
            {
                if (root.GetProperty("status").ToString() == "false")
                {
                    vretour = false;
                }
            }
            catch 
            {

                int id = Convert.ToInt32(root.GetProperty("id").ToString());
                string prenom = root.GetProperty("prenom").ToString();
                string nom = root.GetProperty("nom").ToString();
                string sexe = root.GetProperty("sexe").ToString();
                if( root.GetProperty("date_naiss").ToString() == "")
                {

                }
                else
                {
                     date_naiss = DateTime.Parse(root.GetProperty("date_naiss").ToString(),
                    System.Globalization.CultureInfo.InvariantCulture);
                }
                if (root.GetProperty("date_deces").ToString() == "")
                {

                }
                else
                {
                    date_deces = DateTime.Parse(root.GetProperty("date_deces").ToString(),
                    System.Globalization.CultureInfo.InvariantCulture);
                }
                string ad1 = root.GetProperty("ad1").ToString();
                string ad2 = root.GetProperty("ad2").ToString();
                int cp = Convert.ToInt32(root.GetProperty("cp").ToString());
                string ville = root.GetProperty("ville").ToString();
                string tel_fixe = root.GetProperty("tel_fixe").ToString();
                string tel_port = root.GetProperty("tel_port").ToString();
                string mail = root.GetProperty("mail").ToString();

                //Change le mot de passe de l'utilisateur si l'utilisateur a un nouveau mot de passe 
                
                if ( maConnexion.personne.Where(x => x.id == id).ToList().Count !=0) 
                {
                    MdpChange(M);
                }
                
                else
                {
                    //Créateur des Users 
                    CreateUser(id, prenom, nom, sexe, date_naiss, date_deces, ad1, ad2, cp, ville, tel_fixe, tel_port, mail);
                    CreateUserlogin(id, L, M);
                    CreateInfir(id);
                    maConnexion.SaveChanges();
                  
                }
                //Connection des Users

                utilisateurConnecte = maConnexion.personne_login.Where(x => x.login == L).ToList()[0];
                personneConnecte = maConnexion.personne.Where(x => x.id == utilisateurConnecte.id).ToList()[0];
                vretour = true;
            }
         
            return vretour;

        }
        

        private static void CreateUser(int id, string prenom, string nom, string sexe,
            DateTime dateN, DateTime dateD, string ad1, string ad2, int cp,string ville, string telf, string telp, string mail)
        {
            Utilisateur = new personne();
            Utilisateur.id = id;
            Utilisateur.nom = nom;
            Utilisateur.prenom = prenom;
            Utilisateur.sexe = sexe;
            Utilisateur.date_naiss = dateN;
            Utilisateur.date_deces = dateD;
            Utilisateur.ad1 = ad1;
            Utilisateur.ad2 = ad2;
            Utilisateur.cp = cp;
            Utilisateur.ville = ville;
            Utilisateur.tel_fixe = telf;
            Utilisateur.tel_port = telp;
            Utilisateur.mail = mail;
   
            maConnexion.personne.Add(Utilisateur);
            maConnexion.SaveChanges();

        }
        private static void CreateUserlogin(int id, string login, string mdp) 
        {
            
            Personne = new personne_login();
            Personne.id = id;
            Personne.login = login;
            Personne.mp = getMdpMD5(mdp);
            Personne.derniere_connexion = DateTime.Today;
            Personne.nb_tentative_erreur = 0;
            
            maConnexion.personne_login.Add(Personne);
            maConnexion.SaveChanges();  

        }
        private static void CreateInfir(int id)
        {

            Infirmiere = new infirmiere();
            Infirmiere.id = id;
            maConnexion.infirmiere.Add(Infirmiere);
            maConnexion.SaveChanges();

        }
        public static void MdpChange(string MDP)
        {
            UtilisateurConnecte.mp = getMdpMD5(MDP);
            maConnexion.SaveChanges();
        }

        //--------------------------------------------------------------------------//
        //Récupération des visites et les entrer de celle-ci
        public static bool VerifVisite()
        {

            bool vretour = true;

            try
            {
                string url = "https://www.btssio-carcouet.fr/ppe4/public/mesvisites/3";
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                reponseServeur = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }

            catch { vretour = false; }


            return vretour;

        }
        public static bool chargerlesVisites()
        {
            maConnexion.soins_visite.RemoveRange(maConnexion.soins_visite.ToList());
            maConnexion.visite.RemoveRange(maConnexion.visite.ToList());
            maConnexion.type_soins.RemoveRange(maConnexion.type_soins.ToList());
            maConnexion.categ_soins.RemoveRange(maConnexion.categ_soins.ToList());
            maConnexion.patient.RemoveRange(maConnexion.patient.ToList());
            maConnexion.soins.RemoveRange(maConnexion.soins.ToList());
            maConnexion.SaveChanges();

            //JsonElement 

            JsonDocument doc = JsonDocument.Parse(reponseServeur);
            JsonElement root = doc.RootElement;

            //
            VerifSoin();
            ChargeSoin();
            

            bool vretour = true;
            int NBV = 0;
            var count = root.EnumerateArray();
            var visites = root.EnumerateArray();
            while (count.MoveNext())
            {
                NBV++;
            }
            if (NBV > 0)
            {
                while(visites.MoveNext())
                {
                    var visite = visites.Current;
                    DateTime date_prevue = new DateTime();
                    DateTime date_reelle = new DateTime();

                    /**
                    {
                    "id":"1",
                    "patient":"5",
                    "infirmiere":"3",
                    "date_prevue":"2022-04-15 14:00:00",
                    "date_reelle":"0000-00-00 00:00:00",
                    "duree":"60",
                    "compte_rendu_infirmiere":"
                    ","compte_rendu_patient":""
                    }
                    **/
                    
                    int id = Convert.ToInt32(visite.GetProperty("id").ToString());
                   
                    int patient = Convert.ToInt32(visite.GetProperty("patient").ToString());
                    // Créer le patient
                    if (maConnexion.personne.Where(x => x.id == patient).ToList().Count == 0)
                    {
                        if (VerifPersonne(patient))
                        {
                            ChargePerso(patient);
                        }
                        else
                        {
                            vretour = false;
                        }
                    }
                    if (maConnexion.patient.Where(x => x.id == patient).ToList().Count == 0)
                    {
                        CreatePatient(patient);
                    }
                    
                    
                    // Créer l'infirmiere

                    int infirmiere = Convert.ToInt32(visite.GetProperty("infirmiere").ToString());

                    if (maConnexion.personne.Where(x => x.id == infirmiere).ToList().Count == 0)
                    {
                        if (VerifPersonne(infirmiere))
                        {
                            ChargePerso(infirmiere);
                        }
                        else
                        {
                            vretour = false;
                        }
                    }
                    if (maConnexion.infirmiere.Where(x => x.id == infirmiere).ToList().Count == 0)
                    {
                        CreatePatient(infirmiere);
                    }

                    //date

                    if (visite.GetProperty("date_prevue").ToString() == "")
                    {

                    }
                    else
                    {
                        date_prevue = DateTime.Parse(visite.GetProperty("date_prevue").ToString(),
                       System.Globalization.CultureInfo.InvariantCulture);
                    }
                    if (visite.GetProperty("date_reelle").ToString() == "" || visite.GetProperty("date_reelle").ToString() == "0000-00-00 00:00:00")
                    {

                    }
                    else
                    {
                        date_reelle = DateTime.Parse(visite.GetProperty("date_reelle").ToString(),
                       System.Globalization.CultureInfo.InvariantCulture);
                    }
                    
                    //

                    int duree = Convert.ToInt32(visite.GetProperty("duree").ToString());
                    string compte_rendu_infirmiere = visite.GetProperty("compte_rendu_infirmiere").ToString();
                    string compte_rendu_patient = visite.GetProperty("compte_rendu_patient").ToString();

                    CreateVisite(id, patient, infirmiere, date_prevue, date_reelle, duree, compte_rendu_infirmiere, compte_rendu_patient);

                }
            }
            else
            {
                vretour = false;
            }
            VerifVisiteS();
            ChargeVisiteS();
            return vretour;
        }
        public static bool VerifPersonne(int id)
        {
            //Conversion JSON
            bool vretour = true;
            try 
            {
                string url = "https://btssio-carcouet.fr/ppe4/public/personne/" + id;
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                reponseServeur = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
            } 
            
            catch 
            {
                vretour = false;
            }
            return vretour;
        }
        public static bool ChargePerso(int id)
        {
            bool vretour = true;

            //JsonElement 

            JsonDocument doc = JsonDocument.Parse(reponseServeur);
            JsonElement root = doc.RootElement;

            //

            try
            {
                DateTime date_naiss = new DateTime();
                DateTime date_deces = new DateTime();
                string prenom = root[0].GetProperty("prenom").ToString();
                string nom = root[0].GetProperty("nom").ToString();
                string sexe = root[0].GetProperty("sexe").ToString();
                if (root[0].GetProperty("date_naiss").ToString() == "")
                {

                }
                else
                {
                    date_naiss = DateTime.Parse(root[0].GetProperty("date_naiss").ToString(),
                   System.Globalization.CultureInfo.InvariantCulture);
                }
                if (root[0].GetProperty("date_deces").ToString() == "")
                {

                }
                else
                {
                    date_deces = DateTime.Parse(root[0].GetProperty("date_deces").ToString(),
                    System.Globalization.CultureInfo.InvariantCulture);
                }
                string ad1 = root[0].GetProperty("ad1").ToString();
                string ad2 = root[0].GetProperty("ad2").ToString();
                int cp = Convert.ToInt32(root[0].GetProperty("cp").ToString());
                string ville = root[0].GetProperty("ville").ToString();
                string tel_fixe = root[0].GetProperty("tel_fixe").ToString();
                string tel_port = root[0].GetProperty("tel_port").ToString();
                string mail = root[0].GetProperty("mail").ToString();
                CreateUser(id, prenom, nom, sexe, date_naiss, date_deces, ad1, ad2, cp, ville, tel_fixe, tel_port, mail);
            }
            catch
            {
                vretour = false;
            }

            return vretour;
           
       
        }
        public static bool CreateVisite(int id, int patient, int infirmiere, 
            DateTime date_prevue, DateTime date_reelle, int duree, string compteI, string compteP)

        {
            
            bool vretour = true;
            Visite = new visite();
            Visite.id = id;
            Visite.patient = patient;
            Visite.infirmiere = infirmiere;
            Visite.date_prevue = date_prevue;
            Visite.date_reelle = date_reelle;
            Visite.duree = duree;
            Visite.compte_rendu_infirmiere = compteI;
            Visite.compte_rendu_patient = compteP;
            maConnexion.visite.Add(Visite);
            maConnexion.SaveChanges();
            
            return vretour;
        }
        public static void CreatePatient(int id)
        {
            Patient = new patient();
            Patient.id = id;
            Patient.informations_medicales = " ";
            maConnexion.patient.Add(Patient);
            maConnexion.SaveChanges();
        }
        // Partie SOIN !
        public static bool VerifSoin()
        {
            //Conversion JSON
            bool vretour = true;
            try
            {
                string url = "https://btssio-carcouet.fr/ppe4/public/soins/";
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                reponseServeur = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
            }

            catch
            {
                vretour = false;
            }
            return vretour;
        }
        public static bool ChargeSoin()
        {
            bool vretour = true;
            //JsonElement 

            JsonDocument doc = JsonDocument.Parse(reponseServeur);
            JsonElement root = doc.RootElement;

            //
            
            var count = root.EnumerateArray();
            var visites = root.EnumerateArray();
            int NBV = 0;

            //
            while (count.MoveNext())
            {
                NBV++;
            }
            if (NBV > 0)
            {
                while (visites.MoveNext())
                {
                    var visite = visites.Current;
                    DateTime date = new DateTime();
                    int id_cate = Convert.ToInt32(visite.GetProperty("id_categ_soins").ToString());
                    int id_type = Convert.ToInt32(visite.GetProperty("id_type_soins").ToString());
                    int id = Convert.ToInt32(visite.GetProperty("id").ToString()); 
                    string libel = visite.GetProperty("libel").ToString();
                    string description = visite.GetProperty("description").ToString();
                    String cf = visite.GetProperty("coefficient").ToString();
                    var x = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    x.NumberFormat.NumberDecimalSeparator = ".";
                    float coefficient = float.Parse(cf, x);

                    if (visite.GetProperty("date").ToString() == "")
                    {

                    }
                    else
                    {
                        date = DateTime.Parse(visite.GetProperty("date").ToString(),
                       System.Globalization.CultureInfo.InvariantCulture);
                    }
                    CreateSoin(id_cate, id_type, id, libel, description, coefficient, date);
                }
            }
            else
            {
                vretour = false;
            }
            return vretour;

        }
        // DBCC CHECKIDENT (categ_soins, RESEED, 0) Pour redemarer un auto a zéro
        public static bool CreateSoin(int idc, int idt, int id, string libel, string des, float coef, DateTime date)
        {
            bool vretour = true;

            Soins = new soins();
            
            Soins.id_categ_soins = idc;
            
            Soins.id_type_soins = idt;
            
            if(maConnexion.categ_soins.Where(x=>x.id==idc).ToList().Count==0)
            {
                categ_soins c = new categ_soins();
                c.id = idc;
                c.libel = "";
                maConnexion.categ_soins.Add(c);
 

            }
            
            if (maConnexion.type_soins.Where(x => x.id_type_soins == idt && x.id_categ_soins==idc ).ToList().Count == 0)
            {
                type_soins c = new type_soins();
                c.id_type_soins = idt;
                c.id_categ_soins = idc;
                c.libel = "";
                maConnexion.type_soins.Add(c);
                

            }

            Soins.id = id;
            Soins.libel = libel;
            Soins.description = des;
            Soins.coefficient = coef;
            Soins.date = date;
            maConnexion.soins.Add(Soins);
            maConnexion.SaveChanges();

            return vretour;
        }

        //

        public static bool VerifVisiteS()
        {
            //Conversion JSON
            bool vretour = true;
            try
            {
                string url = "https://btssio-carcouet.fr/ppe4/public/visitesoins/3";
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                reponseServeur = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
            }

            catch
            {
                vretour = false;
            }
            return vretour;
        }
        public static bool ChargeVisiteS()
        {
            bool vretour = true;
            //JsonElement 

            JsonDocument doc = JsonDocument.Parse(reponseServeur);
            JsonElement root = doc.RootElement;

            //

            var count = root.EnumerateArray();
            var visites = root.EnumerateArray();
            int NBV = 0;

            //
            while (count.MoveNext())
            {
                NBV++;
            }
            if (NBV > 0)
            {
                while (visites.MoveNext())
                {
                    /*
                     {
                    "visite":"3",
                    "id_categ_soins":"1",
                    "id_type_soins":"2",
                    "id_soins":"5",
                    "prevu":"1",
                    "realise":"0"
                    }
                    */

                    var v = visites.Current;
                    int visite = Convert.ToInt32(v.GetProperty("visite").ToString());
                    int id_categ_soins = Convert.ToInt32(v.GetProperty("id_categ_soins").ToString());
                    int id_type_soins = Convert.ToInt32(v.GetProperty("id_type_soins").ToString());
                    int id_soins = Convert.ToInt32(v.GetProperty("id_soins").ToString());
                    short prevu = Convert.ToInt16(v.GetProperty("prevu").ToString());
                    short realise = Convert.ToInt16(v.GetProperty("realise").ToString());

                    CreateVisiteS(visite, id_categ_soins, id_type_soins, id_soins, prevu, realise);

                    
                }
            }
            else
            {
                vretour = false;
            }
            return vretour;

        }

        public static bool CreateVisiteS(int v, int idc, int idt, int ids, short p, short r)
        {
            bool vretour = true;

            VisiteS = new soins_visite();
            VisiteS.visite = v;
            VisiteS.id_categ_soins = idc;
            VisiteS.id_type_soins = idt;
            VisiteS.id_soins = ids;
            VisiteS.prevu = p;
            VisiteS.realise = r;

            maConnexion.soins_visite.Add(VisiteS);
            maConnexion.SaveChanges();

            return vretour;
        }

        public static bool ModifVisite(DateTime Datereal, string compterendu)
        {
            bool vretour = true;
            try 
            {
                Visitechoisi.date_reelle=Datereal;
                Visitechoisi.compte_rendu_infirmiere=compterendu;
                maConnexion.SaveChanges();
            } 
            catch 
            { 
                vretour=false;
            }

            return vretour;
        }
        public static void Supp()
        {

            maConnexion.type_soins.Remove(choisiSoins.soins.type_soins);
            maConnexion.soins.Remove(Getsoinsbyid(choisiSoins.id_soins));
            maConnexion.soins_visite.Remove(choisiSoins);
            maConnexion.SaveChanges();

        }
        public static void ModifSoins(string libel, string des, float coef, short realise)
        {
            soins s = Getsoinsbyid(ChoisiSoins.id_soins);
            ChoisiSoins.realise = realise;
            
            s.libel = libel;
            s.description = des;
            s.coefficient = coef;
            s.date = DateTime.Now;

            maConnexion.SaveChanges();

        }
        public static void AjoutSoins(string libel, string des, float coef, short realise)
        {
            int ids = maConnexion.soins.ToList().Count();
            
            int idt = maConnexion.type_soins.ToList().Count();
            int idc = 1;
            type_soins ts = new type_soins();
            soins s = new soins();
            soins_visite sv = new soins_visite();
            ts.id_categ_soins = 1;
            ts.id_type_soins = idt;
            ts.libel = "";

            s.id_categ_soins = idc;
            s.id_type_soins = idt;
            s.id = ids;
            s.libel=libel;
            s.description=des;
            s.coefficient=coef;
            s.date=DateTime.Now;

            sv.visite = visiteChoisi.id;
            sv.id_categ_soins = idc;
            sv.id_type_soins = idt;
            sv.id_soins = ids;
            sv.prevu = 0;
            sv.realise=realise;
            maConnexion.type_soins.Add(ts);
            maConnexion.soins.Add(s);
            maConnexion.soins_visite.Add(sv);
            maConnexion.SaveChanges();
        }

    }
}
