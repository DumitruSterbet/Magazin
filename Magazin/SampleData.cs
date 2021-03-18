using System.Collections.Generic;
using System.IO;
using System.Linq;
using Magazin.Models;
using Magazin.ViewModels;

namespace Magazin
{
    public  class SampleData
    {
       
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if (category==null)
                {
                    var list = new Category[]
                    {
                        new Category { Name = "RPG",Img="/img/Categories/rpg.jpg" },
                    new Category { Name = "Survive",Img="/img/Categories/survive.jpg" },
                    new Category { Name = "Strategy",Img="/img/Categories/strategy.jpg" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (var el in list)
                    {
                        category.Add(el.Name, el);
                    } 

                        
                } return category;
            }
        
        
        }


        public static void Initialize(ShopContext context)
        {



                if (!context.Logs.Any()) { 
                    // citirea fisierului cu loguri
                    string[] entries = Directory.GetFileSystemEntries("C:/Users/dp61/source/repos/Magazin/Magazin/wwwroot/Logs/", "*", SearchOption.AllDirectories);
                
                foreach (string el in entries)
                {
                    context.Logs.Add(new Log { name = el });
                   
                }
            }


           
            if (!context.Categories.Any())
            { // Adaugarea in Bd Informatia despre Categorii
                context.Categories.AddRange(

                    Categories.Select(c => c.Value));
             

            }  
            if(!context.Admins.Any())
            {
                context.Admins.Add(new Admin
                {
                login="dima",
                password="1"
                });
            }

                if (!context.Produse.Any())
            {
                context.Produse.AddRange(
                    new Produs
                    {
                        Name = "Assasin Creed : Black Flag",
                        Company = "Ubisoft",
                        Desc = "Este anul 1715. Pirații conduc " +
"Caraibe și și-au stabilit propria republică fără lege, unde corupția, " +
"lăcomia și cruzimea sunt obișnuite.Printre acești haiduci " +
"se află un tânăr căpitan brash pe nume Edward Kenway.Lupta sa pentru glorie i - a câștigat respectul legendelor precum Blackbeard," +
"dar l - a atras și în războiul antic dintre Asasini și Templieri un război care" +
" poate distruge tot ce au construit pirații." +
"Bine ați venit în Epoca de aur a pirateriei.",
                        Img = "assasin.jpg",
                        Path="/img/Produse/",
                        Price = 2800,
                        Favourite = true
                        ,
                        category = Categories["RPG"]

                    },

                    new Produs
                    {
                        Name = "Kenshi ",
                        Company = "Lo-Fi Games",
                        Desc = "Evenimentele sale se desfășoară într-o lume post-apocaliptică fantezie, care este " +
                        "extrem de dificil de a supraviețui. La începutul jocului, personajul nu are abilități utile" +
                        " și trebuie să lupte pentru supraviețuire din primele minute ale jocului. Abilitățile sunt" +
                        " pompate pe măsură ce acțiunile se desfășoară, de exemplu, abilitatea de a fura este pompată atunci " +
                        "când obiectele sunt furate. Jucătorul poate angaja alte unități pentru a extinde echipa și," +
                        " în timp, își poate construi așezarea sau orașul. Sistemul de daune include deteriorarea și pierderea membrelor individuale.",
                        Img = "kenshi.jpg",
                        Path = "/img/Produse/",

                        Price = 2100,
                        Favourite = true
                        ,category = Categories["Survive"]

                    },
                                        new Produs
                                        {
                                            Name = "Civilization V ",
                                            Company = "Firaxis",
                                            Desc =" Civilization V - aceasta este a cincea parte a strategiei turn -" +
                                            " based grand de studio Firaxis Games,"+
                                           " care va prelua toate cele bune din cele patru jocuri anterioare,"+
                                            "precum și se va adăuga o mulțime de noi.În civilizație,"+
                                           " jucătorii își asumă în mod tradițional rolul de lider al uneia dintre puterile lumii și,"+
                                            "începând din cele mai vechi timpuri,"+
                                           " o conduc spre victorie.Pe drumul spre victorie,"+
                                            "jucătorii se pot uni în alianțe,"+
                                           " se pot lupta unul cu celălalt sau pot conduce o politică de izolare completă." +
                                           "Câștigarea civilizației 5 poate fi în mai multe moduri diferite și numai una" +
                                           " dintre ele implică un conflict militar."+
                                       "Jucătorii sunt disponibili pentru a explora un copac uriaș de tehnologie care "+
                                      " acoperă o perioadă de la inventarea armelor de bronz și la construirea navelor spațiale.La început,"+
                                            "jucătorii pot alege din peste trei duzini de națiuni unice,"+
                                            "fiecare având propriile caracteristici și unități unice.În comparație cu cea de - a patra parte,"+
                                            "civilizația 5 are o grafică mult mai perfectă și o interfață mai ergonomică,"+
                                            "care este intuitivă chiar și pentru acei jucători care nu au jucat niciodată jocuri de serie.",
                                            Img = "civ4.jpg",
                                            Path = "/img/Produse/",

                                            Price = 1200,
                                            Favourite = false
                        ,
                                            category = Categories["Strategy"]

                                        },
                                                            
                                                             new Produs
                                                             {
                                                                 Name = "The Elders Scroll V : Skyrim ",
                                                                 Company = "Bethesda Software",
                                                                 Desc = "The Elder Scrolls V: Skyrim este un joc de rol de aventură, a cincea parte din seria The Elder Scrolls, cu o lume imensă deschisă," +
                        " care este pe deplin disponibilă pentru explorare de la început. Jucătorii vor juca rolul lui Dovakin," +
                        " Dragonborn, care apare în provincia Skyrim exact în timpul " +
                        "revenirii dragonilor Legendari, care, conform legendei, vor distruge lumea. Dovakin trebuie să depășească" +
                        " o mulțime de dificultăți în calea scopului său - pentru " +
                        "a opri Dragon Lord Alduin, care se pregătește să copleșească furia lui în întreaga lume.",
                                                                 Img = "skyrim.jpg",
                                                                 Path = "/img/Produse/",

                                                                 Price = 250,
                                                                 Favourite = true

                      ,
                                                                 category = Categories["RPG"]

                                                             },
                           new Produs
                           {
                               Name = "Fallout 4 ",
                               Company = "Bethesda Software",
  Desc = "Fallout 4 este un joc de rol de acțiune dezvoltat de Bethesda Game" +
  " Studios și publicat de Bethesda Softworks. Este al patrulea joc principal" +
  " din seria Fallout și a fost lansat la nivel mondial pe 10 noiembrie 2015," +
  " pentru Microsoft Windows, PlayStation 4 și Xbox One. Jocul se desfășoară într-un mediu post-apocaliptic deschis, " +
  "care cuprinde orașul Boston și regiunea înconjurătoare Massachusetts, cunoscută sub numele de Commonwealth. Se face uz" +
  " de o serie de repere locale, inclusiv Bunker Hill, Fort Independence, " +
  "și Old North Bridge lângă Concord, CA podul din Sanctuary Hills.Povestea principală are loc în anul 2287" +
  ",la zece ani după evenimentele din Fallout 3 și 210 ani după Marele Război," +
  " care a provocat devastări nucleare catastrofale în Statele Unite.Jucătorul își asumă controlul " +
  "asupra unui personaj denumit singurul supraviețuitor,"+
                               "care iese dintr - o stază criogenică pe termen lung în Vault 111,"+
                               "un adăpost subteran de radiații nucleare.După ce asistă la uciderea soțului și răpirea fiului lor,"+
                               "singurul supraviețuitor se aventurează în Commonwealth pentru a - și căuta copilul"+
                               "dispărut.Jucătorul explorează lumea dărăpănată a jocului,"+
                              " completează diverse căutări,"+
                               "ajută facțiunile și dobândește puncte de experiență pentru a crește nivelul și "+
                              " a crește abilitățile personajului lor.Noile caracteristici ale seriei includ"+
                              " capacitatea de a dezvolta și gestiona așezări și un sistem extins de crafting "+
                            "   în care materialele capturate din mediul înconjurător pot fi "+
                              " folosite pentru a crea droguri și explozivi,"+
                             "  pentru a îmbunătăți armele și armurile și pentru a construi,"+
                              " furniza și îmbunătăți așezările.Fallout 4 marchează,"+
                              " de asemenea,"+
                              " primul joc din serie care prezintă o voce completă pentru protagonist.",
                               Img = "fallout.jpg",
                               Path = "/img/Produse/",
                               Price = 1700,
                               Favourite = true
                        ,
                               category = Categories["RPG"]

                           },
                                               new Produs
                                               {
                                                   Name = "FarCry Primal ",
                                                   Company = "Ubisoft",
                                                   Desc = "Din moment ce acțiunea Far Cry Primal are loc în timpurile" +
                                                   " preistorice, convenționale pentru seria de jocuri Far Cry arme " +
                                                   "moderne și de transport în joc lipsesc. Pentru jucători, sunt" +
                                                   " disponibile numai arme de luptă corp la corp: sulițe, bastoane și " +
                                                   "arme cu rază scurtă de acțiune, cum ar fi arcuri. În acest caz, " +
                                                   "nu există nici o modalitate de a cumpăra, jucătorii vor trebui " +
                                                   "să creeze propriile lor arme, folosind obiecte improvizate, cum ar fi lemn și piatră. " +
                                                   "Pe măsură ce progresează în joc, ei vor putea îmbunătăți" +
                                                   " armele, făcându-l mai mortal și mai eficient",
                                                   Img = "farcry.jpg",
                                                   Path = "/img/Produse/",

                                                   Price = 2300,
                                                   Favourite = true
                        ,
                                                   category = Categories["Survive"]

                                               },
                                                                   new Produs
                                                                   {
                                                                       Name = "Rome Total War II ",
                                                                       Company = "The Creative Assembly",
                       Desc = "Total War: Rome II este o strategie pe scară" +
                       " largă pe un nou motor care va permite afișarea zeci de mii de " +
                       "unități pe ecranele jucătorilor. Setting-ul jocului trimite" +
                       " jucători la Roma antică, continuând povestea Romei originale: Total War."+

"Jocul este disponibil 117 facțiuni,   dar puteți juca doar nouă(fără a lua în considerare conținutul suplimentar)" +
" dintre ele.Dezvoltatorii au actualizat sistemul de provincii"+
                                                                      " îmbunătățit și actualizat ecranul de lupta a introdus noi tipuri de unități,"+
                                                                     "  și mai mult.În general,partea de joc a rămas neschimbată - dezvoltatorii tocmai au" +
                                                                     " îmbunătățit și lustruit toate elementele care au nevoie de ea.",
                                                                       Img = "rome.jpeg",
                                                                       Path = "/img/Produse/",

                                                                       Price = 2150,
                                                                       Favourite = false
                        ,
                                                                       category = Categories["Strategy"]

                                                                   },
                                                                                       new Produs
                                                                                       {
                                                                                           Name = "Stellaris ",
                                                                                           Company = "Paradox Developement",
                                                                                           Desc = "Exploreaza minuni complete ale galaxiei într-o strategie Sci-Fi la nivel mondial de la Paradox " +
                                                                                           "Development Studio. Faceți cunoștință cu extratereștrii de rase diferite, " +
                                                                                           "deschide noi planete, face față provocărilor neașteptate și extinde limitele sale",
                                                                                           Img = "stellaris.jpeg",
                                                                                           Path = "/img/Produse/",

                                                                                           Price = 2800,
                                                                                           Favourite = true
                        ,
                                                                                           category = Categories["Strategy"]

                                                                                       },
                    new Produs
                    {
                        Name = "Europa Universalis IV ",
                        Company = "Paradox Universal Studio",
                        Desc = "Jocul este o hartă interactivă a" +
                        " Pământului împărțită în provincii care sunt controlate de orice națiune." +
                        "Fiecare dintre aceste provincii contribuie atât pozitiv,"+
                         


                       " cât și negativ la stat,"+
                        "deoarece provinciile pot oferi simultan resurse(bani, influență comercială, recruți"+
                        ", marinari etc.) și pot servi drept sursă de entuziasm și revolte",
                        Img = "europa.jpg",
                        Path = "/img/Produse/",


                        Price = 1700,
                        Favourite = false
                        ,category = Categories["Strategy"]
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}