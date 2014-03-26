using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    bazaEntities db = new bazaEntities();
    #region REST
    #region REST_Korisnik
    public korisnik GetKorisnik(string idkorisnika)
    {
        try
        {
           korisnik k = new korisnik();
           bazaEntities db = new bazaEntities();
           int idkorisnik = Convert.ToInt32(idkorisnika);
         var  rezultat = db.korisnik.SingleOrDefault(x => x.idkorisnik == idkorisnik);
            
         k.idkorisnik = rezultat.idkorisnik;
         k.ime = rezultat.ime;
         k.prezime = rezultat.prezime;
         k.username = rezultat.username;
         k.password = rezultat.password;       
        
         k.profil = rezultat.profil;
         k.telefon = rezultat.telefon;
         k.email = rezultat.email;
         k.boraviste = rezultat.boraviste;

           
            return k;
        }
        catch (Exception e) {
                              Console.Write(e.StackTrace.ToString());
                               return null; }
    }


    public void PostKorisnik(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();
      
    
        
       var serializer = new JavaScriptSerializer();
   korisnik novi =    serializer.Deserialize<korisnik>(res);
      bazaEntities db = new bazaEntities();
      
          db.korisnik.Add(novi);
          db.SaveChanges();
 
    }


    public void PUTKorisnik(string streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        korisnik novi = serializer.Deserialize<korisnik>(res);
        bazaEntities db = new bazaEntities();
        db.korisnik.Attach(novi);
        db.Entry(novi).State = EntityState.Modified;
        db.SaveChanges();
    }


    public void DeleteKorisnik(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        korisnik novi = serializer.Deserialize<korisnik>(res);
        bazaEntities db = new bazaEntities();
        db.korisnik.Attach(novi);
        db.Entry(novi).State = EntityState.Deleted;
        db.SaveChanges();
    }
    #endregion



    #region REST_Tutor
    public tutor GetTutor(string idtutora)
    {
        try
        {
            tutor k = new tutor();
            bazaEntities db = new bazaEntities();
            int idtutor = Convert.ToInt32(idtutora);
            var rezultat = db.tutor.SingleOrDefault(x => x.idtutor == idtutor);
            
            k.idtutor = rezultat.idtutor;
            k.ime = rezultat.ime;
            k.prezime = rezultat.prezime;
            k.username = rezultat.username;
            k.password = rezultat.password;
            k.kvalifikacija = rezultat.kvalifikacija;
            k.profil = rezultat.profil;
            k.telefon = rezultat.telefon;
            k.email = rezultat.email;
            k.boraviste = rezultat.boraviste;
            k.opis = rezultat.opis;

            return k;
        }
        catch (Exception e)
        {
            Console.Write(e.StackTrace.ToString());
            return null;
        }
    }


    public void PostTutor(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        tutor novi = serializer.Deserialize<tutor>(res);
        bazaEntities db = new bazaEntities();

        db.tutor.Add(novi);
        db.SaveChanges();
    }

    public void PUTTutor(string streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        tutor novi = serializer.Deserialize<tutor>(res);
        bazaEntities db = new bazaEntities();
        db.tutor.Attach(novi);
        db.Entry(novi).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void DeleteTutor(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        tutor novi = serializer.Deserialize<tutor>(res);
        bazaEntities db = new bazaEntities();
        db.tutor.Attach(novi);
        db.Entry(novi).State = EntityState.Deleted;
        db.SaveChanges();
    }
#endregion

    #region REST_Kategorija
    public kategorija GETKategorija(string idkategorija)
    {
        try
        {
            kategorija k = new kategorija();
            bazaEntities db = new bazaEntities();
            int idkategorije = Convert.ToInt32(idkategorija);
            var rezultat = db.kategorija.SingleOrDefault(x => x.idkategorija == idkategorije);
           
            k.idkategorija = rezultat.idkategorija;
            k.nazivKategorije = rezultat.nazivKategorije;
            k.opis = rezultat.opis;
           
            return k;
        }
        catch (Exception e)
        {
            Console.Write(e.StackTrace.ToString());
            return null;
        }
    }

    public void PostKategorija(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        kategorija novi = serializer.Deserialize<kategorija>(res);
        bazaEntities db = new bazaEntities();

        db.kategorija.Add(novi);
        db.SaveChanges();
    }

    public void PUTKategorija(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        kategorija novi = serializer.Deserialize<kategorija>(res);
        bazaEntities db = new bazaEntities();
        db.kategorija.Attach(novi);
        db.Entry(novi).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void DELETEKategorija(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        kategorija novi = serializer.Deserialize<kategorija>(res);
        bazaEntities db = new bazaEntities();
        db.kategorija.Attach(novi);
        db.Entry(novi).State = EntityState.Deleted;
        db.SaveChanges();
    }
    #endregion


    #region REST_Komentar
    public komentar GETKomentar(string idkomentara)
    {
        try
        {
            komentar k = new komentar();
            bazaEntities db = new bazaEntities();
            int idkomentar = Convert.ToInt32(idkomentara);
            var rezultat = db.komentar.SingleOrDefault(x => x.idkomentar == idkomentar);

            k.idkomentar = rezultat.idkomentar;
            k.korisnik_idkorisnika = rezultat.korisnik_idkorisnika;
            k.naslov = rezultat.naslov;
            k.tekst = rezultat.tekst;
            k.datumKreiranja = rezultat.datumKreiranja;
            k.datumAzuriranja = rezultat.datumAzuriranja;
            k.oglas_idoglasa = rezultat.oglas_idoglasa;

            return k;
        }
        catch (Exception e)
        {
            Console.Write(e.StackTrace.ToString());
            return null;
        }
    }

    public void PostKomentar(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        komentar novi = serializer.Deserialize<komentar>(res);
        bazaEntities db = new bazaEntities();

        db.komentar.Add(novi);
        db.SaveChanges();
    }

    public void PUTKomentar(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        komentar novi = serializer.Deserialize<komentar>(res);
        bazaEntities db = new bazaEntities();
        db.komentar.Attach(novi);
        db.Entry(novi).State = EntityState.Modified;
        db.SaveChanges();
    }
    public void DELETEKomentar(Stream streamdata) {

        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        komentar novi = serializer.Deserialize<komentar>(res);
        bazaEntities db = new bazaEntities();
        db.komentar.Attach(novi);
        db.Entry(novi).State = EntityState.Deleted;
        db.SaveChanges();
    }
    #endregion


    #region REST_Oglas
    public oglas GETOglas(string idoglasa)
    {
        try
        {
            oglas k = new oglas();
            bazaEntities db = new bazaEntities();
            int idoglas = Convert.ToInt32(idoglasa);
            var rezultat = db.oglas.SingleOrDefault(x => x.idoglas == idoglas);

            k.idoglas = rezultat.idoglas;
            k.naslov = rezultat.naslov;
            k.tekst = rezultat.tekst;
            k.datumKreiranja = rezultat.datumKreiranja;
            k.datumAzuriranja = rezultat.datumAzuriranja;
            k.tutor_idtutor = rezultat.tutor_idtutor;
            k.kategorija_idkategorija = rezultat.kategorija_idkategorija;
            k.cijena = rezultat.cijena;
            k.portret = rezultat.portret;
            k.strucnost_idstrucnost = rezultat.strucnost_idstrucnost;

            return k;
        }
        catch (Exception e)
        {
            Console.Write(e.StackTrace.ToString());
            return null;
        }
    }

    public void PostOglas(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        oglas novi = serializer.Deserialize<oglas>(res);
        bazaEntities db = new bazaEntities();

        db.oglas.Add(novi);
        db.SaveChanges();
    }

    public void PUTOglas(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        oglas novi = serializer.Deserialize<oglas>(res);
        bazaEntities db = new bazaEntities();
        db.oglas.Attach(novi);
        db.Entry(novi).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void DELETEOglas(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        oglas novi = serializer.Deserialize<oglas>(res);
        bazaEntities db = new bazaEntities();
        db.oglas.Attach(novi);
        db.Entry(novi).State = EntityState.Deleted;
        db.SaveChanges();
    }
    #endregion

    #region REST_Poruka
    public poruka GETPoruku(string idporuka)
    {
        try
        {
            poruka k = new poruka();
            bazaEntities db = new bazaEntities();
            int idporuke = Convert.ToInt32(idporuka);
            var rezultat = db.poruka.SingleOrDefault(x => x.idporuka == idporuke);

            k.idporuka = rezultat.idporuka;
            k.naslov = rezultat.naslov;
            k.tekst = rezultat.tekst;
            k.datum = rezultat.datum;
            k.korisnik_idkorisnik = rezultat.korisnik_idkorisnik;
            k.tutor_idtutor = rezultat.tutor_idtutor;
            

            return k;
        }
        catch (Exception e)
        {
            Console.Write(e.StackTrace.ToString());
            return null;
        }
    }

    public void PostPoruku(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        poruka novi = serializer.Deserialize<poruka>(res);
        bazaEntities db = new bazaEntities();

        db.poruka.Add(novi);
        db.SaveChanges();
    }

    public void PUTPoruku(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        poruka novi = serializer.Deserialize<poruka>(res);
        bazaEntities db = new bazaEntities();
        db.poruka.Attach(novi);
        db.Entry(novi).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void DELETEPoruku(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        poruka novi = serializer.Deserialize<poruka>(res);
        bazaEntities db = new bazaEntities();
        db.poruka.Attach(novi);
        db.Entry(novi).State = EntityState.Deleted;
        db.SaveChanges();
    }
    #endregion

    #region REST_Strucnost
    public strucnost GETStrucnost(string idstrucnost)
    {
        try
        {
            strucnost k = new strucnost();
            bazaEntities db = new bazaEntities();
            int idstrucnosti = Convert.ToInt32(idstrucnost);
            var rezultat = db.strucnost.SingleOrDefault(x => x.idstrucnost == idstrucnosti);

            k.idstrucnost = rezultat.idstrucnost;
            k.iskustvo = rezultat.iskustvo;

            return k;
        }
        catch (Exception e)
        {
            Console.Write(e.StackTrace.ToString());
            return null;
        }
    }

    public void PostStrucnost(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        strucnost novi = serializer.Deserialize<strucnost>(res);
        bazaEntities db = new bazaEntities();

        db.strucnost.Add(novi);
        db.SaveChanges();
    }

    public void PUTStrucnost(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        strucnost novi = serializer.Deserialize<strucnost>(res);
        bazaEntities db = new bazaEntities();
        db.strucnost.Attach(novi);
        db.Entry(novi).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void DELETEStrucnost(Stream streamdata)
    {
        StreamReader reader = new StreamReader(streamdata);
        string res = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();



        var serializer = new JavaScriptSerializer();
        strucnost novi = serializer.Deserialize<strucnost>(res);
        bazaEntities db = new bazaEntities();
        db.strucnost.Attach(novi);
        db.Entry(novi).State = EntityState.Deleted;
        db.SaveChanges();
    }
#endregion
    #endregion

    #region SOAP

    #region SOAP_Korisnik
    public korisnik Login(string user, string pass)
    {
        try
        {
            korisnik k = db.korisnik.SingleOrDefault(x => x.username == user && x.password == pass);
            return k;
        }
        catch (Exception) { return null; }
    }

    public void Logout()
    {
        throw new NotImplementedException();
    }

    public List<korisnik> dajKorisnike()
    {
        List<korisnik> lista = db.korisnik.Where(x=>true).ToList();
        return lista;
    }

    public void unesiKorisnika(korisnik novi)
    {
        try
        {
            db.korisnik.Add(novi);
            db.SaveChanges();
        }
        catch (Exception) { Console.WriteLine("Nije unesen"); }
    }

    public void promjeniKorisnika(korisnik novi)
    {
        try
        {
            db.korisnik.Attach(novi);
            db.Entry(novi).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void obrisiKorisnika(korisnik novi)
    {
        try
        {
            db.korisnik.Attach(novi);
            db.Entry(novi).State = EntityState.Deleted;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }
    #endregion

    #region SOAP_Tutor
    public tutor LoginTutor(string user, string pass)
    {
        try
        {
            tutor k = db.tutor.SingleOrDefault(x => x.username == user && x.password == pass);
            return k;
        }
        catch (Exception) { return null; }
    }

    public void LogoutTutor()
    {
        throw new NotImplementedException();
    }

    public List<tutor> dajTutore()
    {
        List<tutor> lista = db.tutor.Where(x=>true).ToList();
        return lista;
    }

    public void unesiTutora(tutor novi)
    {
         try
        {
            db.tutor.Add(novi);
            db.SaveChanges();
        }
        catch (Exception) { Console.WriteLine("Nije unesen"); }
    }

    public void promjeniTutora(tutor novi)
    {
       try
        {
            db.tutor.Attach(novi);
            db.Entry(novi).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void obrisiTutora(tutor novi)
    {
         try
        {
            db.tutor.Attach(novi);
            db.Entry(novi).State = EntityState.Deleted;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }
    #endregion

    #region SOAP_Kategorija
    public void UnesiKategoriju(kategorija nova)
    {
        try
        {
            db.kategorija.Add(nova);
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public List<kategorija> vratiKategorije()
    {
         return db.kategorija.Where(x => true).ToList(); 
       
    }

    public void promjeniKategoriju(kategorija nova)
    {
        try
        {
            db.kategorija.Attach(nova);
            db.Entry(nova).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void obrisiKategoriju(kategorija nova)
    {
        try
        {
            db.kategorija.Attach(nova);
            db.Entry(nova).State = EntityState.Deleted;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }
    #endregion

    #region SOAP_Komentar
    public List<komentar> dajKomentare()
    {
        return db.komentar.Where(x => true).ToList();
    }

    public void unesiKomentar(komentar novi)
    {
        try
        {
            db.komentar.Add(novi);
            db.SaveChanges();
        }
        catch (Exception) { Console.WriteLine("Nije unesen"); }
    }

    public void promjeniKomentar(komentar novi)
    {
         try
        {
            db.komentar.Attach(novi);
            db.Entry(novi).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    
    }

    public void obrisiKomentar(komentar novi)
    {
       try
        {
            db.komentar.Attach(novi);
            db.Entry(novi).State = EntityState.Deleted;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }
    #endregion
    
    #region SOAP_Oglas
    public List<oglas> dajOglase()
    {
        return db.oglas.Where(x => true).ToList();
    }

    public void unesiOglas(oglas novi)
    {
        try
        {
            db.oglas.Add(novi);
            db.SaveChanges();
        }
        catch (Exception) { Console.WriteLine("Nije unesen"); }
    }

    public void promjeniOglas(oglas novi)
    {
        try
        {
            db.oglas.Attach(novi);
            db.Entry(novi).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void obrisiOglas(oglas novi)
    {
        try
        {
            db.oglas.Attach(novi);
            db.Entry(novi).State = EntityState.Deleted;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }
    #endregion

    #region SOAP_Poruka
    public List<poruka> dajPoruke()
    {
        return db.poruka.Where(x => true).ToList();
    }

    public void unesiPoruka(poruka novi)
    {
        try
        {
            db.poruka.Add(novi);
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void promjeniPoruka(poruka novi)
    {
        try
        {
            db.poruka.Attach(novi);
            db.Entry(novi).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void obrisiPoruka(poruka novi)
    {
        try
        {
            db.poruka.Attach(novi);
            db.Entry(novi).State = EntityState.Deleted;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }
    #endregion

    #region SOAP_Strucnost
    public List<strucnost> dajStrucnosti()
    {
        return db.strucnost.Where(x => true).ToList();
    }

    public void unesiStrucnost(strucnost novi)
    {
        try
        {
            db.strucnost.Add(novi);
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void promjeniStrucnost(strucnost novi)
    {
        try
        {
            db.strucnost.Attach(novi);
            db.Entry(novi).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }

    public void obrisiStrucnost(strucnost novi)
    {
        try
        {
            db.strucnost.Attach(novi);
            db.Entry(novi).State = EntityState.Deleted;
            db.SaveChanges();
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }
    #endregion

    #endregion
}
