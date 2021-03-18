using Lab4Json.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Json.Repositories
{
    public class Repositoriu
    {
        static public List<Facultate> facultati;
        static public List<Facultate> fac
        {
            get
            {

                facultati = new List<Facultate>()
                {
                    new Facultate
                    {
                        name = "Informatica",
                        desc = "Dezvoltarea Produselor Software",
                        tip = "It",
                       
                    },
                    new Facultate
                    {
                        name = "Chimie",
                        desc = "Chimia aplicata in viata",
                        tip = "Dezvoltarae produselor chimice"
                       

                    },

                };


                return facultati;
            }

        }




        public static void Initialize(FacultateContext context)
        {

            if (!context.facultati.Any())
            {
                context.facultati.AddRange(fac);



            }context.SaveChanges();
        }
    }
}
